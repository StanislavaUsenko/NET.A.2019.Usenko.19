using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UrlToXMLTask
{
    public class File
    {
        private string _pathToFile;
        private List<string> _records = new List<string>();

        public File(string pathToFile)
        {
            this._pathToFile = pathToFile;
            ReturnList();
        }

        public List<string> Records
        {
            get
            {
                if (_records != null || _records.Count != 0)
                {
                    return _records;
                }
                else
                {
                    throw new ArgumentNullException("File doesn't contains any records");
                }
            }
        }


        private void ReturnList()
        {
            try
            {
                if (ReadFile())
                {
                    foreach (var record in _records)
                    {
                        if (string.IsNullOrWhiteSpace(record))
                        {
                            _records.Remove(record);
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ReadFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(_pathToFile))
                {
                    while (!reader.EndOfStream)
                    {
                        _records.Add(reader.ReadLine());
                    }
                }
                return true;
            }
            catch (Exception ex)
            { 
                return false;
                throw new Exception(ex.Message);

            }
        }
        


    }
}
