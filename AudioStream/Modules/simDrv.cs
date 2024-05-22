using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockheedMartin.Prepar3D.SimConnect;
using System.Runtime.InteropServices;

namespace AudioStream.Modules
{
    public class SimDrv
    {
        public event EventHandler<string>? msgText;
        
        public event EventHandler<uint>? COM1_ACTFREQ_CHANGED;
        public event EventHandler<uint>? COM1_STNBYFREQ_CHANGED;
        public event EventHandler<bool>? CONNECT_STATE_CHANGED;
        public event EventHandler<string>? SIM_ERRO;
        public event EventHandler<Object[]>? AIRPORT_CHANGED;

        public static uint WM_USER_SIMCONNECT = 0x0402;
        static SimConnect? _globalsim;

        private uint oldActiveFreq;
        private uint oldStandbyFreq;

        #region Fields
        private SimConnect? simconnect;
        public SimConnect? connector => simconnect;
#endregion
        public SimDrv()
        {
            simconnect = SimDrv._globalsim;
        }

        enum EVENTS
        {
            ONESECOND=10,
            COM1_RADIO_HZ_SET, //Sets Com1 frequency in Hertz
            COM1_STBY_RADIO_HZ_SET, //Sets Com1 Standby frequency in Hertz
            COM_STBY_RADIO_SET, //Sets COM 1 standby frequency (BCD Hz)
            COM_STBY_RADIO_SWAP, //Swaps COM 1 frequency with standby
            COM_RADIO_SET,//Sets COM frequency (BCD Hz)
            COM_RADIO_WHOLE_DEC,
            COM_RADIO_WHOLE_INC
        };

        enum NOTIFICATION_GROUPS
        {
            COM1_RADIO=0
        }
        
        enum DEFINITIONS
        {
            Struct_1=20,
            Struct_2,
            COM1_ACTIVE_FREQ,
            COM1_STANDBY_FREQ
        }

        enum DATA_REQUESTS
        {
            PLANE_INFO=30,
            COM1_INFO,
            AIRPORT_SUBSCRIBE,
            AIRPORT_UNSUBSCRIBE,
        };

        enum GROUPID
        {
            COM1_ACTIVE_FREQ,
            COM1_STANDBY_FREQ,
            COM1_SWAP
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct Struct_1
        {
            // this is how you declare a fixed size string
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public String title;
            public double latitude;
            public double longitude;
            public double altitude;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct Struct_2
        {
            public uint status;
            public uint activeFreq;
            public uint standbyFreq;
        };

        #region 3rd Party functions
        public void Connect(IntPtr hWnd)
        {
            if(simconnect != null)
            {
                CONNECT_STATE_CHANGED?.Invoke(this, true);
                return;
            }
            if(SimDrv._globalsim != null)
            {
                simconnect = SimDrv._globalsim;
                CONNECT_STATE_CHANGED?.Invoke(this, true);
                return;
            }
            try
            {
                simconnect = new SimConnect("Audio Streaming", hWnd, SimDrv.WM_USER_SIMCONNECT, null, 0);
                SimDrv._globalsim = simconnect;
                oldActiveFreq = oldStandbyFreq = 0;
            //-- listen to connect,quit,exception msgs
                simconnect.OnRecvOpen += new SimConnect.RecvOpenEventHandler(simconnect_CALLBACK_Opened);
                simconnect.OnRecvQuit += new SimConnect.RecvQuitEventHandler(simconnect_CALLBACK_Quit);
                simconnect.OnRecvException += new SimConnect.RecvExceptionEventHandler(simconnect_CALLBACK_Exception);

                #region - Subscribe to Simulator events such as "4sec" and COM1_RADIO turning events.

                simconnect.SubscribeToSystemEvent(EVENTS.ONESECOND, "4sec"); // Or '4sec' => simconnect.UnsubscribeFromSystemEvent(EVENTS.ONESECOND);
 
                simconnect.MapClientEventToSimEvent(EVENTS.COM1_RADIO_HZ_SET, "COM1_RADIO_HZ_SET");
                simconnect.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.COM1_RADIO, EVENTS.COM1_RADIO_HZ_SET, false);

                simconnect.MapClientEventToSimEvent(EVENTS.COM1_STBY_RADIO_HZ_SET, "COM1_STBY_RADIO_HZ_SET");
                simconnect.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.COM1_RADIO, EVENTS.COM1_STBY_RADIO_HZ_SET, false);

                simconnect.MapClientEventToSimEvent(EVENTS.COM_STBY_RADIO_SET, "COM_STBY_RADIO_SET");
                simconnect.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.COM1_RADIO, EVENTS.COM_STBY_RADIO_SET, false);

                simconnect.MapClientEventToSimEvent(EVENTS.COM_STBY_RADIO_SWAP, "COM_STBY_RADIO_SWAP");
                simconnect.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.COM1_RADIO, EVENTS.COM_STBY_RADIO_SWAP, false);

                simconnect.MapClientEventToSimEvent(EVENTS.COM_RADIO_SET, "COM_RADIO_SET");
                simconnect.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.COM1_RADIO, EVENTS.COM_RADIO_SET, false);

                simconnect.MapClientEventToSimEvent(EVENTS.COM_RADIO_WHOLE_DEC, "COM_RADIO_WHOLE_DEC");
                simconnect.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.COM1_RADIO, EVENTS.COM_RADIO_WHOLE_DEC, false);

                simconnect.MapClientEventToSimEvent(EVENTS.COM_RADIO_WHOLE_INC, "COM_RADIO_WHOLE_INC");
                simconnect.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.COM1_RADIO, EVENTS.COM_RADIO_WHOLE_INC, false);

                simconnect.SetNotificationGroupPriority(NOTIFICATION_GROUPS.COM1_RADIO, SimConnect.SIMCONNECT_GROUP_PRIORITY_HIGHEST);

                simconnect.OnRecvEvent += new SimConnect.RecvEventEventHandler(simconnect_CALLBACK_SimulatorEvent);
                
             #endregion

             #region -Define data struct to get from Simulator,Location info
                simconnect.AddToDataDefinition(DEFINITIONS.Struct_1, "Title", null, SIMCONNECT_DATATYPE.STRING256, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct_1, "Plane Latitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct_1, "Plane Longitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct_1, "Plane Altitude", "feet", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                simconnect.RegisterDataDefineStruct<Struct_1>(DEFINITIONS.Struct_1);

                simconnect.OnRecvSimobjectDataBytype += new SimConnect.RecvSimobjectDataBytypeEventHandler(simconnect_CALLBACK_SimulatorData);
             #endregion

             #region - define data struct to get COM1 freqs
                simconnect.AddToDataDefinition(DEFINITIONS.Struct_2, "COM STATUS:1", "enum", SIMCONNECT_DATATYPE.INT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct_2, "COM ACTIVE FREQUENCY:1", "Hz", SIMCONNECT_DATATYPE.INT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct_2, "COM STANDBY FREQUENCY:1", "Hz", SIMCONNECT_DATATYPE.INT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                simconnect.RegisterDataDefineStruct<Struct_2>(DEFINITIONS.Struct_2);
                #endregion

                #region - listen to Airport 
                return;
                simconnect.OnRecvAirportList += new SimConnect.RecvAirportListEventHandler(simconnect_CALLBACK_AirportList);
                simconnect.SubscribeToFacilities(SIMCONNECT_FACILITY_LIST_TYPE.AIRPORT, DATA_REQUESTS.AIRPORT_SUBSCRIBE);// =>simconnect.UnsubscribeToFacilities(SIMCONNECT_FACILITY_LIST_TYPE.AIRPORT);
             #endregion
            }
            catch (COMException ex)
            {
                displayMsg(ex.Message);
            }
        }

        public void Disconnect()
        {
            if (simconnect != null)
            {
                try
                {
                    simconnect.Dispose();
                }
                catch
                { }
                simconnect = null;
                displayMsg("Connection Closed");
            }
        }

        public void RequestPlaneInfo()
        {
            simconnect?.RequestDataOnSimObjectType(DATA_REQUESTS.PLANE_INFO, DEFINITIONS.Struct_1, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
        }

        public void RequestAirportInfos()
        {
            simconnect?.RequestFacilitiesList(SIMCONNECT_FACILITY_LIST_TYPE.AIRPORT, DATA_REQUESTS.AIRPORT_UNSUBSCRIBE);
        }

        public void RequestCOM1Info()
        {
            simconnect?.RequestDataOnSimObjectType(DATA_REQUESTS.COM1_INFO, DEFINITIONS.Struct_2, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
        }

        public void SetCOM1Info(uint freq1=0,uint freq2=0)
        {
            if(freq1 > 0) simconnect?.TransmitClientEvent((uint)SimConnect.SIMCONNECT_OBJECT_ID_USER, EVENTS.COM1_RADIO_HZ_SET, freq1,GROUPID.COM1_ACTIVE_FREQ, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
            if (freq2 > 0) simconnect?.TransmitClientEvent((uint)SimConnect.SIMCONNECT_OBJECT_ID_USER, EVENTS.COM1_STBY_RADIO_HZ_SET, freq2, GROUPID.COM1_STANDBY_FREQ, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        public void SetCOM1Swap()
        {
            simconnect?.TransmitClientEvent((uint)SimConnect.SIMCONNECT_OBJECT_ID_USER, EVENTS.COM_STBY_RADIO_SWAP, (uint)0, GROUPID.COM1_SWAP, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        #endregion

        #region CALLBACK functions
        void simconnect_CALLBACK_Opened(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            CONNECT_STATE_CHANGED?.Invoke(this, true);

            RequestCOM1Info();
            displayMsg("connected to sim");
        }

        void simconnect_CALLBACK_Quit(SimConnect sender, SIMCONNECT_RECV data)
        {
            CONNECT_STATE_CHANGED?.Invoke(this, false);
            Disconnect();
            displayMsg("donnection was closed");
        }

        void simconnect_CALLBACK_Exception(SimConnect sender, SIMCONNECT_RECV_EXCEPTION data)
        {
            SIM_ERRO?.Invoke(this, string.Format("{0}",data.ToString()));
            displayMsg("sim error" + data.ToString());
        }

        void simconnect_CALLBACK_SimulatorEvent(SimConnect sender, SIMCONNECT_RECV_EVENT recEvent)
        {
            switch (recEvent.uEventID)
            {
                case (uint)EVENTS.ONESECOND:
                    displayMsg("4s tick");
                    break;
                case (uint)EVENTS.COM1_RADIO_HZ_SET:
                    RequestCOM1Info();
                    displayMsg("-Set up Com1 frequency in Hertz");
                    break;
                case (uint)EVENTS.COM1_STBY_RADIO_HZ_SET:
                    RequestCOM1Info();
                    displayMsg("-Set up Com1 Standby frequency in Hertz" );
                    break;
                case (uint)EVENTS.COM_STBY_RADIO_SET:
                    RequestCOM1Info();
                    displayMsg("-Set up COM 1 standby frequency (BCD Hz)");
                    break;
                case (uint)EVENTS.COM_STBY_RADIO_SWAP:
                    RequestCOM1Info();
                    displayMsg("-Swaps COM 1 frequency with standby");
                    break;
                case (uint)EVENTS.COM_RADIO_SET:
                    RequestCOM1Info();
                    displayMsg("-Set up COM frequency (BCD Hz)" );
                    break;
                case (uint)EVENTS.COM_RADIO_WHOLE_DEC:
                    RequestCOM1Info();
                    displayMsg("-Decrements COM by one MHz");
                    break;
                case (uint)EVENTS.COM_RADIO_WHOLE_INC:
                    RequestCOM1Info();
                    displayMsg("-Increments COM by one MHz");
                    break;
                default:
                    break;
            }
        }

        void simconnect_CALLBACK_SimulatorData(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {
            switch ((DATA_REQUESTS)data.dwRequestID)
            {
                case DATA_REQUESTS.PLANE_INFO:
                    Struct_1 s1 = (Struct_1)data.dwData[0];
                    displayMsg(string.Format("Title:{0},Lat:{1},Lon:{2},Alt:{3}",s1.title,s1.latitude,s1.longitude,s1.altitude));
                    break;
                case DATA_REQUESTS.COM1_INFO:
                    Struct_2 s2 = (Struct_2)data.dwData[0];
                    if(oldActiveFreq != s2.activeFreq)
                    {
                        oldActiveFreq = s2.activeFreq;
                        COM1_ACTFREQ_CHANGED?.Invoke(this, s2.activeFreq);
                    }
                    if (oldStandbyFreq != s2.standbyFreq)
                    {
                        oldStandbyFreq = s2.standbyFreq;
                        COM1_STNBYFREQ_CHANGED?.Invoke(this, s2.standbyFreq);
                    }

                    displayMsg(string.Format("ActiveFreq={0},StandbyFreq={1}", HzToMhz(s2.activeFreq), HzToMhz(s2.standbyFreq)));
                    break;
                default:
                    displayMsg("Unknown request ID: " + data.dwRequestID);
                    break;
            }
        }

        void simconnect_CALLBACK_AirportList(SimConnect sender, SIMCONNECT_RECV_AIRPORT_LIST data)
        {
            switch ((DATA_REQUESTS)data.dwRequestID)
            {
                case DATA_REQUESTS.AIRPORT_SUBSCRIBE:
                case DATA_REQUESTS.AIRPORT_UNSUBSCRIBE:
                    
                    AIRPORT_CHANGED?.Invoke(this, data.rgData);

                    Dump(data);
                    if (data.rgData.Length > 0)
                        DumpArray(data.rgData);
                    else
                        displayMsg("There is no data");
                    break;

                default:
                    displayMsg("Unknown request ID: " + data.dwRequestID);
                    break;
            }
        }
#endregion

#region utility functions
        private void displayMsg(string str)
        {
            msgText?.Invoke(this, str);
        }

        public static string HzToMhz(uint freq)
        {
            uint positive = freq / 1000000;
            uint unpositive = (freq % 1000000) /1000;
            if (unpositive < 100)
            {
                if(unpositive>10)
                    return string.Format("{0}.0{1}", positive, unpositive);
                else
                    return string.Format("{0}.00{1}", positive, unpositive);
            }
            else
                return string.Format("{0}.{1}", positive, unpositive);
        }

        void Dump(Object item)
        {
            String s = "";
            foreach (System.Reflection.FieldInfo f in item.GetType().GetFields())
            {
                if (!f.FieldType.IsArray)
                {
                    s += "  " + f.Name + ": " + f.GetValue(item);
                }
            }
            displayMsg(s);
        }

        uint Bcd2Dec(uint num)
        {
            return HornerScheme(num, 0x10, 10);
        }

        uint Dec2Bcd(uint num)
        {
            return HornerScheme(num, 10, 0x10);
        }

        uint HornerScheme(uint Num, uint Divider, uint Factor)
        {
            uint Remainder = 0, Quotient = 0, Result = 0; Remainder = Num % Divider; Quotient = Num / Divider;
            if (!(Quotient == 0 && Remainder == 0))
                Result += HornerScheme(Quotient, Divider, Factor) * Factor + Remainder; return Result;
        }

        void DumpArray(Array rgData)
        {
            foreach (Object item in rgData)
            {
                Dump(item);
            }
        }
#endregion
    }
}
