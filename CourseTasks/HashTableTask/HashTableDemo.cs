using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableTask
{
    class HashTableDemo
    {
        static void Main()
        {
            HashTable<string> a = new HashTable<string>(10);
            string s = "sss";
            a.Add(s);

            foreach(string aa in a)
            {
                Console.WriteLine(aa);
            }
        }
    }
}
