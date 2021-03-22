using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readonly
{
    class Test
    {
        readonly int read = 10;
        const int cons = 10;
        public Test()
        {
            read = 100;
            //Error CS0131  The left-hand side of an assignment must be a variable, property or indexer 
            //cons = 100; 
        }
        public void Check()
        {
            Console.WriteLine("Read only : {0}", read);
            Console.WriteLine("const : {0}", cons);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            test.Check();
        }
    }
}
