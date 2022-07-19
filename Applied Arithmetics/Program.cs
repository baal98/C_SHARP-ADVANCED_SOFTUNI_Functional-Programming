using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine()
                .Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            string command = "";

            while ((command = Console.ReadLine().ToLower().Trim()) != "end")
            {
                Func<int, int> func = x => x;
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", inputs));
                }
                else if (command == "add")
                {
                    func = x => x + 1;
                }
                else if (command == "multiply")
                {
                    func = x => x * 2;
                }
                else if (command == "subtract")
                {
                    func = x => x - 1;
                }
                inputs = inputs.Select(func).ToList();
            }
        }
    }
}
