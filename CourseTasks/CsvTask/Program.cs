using System.IO;

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
                        writer.WriteLine("\ttr");

                        var a = StringParser.GetTableDetails(currenLine, reader);

                        for(var i = 0; i < a.Count; i++)
                        {
                            writer.WriteLine("\t\ttd");

                            writer.WriteLine("\t\t\t"+a[i]);

                            writer.WriteLine("\t\t/td");
                        }
                        writer.WriteLine("\t/tr");
                    }
                }
                writer.WriteLine("/table");
            }
        }
    }
}