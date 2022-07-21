using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Filter_by_Age
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 0; i < inputNumber; i++)
            {
                var inputs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = inputs[0];
                int age = int.Parse(inputs[1]);
                Person person = new Person(name, age);
                persons.Add(person);
            }


            string filterName = Console.ReadLine();
            int ageToCompareWith = int.Parse(Console.ReadLine());

            Func<Person, bool> filterAge = person => true;

            if (filterName == "younger")
            {
                filterAge = person => person.Age < ageToCompareWith;
            }
            else if (filterName == "older")
            {
                filterAge = person => person.Age >= ageToCompareWith;
            }

            var sortedList = persons.Where(filterAge);

            string filterPrint = Console.ReadLine();

            Func<Person, string> funcFilterPrint = person => person.Name + " - " + person.Age;

            if (filterPrint == "name age")
            {
                funcFilterPrint = person => person.Name + " - " + person.Age;
            }
            else if (filterPrint == "name")
            {
                funcFilterPrint = person => person.Name;
            }
            else if (filterPrint == "age")
            {
                funcFilterPrint = person => person.Age.ToString();
            }

            var printList = sortedList.Select(funcFilterPrint);

            foreach (var person in printList)
            {
                Console.WriteLine(person);
            }
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Filter_By_Age_
//{
//    public class Student
//    {
//        public Student(string name, int age)
//        {
//            this.Name = name;
//            this.Age = age;
//        }
//        public string Name { get; set; }
//        public int Age { get; set; }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            List<Student> students = new List<Student>();

//            int lines = int.Parse(Console.ReadLine());

//            for (int i = 0; i < lines; i++)
//            {
//                string[] input = Console.ReadLine().Split(", ");
//                students.Add(new Student(input[0], int.Parse(input[1])));
//            }

//            string filterInput = Console.ReadLine();
//            int ageFilter = int.Parse(Console.ReadLine());
//            string formatInput = Console.ReadLine();

//            Func<Student, int, bool> filter = GetFilter(filterInput);

//            students = students.Where(student => filter(student, ageFilter)).ToList();

//            Action<Student> printer = GetPrinter(formatInput);

//            students.ForEach(printer);
//        }

//        private static Action<Student> GetPrinter(string formatInput)
//        {
//            if (formatInput == "name")
//            {
//                return student => Console.WriteLine(student.Name);
//            }
//            else if (formatInput == "age")
//            {
//                return student => Console.WriteLine(student.Age);
//            }
//            else if (formatInput == "name age")
//            {
//                return student => Console.WriteLine($"{student.Name} - {student.Age}");
//            }
//            else
//            {
//                return null;
//            }
//        }

//        private static Func<Student, int, bool> GetFilter(string filterInput)
//        {
//            if (filterInput == "younger")
//            {
//                return (student, age) => student.Age < age;
//            }
//            else if (filterInput == "older")
//            {
//                return (student, age) => student.Age >= age;
//            }
//            else
//            {
//                return null;
//            }
//        }
//    }
//}