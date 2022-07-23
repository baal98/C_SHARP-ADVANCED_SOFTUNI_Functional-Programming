//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace Party_Reservation_Filter_Module
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            List<string> inputNames = Console.ReadLine().Split().ToList();

//            string command;

//            while ((command = Console.ReadLine()) != "Print")
//            {
//                string[] inputs = command.Split(';');

//                string action = inputs[0];
//                string filter = inputs[1];
//                string param = inputs[2];

//                Func<string, string, string> func = GetFunc(filter, param);

//                List<string> filteredNames = inputNames.FindAll(func);

//                if (action == "Add filter")
//                {
//                    filteredNames.I;
//                }
//                else if (action == "Remove filter")
//                {
//                    if (filteredNames.Any())
//                    {
//                        filteredNames.Remove(predicate);
//                    }
//                }
//            }
//        }

//        private static Func<string, string, string> GetFunc(string filter, string param)
//        {
//            Func<string, string, string> func;
//            string output = "";
//            if (filter == "Starts with")
//            {
//                func = x => x.StartsWith(param);
//                return func = param.First();
//            }
//            else if (filter == "Ends with")
//            {
//                return x => (char)x.Last() == (char)param[param.Length-1];
//            }
//            else if(filter == "Contains")
//            {
//                return x => x.Contains(param);
//            }
//            else
//            {
//                int length = param.Length;
//                return x => x.Length == length;
//            }
//        }
//    }
//}


namespace Party_Reservation_Filter_Module
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PartyReservationFilterModule
    {
        public class Filter
        {
            public string Command { get; set; }

            public string Arg { get; set; }

            public static string[] FilterCollection(string[] collection, Func<string, bool> filter)
            {
                return collection.Where(n => !filter(n)).ToArray();
            }
        }
        public static void Main()
        {
            var names = Console.ReadLine().Split();
            var filters = GetFilters();
            names = FilterNames(filters, names);
            Console.WriteLine(string.Join(" ", names));
        }

        private static string[] FilterNames(HashSet<Filter> filters, string[] names)
        {
            foreach (Filter filter in filters)
            {
                if (filter.Command.Contains("starts"))
                {
                    names = Filter.FilterCollection(names, n => n.StartsWith(filter.Arg, StringComparison.InvariantCultureIgnoreCase));
                }
                else if (filter.Command.Contains("ends"))
                {
                    names = Filter.FilterCollection(names, n => n.EndsWith(filter.Arg, StringComparison.InvariantCultureIgnoreCase));
                }
                else if (filter.Command.Contains("length"))
                {
                    names = Filter.FilterCollection(names, n => n.Length == int.Parse(filter.Arg));
                }
                else if (filter.Command.Contains("contains"))
                {
                    names = Filter.FilterCollection(names, n => n.ToLower().Contains(filter.Arg.ToLower()));
                }
            }

            return names;
        }

        private static HashSet<Filter> GetFilters()
        {
            // The possible TPRF filter types are: "Starts with", "Ends with", "Length" and "Contains
            var filters = new HashSet<Filter>();
            var input = Console.ReadLine()
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            while (input[0] != "Print")
            {

                var currentFilter = new Filter() { Command = input[1].ToLower(), Arg = input[2] };

                if (input[0].StartsWith("Add"))
                {
                    filters.Add(currentFilter);
                }
                else if (input[0].StartsWith("Remove"))
                {
                    filters.RemoveWhere(f =>
                            f.Arg == currentFilter.Arg &&
                            f.Command == currentFilter.Command);
                }

                input = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            }

            return filters;
        }
    }
}
