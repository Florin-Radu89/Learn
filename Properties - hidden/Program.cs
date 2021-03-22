using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties___hidden
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties
    //This example demonstrates how to access a property in a base class that is hidden by another property that has the same name in a derived class:
    public class Employee
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }

    public class Manager : Employee
    {
        private string _name;

        // Notice the use of the new modifier:
        public new string Name
        {
            get => _name;
            set => _name = value + ", Manager";
        }
    }

    class TestHiding
    {
        static void Main()
        {
            Manager m1 = new Manager();

            // Derived class property.
            m1.Name = "John";

            // Base class property.
            ((Employee)m1).Name = "Mary";

            System.Console.WriteLine("Name in the derived class is: {0}", m1.Name);
            System.Console.WriteLine("Name in the base class is: {0}", ((Employee)m1).Name);
        }
    }
    /* Output:
        Name in the derived class is: John, Manager
        Name in the base class is: Mary
    */
}
