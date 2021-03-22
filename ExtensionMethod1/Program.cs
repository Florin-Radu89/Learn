using ClassLibExtMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod1
{
    public static class XX
    {
        public static void NewMethod(this Class1 ob)
        {
            Console.WriteLine("Hello I m extended method");
            Console.WriteLine($"Hello I m extended method {ob.Print()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Class1 ob = new Class1();
            ob.Display();
            ob.Print();
            ob.NewMethod();
            Console.ReadKey();
        }
    }
}
