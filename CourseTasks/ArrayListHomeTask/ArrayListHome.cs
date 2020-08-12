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
            try
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
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException($"Ошибка! Файл {path} отсутствует.");
            }
        }

        private static void RemoveOddNumbers(List<int> list)
        {
            if (list.Count == 0)
            {
                throw new Exception($"Ошибка! Количество элементов в списке = {list.Count}.");
            }

            int i = 0;

            do
            {
                if (list[i] % 2 == 0)
                {
                    list.Remove(list[i]);
                }
                else
                {
                    i++;
                }
            }
            while (list.Count != i);

        }

        private static List<int> CreateListWithUniqueElements(List<int> list)
        {
            if (list.Count == 0)
            {
                throw new Exception($"Ошибка! Количество элементов в списке = {list.Count}.");
            }

            List<int> resultList = new List<int> { list[0] };

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
            string fileName = "input.txt";
            List<string> listTask1 = ReadToList(fileName);

            Console.WriteLine(string.Join(", ", listTask1));

            List<int> listTask2 = new List<int> { 1, 1, 2, 10, 3, 4, 27, 99, 5, 6, 7, 7, 8, 8, 8 };

            RemoveOddNumbers(listTask2);

            Console.WriteLine(string.Join(", ", listTask2));

            List<int> listTask3 = new List<int> { 1, 1, 3, 4, 5, 5, 6 };
            List<int> uniqueListTask3 = CreateListWithUniqueElements(listTask3);

            Console.WriteLine(string.Join(", ", uniqueListTask3));
        }
    }
}