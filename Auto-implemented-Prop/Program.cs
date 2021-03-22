using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_implemented_Prop
{
    // The following example shows how a property with only get accessor differs than one with get and private set.
    class Contact
    {
        public string Name { get; }     // can only be set in constructor
        public string Address { get; private set; }

        public Contact(string contactName, string contactAddress)
        {
            // Both properties are accessible in the constructor.
            Name = contactName;
            Address = contactAddress;
        }

        // Name isn't assignable here. This will generate a compile error.
        //public void ChangeName(string newName) => Name = newName;

        // Address is assignable here.
        public void ChangeAddress(string newAddress) => Address = newAddress;

        static void Main() { }

    }
}
