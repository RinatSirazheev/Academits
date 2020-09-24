using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTask
{
    class StringParser
    {
        public static List<string> GetTableDetails(string line, StreamReader reader)
        {
            var list = new List<string>();

            if (line.IndexOf('"') == -1)
            {
                var lineSplit = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                return lineSplit.ToList();
            }

            while (line.Length != 0)
            {
                if (line.StartsWith("\""))
                {
                    int index;

                    if ((index = line.IndexOf("\",")) != -1)
                    {
                        list.Add(line.Substring(1, index - 1));

                        line= line.Remove(0, index + 2);
                    }
                    else
                    {
                        line+=" " + reader.ReadLine();
                    }
                }
            }



            return list;
        }

    }
}
