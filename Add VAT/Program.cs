using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).Select(x => x * 1.2);

            foreach (var input in inputs)
            {
                Console.WriteLine($"{input:F2}");
            }
        }
    }
}
