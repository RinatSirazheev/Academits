﻿using System;
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
                int index;

                if (line.StartsWith("\""))
                {
                    if ((index = line.IndexOf("\",")) != -1)
                    {
                        if (line[index - 1] == '"' && line[index - 2] != '"')
                        {
                            index = line.IndexOf("\",", index + 1);
                        }

                        if (index != -1)
                        {
                            list.Add(line.Substring(1, index - 1));

                            line = line.Remove(0, index + 2);
                        }
                        else
                        {
                            list.Add(line.Substring(1, line.Length - 2));
                            line = line.Remove(0, line.Length -2);
                        }

                    }
                    else
                    {
                        if (line.EndsWith("\""))
                        {
                            list.Add(line.Substring(1, line.Length - 2));
                            line = line.Remove(0, line.Length );
                        }
                        else
                        {
                            line += " " + reader.ReadLine();
                        }

                    }
                }
                else
                {
                    if ((index = line.IndexOf(",")) != -1)
                    {
                        list.Add(line.Substring(0, index));

                        line = line.Remove(0, index + 1);
                    }
                    else
                    {
                        list.Add(line);

                        line = line.Remove(0, line.Length);
                    }


                }
            }

   

            return list;
        }

    }
}
