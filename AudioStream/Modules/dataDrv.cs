using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioStream.Modules
{
    public class SelectionChangedEventArg : EventArgs
    {
        public Object? stream;
        public SelectionChangedEventArg(Object? obj) : base()
        {
            stream = obj;
        }
    }

    public class DataDrv
    {
        public event EventHandler<SelectionChangedEventArg>? SelectionChanged;
        public event EventHandler<SelectionChangedEventArg>? SelectedItemChanged;

        private Object? addingObj;
        private BindingSource? xmlDataSource;
        DataView? dataView;
        private List<String> columns = new List<String>();

        public DataDrv(List<String> _columns, String xmlPath = "stream-list.xml")
        {
            SetColumns(_columns);
            string? currentPath = Path.GetDirectoryName(Application.ExecutablePath);
            
            if (currentPath == null) return;

            var xmlData = loadDocument(System.IO.Path.Combine(currentPath, xmlPath));
            StringReader streamReader = new StringReader(xmlData);

            DataSet dataSet = new DataSet();
            dataSet.ReadXml(streamReader);
         
            DataTableCollection tables = dataSet.Tables;
            dataView = new DataView(tables[0]);

            dataView.Sort = "ICAO ASC, FreqType ASC";
        }

        private void SetColumns(List<String> _cols)
        {
            columns.Clear();
            columns.AddRange(_cols);
        }
        
        public void Save(string xmlPath= "")
        {
            if(xmlPath.Length == 0)
            {
                xmlPath = System.IO.Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "stream-list.xml");
            }

            DataTable? dt = dataView?.Table;
            if(dt != null)
            {
                dt.WriteXml(xmlPath);
            }
        }

        private void XmlDataSource_PositionChanged(object? sender, EventArgs e)
        {
            SelectionChanged?.Invoke(xmlDataSource, new SelectionChangedEventArg(GetCurrentStream()));
        }

        public bool IsSelected()
        {
            return xmlDataSource.Position > -1;
        }

        public string loadDocument(string xmlfilePath)
        {
            if (File.Exists(xmlfilePath))
            {
                return System.IO.File.ReadAllText(xmlfilePath);
            }
            else
            {
                return "";
            }
        }

        public Object DataSource
        {
            get 
            { 
                if(xmlDataSource == null)
                {
                    xmlDataSource = new BindingSource();
                    xmlDataSource.PositionChanged += XmlDataSource_PositionChanged;
                    xmlDataSource.CurrentItemChanged += XmlDataSource_CurrentItemChanged;
                    xmlDataSource.DataSource = dataView;
                }
                xmlDataSource.Position = 0;
                return xmlDataSource;
            }
        }

        private void XmlDataSource_CurrentItemChanged(object? sender, EventArgs e)
        {
            SelectedItemChanged?.Invoke(this, new SelectionChangedEventArg(GetCurrentStream()));
        }

        public void AddStream(Object[] obj)
        {
            DataRow dr = dataView.Table.NewRow();
            dr.ItemArray = obj;
            dataView.Table.Rows.Add(dr);
        }

        public List<DataItemWrapper>? FindStream(string fieldName,Object key)
        {
            var colIndex = columns.FindIndex(x => x == fieldName);
            if (colIndex < 0) return null ;

            List<DataItemWrapper> ret = new List<DataItemWrapper>();

            var list = xmlDataSource?.List;
            if (list == null) return null;

            for(int index = 0; index < list.Count;index++)
            {
                DataRowView? drv = list[index] as DataRowView;
                if(drv != null)
                {
                    if(float.TryParse(key.ToString(),out float v))
                    {
                        if (float.Parse(drv.Row.ItemArray[colIndex].ToString()) == v)
                        {
                            DataItem? item = DataItem.parseFromObject(drv.Row.ItemArray);
                            if (item != null) ret.Add(new DataItemWrapper() { Pos = index, Content = item });
                        }
                    }
                    else
                    {
                        if (drv.Row.ItemArray[colIndex].ToString() == key.ToString())
                        {
                            DataItem? item = DataItem.parseFromObject(drv.Row.ItemArray);
                            if (item != null) ret.Add(new DataItemWrapper() { Pos = index, Content = item });
                        }
                    }                    
                }
            }

            return ret;
        }

        public void RemoveStream(int index = -1)
        {
            if(index == -1)
            {
                index = xmlDataSource.Position;
            }

            if(index > -1 && index < xmlDataSource.Count)
            {
                xmlDataSource.RemoveAt(index);
            }
        }

        public void UpgradeStream(Object[] obj,int Position = -1)
        {
            if (Position == -1) Position = xmlDataSource.Position;

            var drv = dataView[Position];
            drv.Row.ItemArray = obj;
        }

        public void Filter(string strFilter)
        {
            if (strFilter == "")
                xmlDataSource?.RemoveFilter();
            else
                dataView.RowFilter = strFilter;
        }

        public void Sort(string strSort = "ICAO ASC, FreqType ASC")
        {
            dataView.Sort = strSort;            //view.Sort = "day ASC, status DESC";

        }
        
        public DataItem? GetCurrentStream()
        {
            Object obj = xmlDataSource.Current;
            if (obj.GetType() == typeof(System.Data.DataRowView))
            {
                DataItem? item = DataItem.parseFromObject((obj as DataRowView).Row.ItemArray);
                return item;
            }
            else
            {
                return null;
            }
        }
    }
}
