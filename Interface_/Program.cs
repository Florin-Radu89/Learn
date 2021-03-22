using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_1
{
    interface IValue
    {
        void Render();
    }

    class Content : IValue
    {
        public void Render()
        {
            Console.WriteLine("Render content");
        }
    }

    class Image : IValue
    {
        public void Render()
        {
            Console.WriteLine("Render image");
        }
    }

    class Program
    {
        static void Main()
        {
            // Add three objects that implement the interface.
            var dictionary = new Dictionary<string, IValue>();
            dictionary.Add("cat1.png", new Image());
            dictionary.Add("image1.png", new Image());
            dictionary.Add("home.html", new Content());

            // Look up interface objects and call implementations.
            IValue value;
            if (dictionary.TryGetValue("cat1.png", out value))
            {
                value.Render(); // Image.Render
            }
            if (dictionary.TryGetValue("home.html", out value))
            {
                value.Render(); // Content.Render
            }
        }
    }

}
