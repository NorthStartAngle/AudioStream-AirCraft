using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AudioStream.Modules
{
    public enum FileType
    {
        File =0,
        Url
    }

    public class DataItemWrapper
    {
        public int Pos;
        public DataItem? Content;

        public DataItemWrapper()
        {
            Pos = -1;
            Content = null;
        }
    }

    public class DataItem
    {
        public DataItem()
        {

        }

        ~DataItem() 
        { }

        private string _icao ="";
        public string ICAO
        {
            get { return _icao; }
            set { _icao = value; }
        }

        private string _airport="";
        public string Airport
        {
            get { return _airport; }
            set { _airport = value; }
        }

        private string _city ="";
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _country ="";
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        private string _freqtype ="";
        public string FreqType
        {
            get { return _freqtype; }
            set { _freqtype = value; }
        }

        private float _freq =118.000f;
        public float Freq
        {
            get { return _freq; }
            set {
                if(value != 118.123) _freq = value; 
            }
        }

        private FileType _filetype=0;
        public FileType Filetypes
        {
            get { return _filetype; }
            set
            {
                _filetype = value;
            }
        }

        private string _filepath="";
        public string FilePath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }

        public static Object[] parseToObject(DataItem si)
        {
            Object[] ret = new Object[8];
            ret[0] = si.ICAO;
            ret[1] = si.Airport;
            ret[2] = si.City;
            ret[3] = si.Country;
            ret[4] = si.FreqType;
            ret[5] = si.Freq;
            ret[6] = si.Filetypes == FileType.File ? "File" : "Url";
            ret[7] = si.FilePath;

            return ret;
        }

        public static DataItem parseFromObject(Object?[] obj)
        {
            DataItem ret = new DataItem();
            if (obj != null)
            {
                var size = obj.Length;
                if (size > 0)
                {
                    ret.ICAO = obj[0].ToString();
                }
                if (size > 1)
                {
                    ret.Airport = obj[1].ToString();
                }
                if (size > 2)
                {
                    ret.City = obj[2].ToString();
                }
                if (size > 3)
                {
                    ret.Country = obj[3].ToString();
                }
                if (size > 4)
                {
                    ret.FreqType = obj[4].ToString();
                }
                if (size > 5)
                {
                    ret.Freq = float.Parse(obj[5].ToString());
                }
                if (size > 6)
                {
                    ret.Filetypes = (FileType)Enum.Parse(typeof(FileType), obj[6].ToString(), true);
                }
                if (size > 7)
                {
                    ret.FilePath = obj[7].ToString();
                }

                return ret;
            }
            else
            {
                return ret;
            }            
        }
    }

    public class AirportItem
    {
        public AirportItem(string icao="",string name="",string city="",string location="",double distance =0)
        {
            ICAO = icao;
            Name = name;
            City = city;
            Location = location;
            Distance = Math.Truncate(100 * distance) / 100;
        }

        ~AirportItem()
        { }

        private string _icao = "";
        public string ICAO
        {
            get { return _icao; }
            set { _icao = value; }
        }

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _city = "";
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _location = "";
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private double _distance = 0;
        public double Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }
    }
}
