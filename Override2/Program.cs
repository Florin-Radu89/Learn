using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Override2
{
    //https://stackoverflow.com/questions/3838553/overriding-vs-method-hiding
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass isReallyBase = new BaseClass();
            BaseClass isReallyDerived = new DerivedClass();
            DerivedClass isClearlyDerived = new DerivedClass();

            isReallyBase.WriteNum(); // writes 12
            isReallyBase.WriteStr(); // writes abc
            isReallyDerived.WriteNum(); // writes 12: WriteNum is hidden because is not declared as virtual; so BaseClass functionality is used
            isReallyDerived.WriteStr(); // writes xyz: WriteStr is overriden because is declared virtual in BaseClass; so the most derived version of the method is called
            isClearlyDerived.WriteNum(); // writes 42
            isClearlyDerived.WriteStr(); // writes xyz
        }
    }

    public class BaseClass
    {
        public void WriteNum()
        {
            Console.WriteLine(12);
        }
        public virtual void WriteStr()
        {
            Console.WriteLine("abc");
        }
    }

    public class DerivedClass : BaseClass
    {
        public new void WriteNum()
        {
            Console.WriteLine(42);
        }
        public override void WriteStr()
        {
            Console.WriteLine("xyz");
        }
    }
}
