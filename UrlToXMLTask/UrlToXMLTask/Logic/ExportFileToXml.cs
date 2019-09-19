using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UrlToXMLTask.Interfaces;

namespace UrlToXMLTask.Logic
{
    class ExportFileToXml : File, IExport
    {
        private string _pathToSaveXml;
        List<List<string>> _listOfUrls;
        public ExportFileToXml(string pathToSaveXml, string pathToFile) 
            : base (pathToFile)
        {
            this._pathToSaveXml = pathToSaveXml;
            //base.Records()
        }

        public bool Export()
        {
            
        }

        public List<string> ParsingRecord(string record)
        {
            List<string> obj = new List<string>();
            StringBuilder temp = new StringBuilder(record);

            //add http or https
            obj.Add(record.Split(new string[]{ "://"},StringSplitOptions.RemoveEmptyEntries).First());
            temp = temp.Remove(0, record.Contains("http://") ? 7 : 8);

            //add host name
            obj.Add(temp.ToString().Split('/').First());
            temp = temp.Remove(0, temp.Length - temp.ToString().IndexOf('/') + 1);

            //add other parameters
            string[] strArray = temp.ToString().Split(new char [] { '/' },StringSplitOptions.RemoveEmptyEntries);
            foreach(var s in strArray)
            {
                obj.Add(s);
            }

            return obj;
        }
    }
}
