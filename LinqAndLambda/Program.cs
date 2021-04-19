using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAndLambda
{
    class Program
    {
        static void Main(string[] args)
        {

            string sentence = "I love cats.";
            string[] catNames = { "Kosto", "Garfield", "Bob", "John", "Hamsi", "Hamsterblaster" };
            List<Person> people = new List<Person>()
            {
                new Person("Tod", 180, 70, Person.Gender.Male),
                new Person("Siggi", 25, 1, Person.Gender.Male),
                new Person("Lena", 178, 65, Person.Gender.Female),
                new Person("Olli", 180, 90, Person.Gender.Male),
                new Person("Luna", 50, 4, Person.Gender.Female),
                new Person("Kara", 170, 78, Person.Gender.Female),
                new Person("Kara", 170, 82, Person.Gender.Female),
                new Person("Mara", 173, 73, Person.Gender.Female),
                new Person("Maria", 174, 66, Person.Gender.Female),
            };
            int[] numbers = { 2, 4, 7, 2, 6, 42, 9, 11, 23, -34, -2, -33, 123, 23, 72, 99 };




            //
            // LINQ used on Objects
            //
            var fourCharPeople = from p in people
                                 where (p.Name.Length == 4)
                                 orderby p.Name descending, p.Weight ascending
                                 select p;

            var fourCharPeopleList = fourCharPeople.ToList();
            fourCharPeople.ToList().ForEach(p => Console.WriteLine($"{p.Name} weights {p.Weight}"));


            //
            // Array to List - Two versions
            //
            //numbers.ToList().ForEach(Console.WriteLine);
            //var numberList = new List<int>(numbers);
            //numberList.ForEach(Console.WriteLine);



            //
            // Example 2
            // 
            //var catsWithO = from cat in catNames
            //                where cat.Contains("o") && (cat.Length < 5)
            //                orderby cat descending
            //                select cat;
            //Console.WriteLine(string.Join(",", catsWithO));



            //
            // Example 1
            // 
            //Console.WriteLine(" ---------------------- using LINQ ----------------------");
            //var getNumbers = from number in numbers
            //                 where number > 2
            //                 select number;
            //Console.WriteLine(string.Join(',', getNumbers));

            //// without Linq
            //List<int> tempList = new();
            //foreach (int number in numbers)
            //{
            //    if (number > 2)
            //    {
            //        tempList.Add(number);
            //    }
            //}
            //Console.WriteLine(string.Join(',', tempList));



        }
    }

    internal class Person
    {

        private int height;
        private int weight;
        private string name;
        private Gender gender;


        public Person(string name, int height, int weight, Gender gender)
        {
            this.Name = name;
            this.Height = height;
            this.Weight = weight;
            this.MyGender = gender;
        }


        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Gender MyGender
        {
            get { return gender; }
            set { gender = value; }
        }


        internal enum Gender
        {
            Male,
            Female,
            Div
        }
    }
}
