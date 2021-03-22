using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    // https://www.c-sharpcorner.com/UploadFile/mkagrahari/introduction-to-object-oriented-programming-concepts-in-C-Sharp/

    //Abstraction is "To represent the essential feature without representing the background details."
    //Abstraction is accomplished using an Interface. Just giving the abstract information about what it can do without specifying the details.
    #region Abstraction

    public abstract class MobilePhone
    {
        public void Calling() { }
        //public abstract void Calling();
        public abstract void SendSMS();
    }
    public class Nokia1400 : MobilePhone
    {
        public override void SendSMS() { }
    }
    //public class Nokia2700 : MobilePhone
    public class Nokia2700 : Nokia1400
    {
        public void FMRadio() { }
        public void MP3() { }
        public void Camera() { }
    }
    //public class BlackBerry : MobilePhone
    public class BlackBerry : Nokia2700
    {
        //public void FMRadio() { }
        //public void MP3() { }
        public new void Camera() { }    //hiding Camera() from inherited class, with new keyword
        public void Recording() { }
        public void ReadAndSendEmails() { }
    }
    #endregion Abstraction

    //Wrapping up a data member and a method together into a single unit (in other words class) is called Encapsulation.
    //Encapsulation is accomplished using classes. Keeping data and methods that access that data into a single unit.
    #region Encapsulation
    class Demo
    {
        private int _mark;
        public int Mark
        {
            get
            {
                return _mark;
            }
            set
            {
                if (_mark > 0) _mark = value;
                else _mark = 0;
            }
        }
    }
    #endregion Encapsulation

    //When a class includes a property of another class it is known as inheritance. Inheritance is a process of object reusability.
    #region Inheritance
    public class ParentClass
    {
        public ParentClass()
        {
            Console.WriteLine("Parent Constructor.");
        }
        public void print()
        {
            Console.WriteLine("I'm a Parent Class.");
        }
    }
    public class ChildClass : ParentClass
    {
        public ChildClass()
        {
            Console.WriteLine("Child Constructor.");
        }
        public static void Main()
        {
            ChildClass child = new ChildClass();
            child.print();
        }
    }
    #endregion Inheritance

    //Polymorphism means one name, many forms. One function behaves in different forms.
    #region Polymorphism

    #endregion Polymorphism
}
