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

        private static void RemoveOddNumbers(List<int> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                while ((list[i] % 2) != 0)
                {
                    list.Remove(list[i]);

                    if (list.Count == i)
                    {
                        break;
                    }
                }
            }
        }

        private static List<int> CreateListWithUniqueElements(List<int> list)
        {
            List<int> resultList = new List<int> { list[0] };

            foreach (int elementList in list)
            {
                bool isUniqueElement = true;

                foreach (int elementResultList in resultList)
                {
                    if (elementList == elementResultList)
                    {
                        isUniqueElement = false;
                    }
                }

                if (isUniqueElement)
                {
                    resultList.Add(elementList);
                }
            }

            return resultList;
        }

        public static void Main()
        {
            string fileName = "input.txt";
            List<string> listTask1 = ArrayListHome.ReadToList(fileName);

            Console.WriteLine(string.Join(" ,", listTask1));

            List<int> listTask2 = new List<int> { 1, 1, 2, 10, 3, 4, 27, 99, 5, 6, 7, 7, 8, 8, 9 };

            ArrayListHome.RemoveOddNumbers(listTask2);

            Console.WriteLine(String.Join(" ,", listTask2));

            List<int> listTask3 = new List<int> { 1, 1, 3, 4, 5, 5, 6 };
            List<int> uniqueListTask3 = ArrayListHome.CreateListWithUniqueElements(listTask3);

            Console.WriteLine(string.Join(" ,", uniqueListTask3));
        }
    }
}