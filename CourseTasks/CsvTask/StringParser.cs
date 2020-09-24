using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTask
{
    class StringParser
    {
        public static List<string> GetTableDetails(string line)
        {
            var list = new List<string>();

            if (line.IndexOf('"') == -1)
            {
                var lineSplit = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                
                return lineSplit.ToList();
            }



            return list;
        }

    }
}
