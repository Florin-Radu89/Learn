using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable HT = new Hashtable();



            //anonymours types
            var anonymousData = new
            {
                ForeName = "Jignesh",
                SurName = "Trivedi"
            };
            Console.WriteLine("First Name : " + anonymousData.ForeName);

            //jagged arrays
            int[][] jaggedArray = new int[5][];
            jaggedArray[0] = new int[3];
            jaggedArray[1] = new int[5];
            jaggedArray[2] = new int[2];
            jaggedArray[3] = new int[8];
            jaggedArray[4] = new int[10];
            jaggedArray[0] = new int[] { 3, 5, 7, };
            jaggedArray[1] = new int[] { 1, 0, 2, 4, 6 };
            jaggedArray[2] = new int[] { 1, 6 };
            jaggedArray[3] = new int[] { 1, 0, 2, 4, 6, 45, 67, 78 };
            jaggedArray[4] = new int[] { 1, 0, 2, 4, 6, 34, 54, 67, 87, 78 };

            // == vs Equals:  The == Operator compares the reference identity while the Equals() method compares only contents.
            string name = "sandeep";
            string myName = name;
            Console.WriteLine("== operator result is {0}", name == myName);
            Console.WriteLine("Equals method result is {0}", name.Equals(myName));
            myName = "otherValue";
            Console.WriteLine("Other value: == operator result is {0}", name == myName);

            return;

            //const vs readonly
            Test t = new Test();
            t.Check();

            // Boxing  
            int anum = 123;
            Object obj = anum;      //implicit conversion
            Console.WriteLine(anum);
            Console.WriteLine(obj);

            // Unboxing  
            Object obj2 = 123;
            int anum2 = (int)obj;   //explicit conversion
            Console.WriteLine(anum2);
            Console.WriteLine(obj);
            
        }
    }
}
class Test
{
    readonly int read = 10;
    const int cons = 10;
    public Test()
    {
        read = 100; //we can assign it at run time but only through the non-static constructor.
        //cons = 100; //error
    }
    public void Check()
    {
        Console.WriteLine("Read only : {0}", read);
        Console.WriteLine("const : {0}", cons);
    }
}