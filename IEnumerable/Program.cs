using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable
{
    class Program
    {
        static void Main()
        {
            int[] values = { 1, 2, 3 };
            List<int> values2 = new List<int>() { 1, 2, 3 };

            // Pass to a method that receives IEnumerable.
            Display(values);
            Display(values2);
            // We can use one method here (Display) to handle arguments of both array and List types. The element type (int) is fixed.
        }

        static void Display(IEnumerable<int> values)
        {
            foreach (int value in values)
            {
                Console.WriteLine(value);
            }
        }
    }
}
