using System;

namespace HashTableTask
{
    class HashTableDemo
    {
        static void Main()
        {
            HashTable<string> hash = new HashTable<string>(10);
            
            hash.Add("a");
            hash.Add("b");
            hash.Add(null);
            hash.Add("bs");
            hash.Add("avv");
            hash.Add("hello");
            hash.Add("aaaa");
            
            foreach (var element in hash)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine(hash.Contains("hello"));

            Console.WriteLine(hash.Remove("b"));

            Console.WriteLine(hash.Contains("b"));

            foreach (var element in hash)
            {
                Console.WriteLine(element);
            }

            string[] arstr = new string[hash.Count];

            hash.CopyTo(arstr,0);

            Console.WriteLine("TEST");

            foreach (var item in arstr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine( hash.Remove("hello")) ;

            foreach (var element in hash)
            {
                Console.WriteLine(element);
            }
        }
    }
}