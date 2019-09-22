using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlToXMLTask.Interfaces;
using UrlToXMLTask.Logic;


namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ExportFileToXml test = new ExportFileToXml("test.xml","test.txt");
            test.Export();
            
        }

        
    }
}
