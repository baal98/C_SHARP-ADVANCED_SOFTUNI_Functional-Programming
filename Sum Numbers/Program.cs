using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(", ").Select(int.Parse);
            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
    }
}
