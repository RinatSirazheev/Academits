﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTask
{
    class PersonDemo
    {
        class PersonByNameComparer : IEqualityComparer<Person>
        {
            public bool Equals(Person person1, Person person2)
            {
                if (ReferenceEquals(person1, person2))
                {
                    return true;
                }

                if (ReferenceEquals(null, person1) || ReferenceEquals(null, person2))
                {
                    return false;
                }

                return person1.Name == person2.Name;
            }

            public int GetHashCode(Person obj)
            {
                int prime = 19;
                int hash = 1;

                hash = prime * hash + obj.Age;
                hash = prime * hash + (obj.Name != null ? obj.Name.GetHashCode() : 0);
                return hash;
            }
        }

        static void Main()
        {
            var personsList = new List<Person>()
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

            StringBuilder distinctNamesList = new StringBuilder();

            distinctNamesList.Append("Имена: ")
                             .Append(string.Join(", ", distinctNameslist))
                             .Append(".");

            Console.WriteLine("Список содержащий только уникальные имена.");
            Console.WriteLine(distinctNamesList);
            Console.WriteLine();

            var minorPersons = personsList
                .Where(p => p.Age < 18)
                .ToList();

            var minorPersonsAverageAge = minorPersons
                .Select(Person => Person.Age)
                .Average();

            Console.WriteLine("Список людей младше 18 лет: " + string.Join(", ", minorPersons) + ".");
            Console.WriteLine();

            Console.WriteLine("Средний возраст людей младше 18 лет = " + minorPersonsAverageAge);
            Console.WriteLine();

            Dictionary<string, double> a = personsList
                .GroupBy(Person => Person.Name)
                .ToDictionary(Person => Person.Key, Person => Person.ToList().Select(x => x.Age).Average());

            Console.WriteLine(a["Ivan"]);

            var personsAged20To40 = personsList.Where(p => p.Age >= 20 && p.Age <= 40).OrderByDescending(p => p.Age).ToList();

            Console.WriteLine();

            personsAged20To40.ForEach(Console.WriteLine);
        }
    }
}
