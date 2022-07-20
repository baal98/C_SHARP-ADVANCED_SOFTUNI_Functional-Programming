using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(x => char.IsUpper(x[0]));

            Console.WriteLine(String.Join("\n", inputs));
        }
    }
}