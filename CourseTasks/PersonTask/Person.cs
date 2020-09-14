using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTask
{
    class Person
    {
        private string name;
        private int age;

        public string Name { get { return name; } }

        public int Age { get { return age; } }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return Name;
        }

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
            var personList = new List<Person>()
            {
                new Person("Ivan", 30),
                new Person("Ivan", 30),
                new Person("Pavel", 32),
                new Person("Anton", 25),
                new Person("Olga", 22),
                new Person("Anna", 17),
                new Person("Roman", 34)
            };

            var list = personList.Distinct(new PersonByNameComparer()).ToList();

            list.ForEach(Console.WriteLine);

            StringBuilder distinctName = new StringBuilder();
            distinctName.Append("Имена: ")
                        .Append(string.Join(", ", list.Select(p => p.Name)))
                        .Append(".");

            Console.WriteLine(distinctName);

            var minorPersons = personList.Where(p => p.Age < 18).ToList();

            var minorPersonAverageAge = minorPersons.Select(p => p.Age).Sum() / minorPersons.Count();

            minorPersons.ForEach(Console.WriteLine);
            Console.WriteLine(minorPersonAverageAge);

            var a = personList.GroupBy(p => p.Name).ToDictionary(p => p.Key, p => p.ToList().Select(p => p.Age).Sum());

            //var a = personList.GroupBy(p => p.Name).ToList();
            Console.WriteLine(a);
        }
    }
}