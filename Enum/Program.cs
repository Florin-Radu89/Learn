using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumeration
{
    class Program
    {
        public enum DayofWeek
        {
            Sunday = 1, Monday, Tuesday = 1, Wednesday, Thursday = 2, Friday, Saturday
        }
        static void Main(string[] args)
        {
            string[] values = Enum.GetNames(typeof(DayofWeek));
            foreach (string s in values)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            int[] n = (int[])Enum.GetValues(typeof(DayofWeek));
            foreach (int x in n)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();
        }
    }
}
