using System;

namespace HashTableTask
{
    class HashTableDemo
    {
        static void Main()
        {
            HashTable<string> hash = new HashTable<string>(10);

            hash.Add("zero");
            hash.Add("one444");
            hash.Add(null);
            hash.Add(null);
            hash.Add("two");
            hash.Add("three");
            hash.Add("hello");
            hash.Add("four");

            foreach (var element in hash)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();

            Console.WriteLine(hash.Contains("hello"));

            Console.WriteLine(hash.Remove("zero"));

            Console.WriteLine(hash.Contains(null));

            foreach (var element in hash)
            {
                Console.WriteLine(element);
            }

            string[] hashCopy = new string[hash.Count];

            hash.CopyTo(hashCopy, 0);

            Console.WriteLine("TEST");

            foreach (var item in hashCopy)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(hash.Remove(null) + "test");

            foreach (var element in hash)
            {
                Console.WriteLine(element);
            }
        }
    }
}