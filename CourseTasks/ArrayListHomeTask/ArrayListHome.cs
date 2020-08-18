using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ArrayListHomeTask
{
    class ArrayListHome
    {
        private static List<string> ReadToList(string path)
        {
            List<string> list = new List<string>();

            using (StreamReader reader = new StreamReader(path))
            {
                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    list.Add(currentLine);
                }
            }

            return list;
        }

        private static void RemoveEvenNumbers(List<int> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i] % 2 == 0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        private static List<int> CreateListWithUniqueElements(List<int> list)
        {
            List<int> resultList = new List<int> { Capacity = list.Capacity };

            foreach (int elementList in list)
            {
                if (!resultList.Contains(elementList))
                {
                    resultList.Add(elementList);
                }
            }

            return resultList;
        }

        public static void Main()
        {
            try
            {
                string fileName = "input.txt";
                List<string> listTask1 = ReadToList(fileName);

                Console.WriteLine(string.Join(", ", listTask1));
            }
            catch
            {
                Console.WriteLine($"Файл отсутствует!");
            }

            List<int> listTask2 = new List<int> { 1, 1, 2, 10, 3, 4, 27, 99, 5, 6, 7, 7, 8, 8, 8 };

            RemoveEvenNumbers(listTask2);

            Console.WriteLine(string.Join(", ", listTask2));

            List<int> listTask3 = new List<int> { 1, 1, 3, 4, 5, 5, 6 };
            List<int> uniqueListTask3 = CreateListWithUniqueElements(listTask3);

            Console.WriteLine(string.Join(", ", uniqueListTask3));
        }
    }
}