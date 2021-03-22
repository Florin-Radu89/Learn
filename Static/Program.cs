using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static
{
    using System;
    class MyClass
    {
        private static int x;
        public static int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int MyProperty { get; set; }
    }
    class MyClient
    {
        public static void Main()
        {
            MyClass.X = 10;
            int xVal = MyClass.X;
            Console.WriteLine(xVal);

            MyClass myClass = new MyClass();
            MyClass anObject = myClass;
            Console.WriteLine(anObject.MyProperty);


        }
    }
}
