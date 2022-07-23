//using System;
//using System.Collections.Generic;
//using System.Linq;
//namespace List_of_Predicates
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int start = 1;
//            int end = int.Parse(Console.ReadLine());

//            var dividers = Console.ReadLine().Split().Select(int.Parse);

//            Predicate<int> predicate = null;

//            var newArr = new List<int>();
//            for (int i = start; i <= end; i++)
//            {
//                bool isDivisible = true;
//                foreach (var item in dividers)
//                {
//                    if (!IsDivisible(i, item))
//                    {
//                        isDivisible = false;
//                        break;
//                    }
//                }
//                if (isDivisible)
//                {
//                    newArr.Add(i);
//                }
//            }

//            Console.WriteLine(String.Join(" ", newArr));


//        }
//        static bool IsDivisible(int number, int divider)
//        {
//            if (number % divider == 0)
//            {
//                return true;
//            }
//            return false;
//        }
//    }
//}


namespace List_of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListOfPredicates
    {
        public static void Main()
        {
            var endNumber = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine().Split().Select(int.Parse).Distinct();

            Queue<int> numbers = new Queue<int>();

            Func<int, bool>[] predicates = dividers
                .Select(div => (Func<int, bool>)(n => n % div == 0))
                .ToArray();

            for (int i = 1; i <= endNumber; i++)
            {
                if (IsValid(predicates, i))
                {
                    numbers.Enqueue(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static bool IsValid(Func<int, bool>[] predicates, int num)
        {
            foreach (var predicate in predicates)
            {
                if (!predicate(num))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
