using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynanic
{
    class Program
    {
        static void Main(string[] args)
        {

            //2. The result of most dynamic operations is itself dynamic
            dynamic d = 1;
            var testSum = d + 3;
            // Rest the mouse pointer over testSum in the following statement.
            System.Console.WriteLine(testSum);

            //3.Any object can be converted to dynamic type implicitly:
            dynamic d1 = 7;
            dynamic d2 = "a string";
            dynamic d3 = System.DateTime.Today;
            dynamic d4 = System.Diagnostics.Process.GetProcesses();
            //Conversely, an implicit conversion can be dynamically applied to any expression of type dynamic.
            int i = d1;
            string str = d2;
            DateTime dt = d3;
            System.Diagnostics.Process[] procs = d4;

            ExampleClass ec = new ExampleClass();
            // The following call to exampleMethod1 causes a compiler error
            // if exampleMethod1 has only one parameter. Uncomment the line
            // to see the error.
            //ec.exampleMethod_int(10, 4);

            dynamic dynamic_ec = new ExampleClass();
            // The following line is not identified as an error by the
            // compiler, but it causes a run-time exception.
            dynamic_ec.exampleMethod_int(10, 4);

            // The following calls also do not cause compiler errors, whether
            // appropriate methods exist or not.
            dynamic_ec.someMethod("some argument", 7, null);
            dynamic_ec.nonexistentMethod();


        }
    }

    class ExampleClass
    {
        public ExampleClass() { }
        public ExampleClass(int v) { }

        public void exampleMethod_int(int i) { }

        public void exampleMethod_str(string str) { }
    }
}
