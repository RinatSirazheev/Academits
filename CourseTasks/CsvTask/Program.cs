﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTask
{
    class Program
    {
        static void Main()
        {
            var inFilePath = "..//..//inFile.txt";
            var outFilePath = "..//..//outFile.txt";
            
            using (var writer = new StreamWriter(outFilePath))
            {
                writer.WriteLine("table");

                using (var reader = new StreamReader(inFilePath))
                {
                    string currenLine;

                    while ((currenLine = reader.ReadLine()) != null)
                    {
                        writer.WriteLine("tr");

                        var a = StringParser.GetTableDetails(currenLine, reader);




                        writer.WriteLine("/tr");

                    }
                }

                writer.WriteLine("/table");
            }

        }
    }
}
