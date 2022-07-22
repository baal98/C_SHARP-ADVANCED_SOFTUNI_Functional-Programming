using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split();

            Action<string> action = input => PrintName(input);

            foreach (var input in inputs)
            {
                action(input);
            }
        }
        private static void PrintName(string input)
        {
            Console.WriteLine($"Sir {input}");
        }
    }
}
