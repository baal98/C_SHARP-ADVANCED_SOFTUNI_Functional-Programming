using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int start = inputs[0];
            int end = inputs[1];

            string command = Console.ReadLine();

            Predicate<int> predicate;

            if (command == "odd")
            {
                predicate = x => x % 2 != 0;
            }
            else if (command == "even")
            {
                predicate = x => x % 2 == 0;
            }
            else
            {
                predicate = null;
            }

            List<int> sortedList = PrintEvenOrOdd(start, end, predicate);

            //This is valid with LINQ;
            //List<int> numbers = new List<int>();

            //for (int i = start; i <= end; i++)
            //{
            //    numbers.Add(i);
            //}
            //List<int> sortedList2 = numbers.Where(w => predicate(w)).ToList();
            //Console.WriteLine(String.Join(" ", sortedList2));

            Console.WriteLine(String.Join(" ", sortedList));
        }

        private static List<int> PrintEvenOrOdd(int start, int end, Predicate<int> predicate)
        {
            List<int> numbers = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (predicate(i))
                {
                    numbers.Add(i);
                }
            }
            return numbers;
        }
    }
}
