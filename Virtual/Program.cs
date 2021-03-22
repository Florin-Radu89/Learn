using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual
    // The virtual keyword is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class. 
    class MyBaseClass
    {
        // virtual auto-implemented property. Overrides can only provide specialized behavior if they implement get and set accessors.
        public virtual string Name { get; set; }

        // ordinary virtual property with backing field
        private int num;
        public virtual int Number
        {
            get { return num; }
            set { num = value; }
        }
    }

    class MyDerivedClass : MyBaseClass
    {
        private string name;

        // Override auto-implemented property with ordinary property to provide specialized accessor behavior.
        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    name = "Unknown";
                }
            }
        }

        static void Main() { }
    }
}
