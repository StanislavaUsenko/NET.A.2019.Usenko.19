using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var c in ParsingRecord("https://github.com/AnzhelikaKravchuk?tab=repositories"))
            {
                Console.WriteLine(c);
            }
            Console.ReadLine();
        }

        public static List<string> ParsingRecord(string record)
        {
            Dictionary<string, string> parameter = new Dictionary<string, string>();

            List<string> obj = new List<string>();
            StringBuilder temp = new StringBuilder(record);

            //add http or https
            obj.Add(record.Split(new string[] { "://" }, StringSplitOptions.RemoveEmptyEntries).First());
            temp = temp.Remove(0, record.Contains("http://") ? 7 : 8);

            //add host name
            obj.Add(temp.ToString().Split('/').First());
            temp = temp.Remove(0, temp.ToString().IndexOf('/') + 1);

            //add other parameters
            string[] strArray = temp.ToString().Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in strArray)
            {
                if (s.Contains('?'))
                {
                    string[] tempParameter = s.Split('?');
                    obj.Add(tempParameter[0]);
                    if (tempParameter[1].Contains('='))
                    {
                        tempParameter = tempParameter[1].Split('=');
                        parameter.Add(tempParameter[0], tempParameter[1]);
                    }
                    parameter.Add("", tempParameter[1]);
                }
                else
                {
                    obj.Add(s);
                }
            }

            Console.WriteLine(parameter.First().ToString());
            return obj;
        }
    }
}
