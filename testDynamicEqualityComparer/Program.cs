using System;
using System.Collections.Generic;

namespace testDynamicEqualityComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Person, Person, bool> comparer = (x, y) => x.Age == y.Age && x.Name == y.Name && x.Phone.Phone1 == y.Phone.Phone1;
            var data = GetData().DistinctWithComparer(comparer);

            foreach (var d in data)
            {
                Console.WriteLine(d); 
            }

            Console.ReadKey();
        }

        private static IEnumerable<Person> GetData()
        {
            for (int i = 0; i < 1000000; i++)
            {
                var person = new Person
                {
                    Age = 18, Name = "cash", Phone = new Phone
                    {
                        Phone1 = 123,
                        Phone3 = 456
                    }
                };

                if (i == 2)
                {
                    person.Phone.Phone3 = 111;
                }

                if (i == 3)
                {
                    person.Phone.Phone1 = 223;
                }

                yield return person;
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
        
        public Phone Phone { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}, {nameof(Phone)}: {Phone}";
        }
    }

    public class Phone
    {
        public int Phone1 { get; set; }
        
        public int Phone3 { get; set; }

        public override string ToString()
        {
            return $"{nameof(Phone1)}: {Phone1}, {nameof(Phone3)}: {Phone3}";
        }
    }
}