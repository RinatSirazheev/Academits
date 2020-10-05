using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonTask
{
    class PersonDemo
    {
        static void Main()
        {
            var personsList = new List<Person>
            {
                new Person("Ivan", 30),
                new Person("Ivan", 14),
                new Person("Pavel", 32),
                new Person("Anton", 25),
                new Person("Olga", 22),
                new Person("Anna", 17),
                new Person("Roman", 34)
            };

            var distinctNamesList = personsList
                .Select(p => p.Name)
                .Distinct()
                .ToList();

            var distinctNames = new StringBuilder()
                .Append("Имена: ")
                .Append(string.Join(", ", distinctNamesList))
                .Append(".");

            Console.WriteLine("Список содержащий только уникальные имена.");
            Console.WriteLine(distinctNames);
            Console.WriteLine();

            var minorPersons = personsList
                .Where(p => p.Age < 18)
                .ToList();

            var minorPersonsAverageAge = minorPersons
                .Select(p => p.Age)
                .Average();

            Console.WriteLine("Список людей младше 18 лет: " + string.Join(", ", minorPersons) + ".");
            Console.WriteLine();

            Console.WriteLine("Средний возраст людей младше 18 лет = " + minorPersonsAverageAge + " лет.");
            Console.WriteLine();

            var peoplesAveragesAgesMap = personsList
                .GroupBy(p => p.Name)
                .ToDictionary(personsGroups => personsGroups.Key, personsGroups => personsGroups.Average(p => p.Age));

            Console.WriteLine("Коллекция в которой ключи - имена, а значения - средний возраст:");

            foreach (var pair in peoplesAveragesAgesMap)
            {
                Console.WriteLine(pair.Key + " - " + pair.Value);
            }

            Console.WriteLine();

            var personsAged20To40 = personsList
                .Where(p => p.Age >= 20 && p.Age <= 40)
                .OrderByDescending(p => p.Age)
                .ToList();

            Console.WriteLine("Список людей, возраст которых от 20 до 45 лет:");
            personsAged20To40.ForEach(Console.WriteLine);
        }
    }
}