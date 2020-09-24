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

            var distinctNameslist = personsList
                .Select(Person => Person.Name)
                .Distinct()
                .ToList();

            var distinctNames = new StringBuilder();

            distinctNames.Append("Имена: ")
                             .Append(string.Join(", ", distinctNameslist))
                             .Append(".");

            Console.WriteLine("Список содержащий только уникальные имена.");
            Console.WriteLine(distinctNames);
            Console.WriteLine();

            var minorPersons = personsList
                .Where(p => p.Age < 18)
                .ToList();

            var minorPersonsAverageAge = minorPersons
                .Select(Person => Person.Age)
                .Average();

            Console.WriteLine("Список людей младше 18 лет: " + string.Join(", ", minorPersons) + ".");
            Console.WriteLine();

            Console.WriteLine("Средний возраст людей младше 18 лет = " + minorPersonsAverageAge + " лет.");
            Console.WriteLine();

            var peoplesAveragesAgesMap = personsList
                .GroupBy(Person => Person.Name)
                .ToDictionary(Person => Person.Key, Person => Person.ToList().Select(p => p.Age).Average());

            Console.WriteLine("Коллекция в которой ключи - имена, а значения - средний возраст:");
            foreach (KeyValuePair<string, double> valuePair in peoplesAveragesAgesMap)
            {
                Console.WriteLine(valuePair.Key + " - " + valuePair.Value);
            }
            Console.WriteLine();

            var personsAged20To40 = personsList
                .Where(Person => Person.Age >= 20 && Person.Age <= 40)
                .OrderByDescending(Person => Person.Age)
                .ToList();

            Console.WriteLine("Список людей, возраст которых от 20 до 45 лет:");
            personsAged20To40.ForEach(Console.WriteLine);
        }
    }
}