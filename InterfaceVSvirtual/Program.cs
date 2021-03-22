using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceVSvirtual
{
    interface IInterfaceExample
    {
        void Y();
    }

    class ImplementsInterface : IInterfaceExample
    {
        public void Y()
        {
        }
    }

    class BaseExample
    {
        public virtual void Y()
        {
        }
    }

    class DerivesBase : BaseExample
    {
        public override void Y()
        {
        }
    }

    class Program
    {
        const int _max = 100000000;
        static void Main()
        {
            IInterfaceExample interface1 = new ImplementsInterface();
            BaseExample base1 = new DerivesBase();
            interface1.Y();
            base1.Y();

            // Version 1: call interface method.
            var s1 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                interface1.Y();
            }
            s1.Stop();
            // Version 2: call virtual method.
            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                base1.Y();
            }
            s2.Stop();
            Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000 * 1000) /
                _max).ToString("0.00 ns"));
            Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000 * 1000) /
                _max).ToString("0.00 ns"));
            Console.Read();
        }
    }

}
