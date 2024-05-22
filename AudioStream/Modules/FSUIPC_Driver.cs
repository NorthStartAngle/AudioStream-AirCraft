using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using FSUIPC;
using LockheedMartin.Prepar3D.SimConnect;
using Microsoft.VisualBasic.ApplicationServices;
using NAudio.Wave;


namespace AudioStream.Modules
{
    public class FSUIPC_Driver
    {
        private Offset<uint> com1_active = new Offset<uint>("COM1", 0x05C4);//05C4
        private Offset<uint> com1_standby = new Offset<uint>("COM1", 0x05CC);//05CC 
        private Offset<FsLongitude> playerLon = new Offset<FsLongitude>("LatLonArea", 0x0568, 8);
        private Offset<FsLatitude> playerLat = new Offset<FsLatitude>("LatLonArea", 0x0560, 8);

        FsLongitude old_playerLon = new FsLongitude(0.0f);
        FsLatitude old_playerLat = new FsLatitude(0.0f);

        public event EventHandler<bool>? CONNECT_STATE_CHANGED;
        public event EventHandler<string>? SIM_ERRO;
        public event EventHandler<uint>? COM1_ACTFREQ_CHANGED;
        public event EventHandler<uint>? COM1_STNBYFREQ_CHANGED;
        public event EventHandler<bool>? AIRPORTDATABASE_LOADEDDONE;
        public event EventHandler<string>? msgText;
        public event EventHandler<List<AirportItem>>? AIRPORT_CHANGED;

        System.Timers.Timer? mainTimer;
        System.Timers.Timer? mainEventTimer;
        System.Timers.Timer? airpotTimer;
        FsLatLonPoint? playerPos_prev;
        AirportsDatabase? db;
        double away_limit = 5.0f;
        Task? dbTask;
        List<AirportItem> beforelist = new List<AirportItem>();
        bool radiusChanged = false;
        bool autoConnect = false;
        public static FSUIPC_Driver FS_GLOBAL = null;
        
        public FSUIPC_Driver(double rad =40)
        {
            _radius = rad;
            mainTimer = null;
            CONNECT_STATE = false;
            playerPos_prev = null;

            mainEventTimer = new System.Timers.Timer();
            mainEventTimer.Elapsed += OnMainEventTimedEvent;
            mainEventTimer.Interval = 200;
            db = null;
            dbTask = null;

            FSUIPC_Driver.FS_GLOBAL = this;

            airpotTimer = new System.Timers.Timer();
            airpotTimer.Elapsed += OnAirpotEventTimedEvent;
            airpotTimer.Interval = 1000;
            airpotTimer.Start();
        }
        
        bool refreshed;
        ~FSUIPC_Driver()
        {
            Disconnect();
            mainTimer?.Stop();
            mainTimer?.Dispose();
            mainEventTimer?.Stop();
            mainEventTimer?.Dispose();
            airpotTimer?.Stop();
            airpotTimer?.Dispose();
            if (db != null)
            {
                db.Clear();
                db = null;
            }
            dbTask?.Dispose();
            refreshed = false;
        }

        bool connected = false;
        public bool CONNECT_STATE
        {
            get { return connected; }
            set
            {
                if(connected != value)
                {
                    connected = value;
                    CONNECT_STATE_CHANGED?.Invoke(this, connected);
                    refreshed = false;
                    if (connected)
                    {
                        radiusChanged = true;
                        mainEventTimer?.Start();
                    }
                    else
                    {
                        beforelist.Clear();
                        mainEventTimer?.Stop();
                        AIRPORT_CHANGED?.Invoke(this, beforelist);

                        old_playerLon = new FsLongitude(0.0f);
                        old_playerLat = new FsLatitude(0.0f);
                    }
                }
            }
        }

        string strDbPath = "";// "F:\\12_AudioStream\\FSUIPC\\MakeRunwaysOutput";
        public string AirportDBPath
        {
            get { return strDbPath; }
            set
            {
                strDbPath = value;
                SetAirportDB(true);
            }
        }

        double _radius;
        public double Radius
        {
            get { return _radius; }
            set
            {
                if(_radius != value)
                {
                    _radius = value;
                    radiusChanged = true;
                    //refreshAirportDatas(true);
                }               
            }
        }
        
        public bool AutoConnectAble
        {
            get { return autoConnect; }
            set
            {
                autoConnect = value;
            }
        }
        public void SetAirportDB(bool dispatchable = false)
        {
            if (strDbPath != "" && FSUIPCConnection.IsOpen)
            {
               if (dbTask != null) dbTask.Dispose();
               dbTask = Task.Run(async () =>
               {
                   if (db != null)
                   {
                       db.Clear();
                   }
                   db = FSUIPCConnection.AirportsDatabase;
                   db.MakeRunwaysFolder = strDbPath;
                   if (db.MakeRunwaysFilesExist)
                   {
                       if (!db.DatabaseFilesExist)
                       {
                           await db.RebuildDatabaseAsync();
                       }
                       if (db.DatabaseFilesExist)  db.Load();
                   }
                   if(dispatchable) AIRPORTDATABASE_LOADEDDONE?.Invoke(this, db.IsLoaded);
                   beforelist.Clear();
               });
            }
            else
            {
               if (dispatchable) AIRPORTDATABASE_LOADEDDONE?.Invoke(this, false);
            }
        }

        void OnMainTimedEvent(Object? source, ElapsedEventArgs? e)
        {
            if (FSUIPCConnection.IsOpen)
            {
                CONNECT_STATE = true;
            }
            else
            {
                CONNECT_STATE = false;

                if(AutoConnectAble)
                {
                    try
                    {
                        FSUIPCConnection.Open();
                    }
                    catch (FSUIPCException)
                    {}
                }
            }
        }

        void OnMainEventTimedEvent(Object? source, ElapsedEventArgs? e)
        {
            if (FSUIPCConnection.IsOpen)
            {
                FSUIPCConnection.Process("COM1");

                if (com1_active.ValueChanged || !refreshed)
                {
                    COM1_ACTFREQ_CHANGED?.Invoke(this, com1_active.Value);
                }

                if (com1_standby.ValueChanged || !refreshed)
                {
                    COM1_STNBYFREQ_CHANGED?.Invoke(this, com1_standby.Value);
                }

                refreshed = true;
            }
        }

        void refreshAirportDatas(bool flag)
        {
            if (!flag) return;
            radiusChanged = false;
            FsAirportCollection airports = FSUIPCConnection.AirportsDatabase.Airports;

            airports.SetReferenceLocation(AirportComponents.None);
            airports = airports.InRangeOfNauticalMiles(Radius);
            airports.LoadComponents(AirportComponents.Runways);
            List<FsAirport> lstAirPort = airports.ToList();

            List<AirportItem> arrAirports = new List<AirportItem>();

            foreach (FsAirport airport in lstAirPort)
            {
                AirportItem api = new AirportItem(airport.ICAO, airport.Name, airport.City, airport.Location.ToString(), airport.DistanceNauticalMiles);
                arrAirports.Add(api);
            }
            arrAirports.Sort(CompareString);
            beforelist.Sort(CompareString);

            bool same = arrAirports.Select(x => x.ICAO).ToHashSet().SetEquals(beforelist.Select(x => x.ICAO));

            if (!same)
            {
                beforelist.Clear();
                beforelist.AddRange(arrAirports);
                AIRPORT_CHANGED?.Invoke(this, arrAirports);
            }
        }
        
        bool PlayerMoved(double distance = 10000)
        {
            FsLatLonPoint oldPt = new FsLatLonPoint(old_playerLat, old_playerLon);
            FsLatLonPoint curPt = new FsLatLonPoint(playerLat.Value, playerLon.Value);
            if (oldPt.DistanceFromInMetres(curPt) > distance)
            {
                old_playerLat = new FsLatitude(playerLat.Value.DecimalDegrees);
                old_playerLon = new FsLongitude(playerLon.Value.DecimalDegrees);

                return true;
            }
            else
                return false;
        }

        void OnAirpotEventTimedEvent(Object? source, ElapsedEventArgs? e)
        {
            if (FSUIPCConnection.IsOpen )
            {
                if(db != null && db.IsLoaded)
                {
                    FSUIPCConnection.Process("LatLonArea");

                    refreshAirportDatas(PlayerMoved() || radiusChanged);
                }
                else
                {
                    if (strDbPath != "")
                    {
                        if(dbTask != null && !dbTask.IsCompletedSuccessfully)
                        {
                            return;
                        }
                        SetAirportDB();
                    }
                }
            }
        }

        public void Connect(bool IsAuto = false)
        {
            AutoConnectAble = IsAuto;
            if (FSUIPCConnection.IsOpen)
            {
                return;
            }
            
            try
            {
                FSUIPCConnection.Open();                
            }
            catch (FSUIPCException ex)
            {
                SIM_ERRO?.Invoke(this, string.Format("{0}", ex.ToString()));
            }

            mainTimer = new System.Timers.Timer();
            mainTimer.Elapsed += OnMainTimedEvent;
            mainTimer.Interval = 1500;
            mainTimer.Start();
        }

        public void Disconnect()
        {
            autoConnect = false;
            FSUIPCConnection.Close();
        }

        public void RequestPlaneInfo()
        {
            FSUIPCConnection.Process("LatLonArea");
        }
        
        public void SetCOM1Info(uint freq1 = 0, uint freq2 = 0)
        {
            if (!CONNECT_STATE) return;
            lock (this.com1_active)
            {
                if (freq1 > 0)
                {
                    this.com1_active.Value = freq1;
                }
            }
            lock (this.com1_standby)
            {
                if (freq2 > 0)
                {
                    this.com1_standby.Value = freq2;
                }
            }

            FSUIPCConnection.Process("COM1");
        }

        public void COM1_swap()
        {
            if (!CONNECT_STATE) return;
            FSUIPCConnection.SendControlToFS(FsControl.COM_STBY_RADIO_SWAP, 0);
        }
    
        public static uint convertToHz(ushort num)
        {
            if (num == 0) return 0;

            int num1 = num & 0xFF00;
            int op_1 = num1 / 0x100;
            int op_2 =  num & 0xFF;

            string hex_op_1 = op_1.ToString("X");
            string hex_op_2 = op_2.ToString("X");

            uint num2 = uint.Parse(hex_op_1) * 1000 + uint.Parse(hex_op_2) * 10 + 100000;
            if (num2 % 25 == 0)
            {
                return num2;
            }
            else if ((num2 - 5) % 25 == 0)
            {
                return num2 - 5;
            }
            else if ((num2 + 5) % 25 == 0)
            {
                return num2 + 5;
            }
            else
                return 0;
        }

        public static bool IsAvaiableMHz(float num)
        {
            int num2 = (int)(num * 1000) - (int)num * 1000;
            string s = num2.ToString();
            return s.EndsWith("00") || s.EndsWith("25") || s.EndsWith("50") ||s.EndsWith("75");
        }

        public static int CompareString(AirportItem str1, AirportItem str2)
        {
            return String.Compare(str1.ICAO, str2.ICAO, comparisonType: StringComparison.OrdinalIgnoreCase);
        }

        public static int CompareDouble(AirportItem s1, AirportItem s2)
        {
            if (s1.Distance > s2.Distance) return 1;
            if (s1.Distance == s2.Distance) return 0;
            if (s1.Distance < s2.Distance) return -1;
            return -1;
        }
    }
}