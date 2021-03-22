using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Override
{
    // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/override
    /// <summary>
    /// The override modifier is required to extend or modify the abstract or virtual implementation of an inherited method, property, indexer, or event.
    /// An override method provides a new implementation of a member that is inherited from a base class. The method that is overridden by an override declaration is known as the overridden base method. The overridden base method must have the same signature as the override method.
    /// You cannot override a non-virtual or static method. The overridden base method must be virtual, abstract, or override.
    /// </summary>
    abstract class Shape
    {
        public abstract int GetArea();
        //public  int GetArea();  //must declare a body
    }

    class Square : Shape
    {
        int side;

        public Square(int n) => side = n;

        // GetArea method is required to avoid a compile-time error: must implement inherited abstract member
        public override int GetArea() => side * side;

        static void Main()
        {
            var sq = new Square(12);
            Console.WriteLine($"Area of the square = {sq.GetArea()}");
        }
    }
    // Output: Area of the square = 144
}
