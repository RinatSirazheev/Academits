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
            HashTable<int> hash = new HashTable<int>(10);
            
            hash.Add(1);
            hash.Add(2);
            hash.Add(5);

            foreach(int element in hash)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine(hash.Remove(2));

            foreach (int element in hash)
            {
                Console.WriteLine(element);
            }
        }
    }
}
