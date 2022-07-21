using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            Func<double[], double> func = MinValue;
            var value = func(inputs);
            Console.WriteLine(value);

        }

        private static double MinValue(double[] inputs)
        {
            double min = double.MaxValue;
            foreach (var input in inputs)
            {
                if (input < min)
                {
                    min = input;
                }
            }
            return min;
        }
    }
}