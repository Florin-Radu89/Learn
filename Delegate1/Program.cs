using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate1
{
    class Program
    {
        public delegate int IncreaseByANumber(int j);
        public delegate int MultipleIncreaseByANumber(int j, int k, int l);

        static public int MultiplyByANumber(int j)
        {
            return j * 42;
        }

        public static void ExecuteCSharp1_0()
        {
            //TODO: delegate
            //IncreaseByANumber increase =
            //   new IncreaseByANumber(DelegatesEventsLambdaExpressions.MultiplyByANumber);
            //Console.WriteLine(increase(10));
        }
        static void Main(string[] args)
        {

        }
    }
}
