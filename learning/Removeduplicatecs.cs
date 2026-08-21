namespace learningprojectserver.learning
{
    using System.Collections.Generic;
    using System.Linq;

    public class Example
    {
        public static void Main(string[] args)
        {
            List<int> numbersWithDuplicates = new List<int> { 1, 2, 2, 3, 4, 4, 5 };
            List<int> distinctNumbers = numbersWithDuplicates.Distinct().ToList();

            // Output: 1, 2, 3, 4, 5
            foreach (int number in distinctNumbers)
            {
                System.Console.WriteLine(number);
            }

            hascode();


        }

        public static void hascode()
        {

            List<string> namesWithDuplicates = new List<string> { "Alice", "Bob", "Alice", "Charlie" };

            HashSet<string> removedduplicate = new HashSet<string>(namesWithDuplicates);

            List<string> duplicateremovedlist = removedduplicate.ToList();

            foreach (string duplicate in duplicateremovedlist)
            {
                System.Console.WriteLine(duplicate, "duplicate");
            }

            RemoveProperty();


        }
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        //DistinctBy works only in .NET 6 and above.
        // public static void RemoveProperty(){


        //      List<Person> peopleWithDuplicates = new List<Person>
        //     {
        //         new Person { Name = "Alice", Age = 30 },
        //         new Person { Name = "Bob", Age = 25 },
        //         new Person { Name = "Alice", Age = 30 } // Duplicate based on Name and Age
        //     };

        //   List<Person> distinctPeopleByName = peopleWithDuplicates.DistinctBy(p => p.Name).ToList();


        //     foreach (Person p in distinctPeopleByName)
        //     {
        //         System.Console.WriteLine($"{p.Name} ({p.Age})");
        //     }

        // }

        public static void RemoveProperty()
        {
            List<Person> peopleWithDuplicates = new List<Person>
        {
            new Person { Name = "Alice", Age = 30 },
            new Person { Name = "Bob", Age = 25 },
            new Person { Name = "Alice", Age = 30 }
        };

            // ✅ Compatible with ALL .NET versions
            List<Person> removeDuplicate = peopleWithDuplicates
                .GroupBy(p => p.Name)   // remove duplicates by Name
                .Select(g => g.First())
                .ToList();

            foreach (Person p in removeDuplicate)
            {
                System.Console.WriteLine($"{p.Name} ({p.Age})");
            }

            Withoutlinq();
        }

        public static void Withoutlinq()
        {

            List<int> numbersWithDuplicates = new List<int> { 1, 2, 2, 3, 4, 4, 5 };
            List<int> distinctNumbers = new List<int>();

            foreach (int num in numbersWithDuplicates)
            {

                if (!distinctNumbers.Contains(num))
                {
                    distinctNumbers.Add(num);
                }
            }


            foreach (int number in distinctNumbers)
            {
                System.Console.WriteLine(number);
            }
        }
    }




}
