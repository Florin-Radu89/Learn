using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods
    class Program
    {
        abstract class Motorcycle
        {
            // Anyone can call this.
            public void StartEngine() {/* Method statements here */ }

            // Only derived classes can call this.
            protected void AddGas(int gallons) { /* Method statements here */ }

            // Derived classes can override the base class implementation.
            public virtual int Drive(int miles, int speed) { /* Method statements here */ return 1; }

            // Derived classes must implement this.
            public abstract double GetTopSpeed();

            //TODO: error: 'Program.Motorcycle.GetTopSpeed1()' cannot be sealed because it is not an override 
            //public sealed double GetTopSpeed1() { /* Method statements here */ return 1d; }
        }

        class TestMotorcycle : Motorcycle
        {

            public override double GetTopSpeed()
            {
                return 108.4;
            }

            static void Main()
            {

                TestMotorcycle moto = new TestMotorcycle();

                moto.StartEngine();
                moto.AddGas(15);
                moto.Drive(5, 20);
                double speed = moto.GetTopSpeed();
                Console.WriteLine("My top speed is {0}", speed);
            }
        }

    }
}
