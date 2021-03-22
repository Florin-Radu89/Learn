using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Interview
{
    class LanguageGuidelines
    {
        // First, in class Program, define the delegate type and a method that has a matching signature.
        // Define the type.
        public delegate void Del(string message);
        // Define a method that has a matching signature.

        public static void DelMethod(string str)
        {
            Console.WriteLine("DelMethod argument: {0}", str);
        }
        public void methodName()
        {
            // Use string interpolation to concatenate short strings, as shown in the following code.
            Name[] nameList = new Name[6];
            Name name = new Name { FirstName = "FN1", LastName = "LN1" };
            nameList[0] = name;
            string displayName = $"{nameList[0].LastName}, {nameList[0].FirstName}";
            Console.WriteLine(displayName);

            //To append strings in loops, especially when you are working with large amounts of text, use a StringBuilder object.
            var phrase = "lalalalalalalalalalalalalalalalalalalalalalalalalalalalalala";
            var manyPhrases = new StringBuilder();
            for (var i = 0; i < 10000; i++)
            {
                manyPhrases.Append(phrase);
            }
            Console.WriteLine("tra" + manyPhrases);

            // When the type of a variable is clear from the context, use var in the declaration. Implicit typing
            var var1 = "This is clearly a string.";
            var var2 = 27;

            // When the type of a variable is not clear from the context, use an explicit type. You generally don't assume the type clear from a method name.
            // A variable type is considered clear if it's a new operator or an explicit cast.
            int var3 = Convert.ToInt32(Console.ReadLine());
            //int var4 = ExampleClass.ResultSoFar();

            IEnumerable<char> laugh = null;
            // Do not use implicit typing to determine the type of the loop variable in foreach loops.
            // The following example uses explicit typing in a foreach statement.
            foreach (char ch in laugh)
            {
                if (ch == 'h')
                    Console.Write("H");
                else
                    Console.Write(ch);
            }

            // Use the concise syntax when you initialize arrays on the declaration line.
            // Preferred syntax. Note that you cannot use var here instead of string[].
            string[] vowels1 = { "a", "e", "i", "o", "u" };
            // If you use explicit instantiation, you can use var.
            var vowels2 = new string[] { "a", "e", "i", "o", "u" };
            // If you specify an array size, you must initialize the elements one at a time.
            var vowels3 = new string[5];
            vowels3[0] = "a";
            vowels3[1] = "e";
            // And so on.

            // Use the concise syntax to create instances of a delegate type.
            // In the Main method, create an instance of Del.
            // Preferred: Create an instance of Del by using condensed syntax.
            Del exampleDel2 = DelMethod;
            // The following declaration uses the full syntax.
            Del exampleDel1 = new Del(DelMethod);

            // Simplify your code by using the C# using statement. If you have a try-finally statement in which the only code in the finally block is a call to the Dispose method, use a using statement instead.
            // This try-finally statement only calls Dispose in the finally block.
            System.Drawing.Font font1 = new Font("Arial", 10.0f);
            try
            {
                byte charset = font1.GdiCharSet;
            }
            finally
            {
                if (font1 != null)
                {
                    ((IDisposable)font1).Dispose();
                }
            }
            // You can do the same thing with a using statement.
            using (Font font2 = new Font("Arial", 10.0f))
            {
                byte charset = font2.GdiCharSet;
            }

            // Use the concise form of object instantiation, with implicit typing, as shown in the following declaration.
            var instance1 = new ExampleClass();
            // The previous line is equivalent to the following declaration.
            ExampleClass instance2 = new ExampleClass();

            // Use object initializers to simplify object creation.
            // Object initializer.
            var instance3 = new ExampleClass
            {
                Name = "Desktop",
                ID = 37414,
                Location = "Redmond",
                Age = 2.3
            };
            // Default constructor and assignment statements.
            var instance4 = new ExampleClass();
            instance4.Name = "Desktop";
            instance4.ID = 37414;
            instance4.Location = "Redmond";
            instance4.Age = 2.3;


        }

        // If you are defining an event handler that you do not need to remove later, use a lambda expression.
        public Form2()
        {
            // You can use a lambda expression to define an event handler.
            this.Click += (s, e) =>
            {
                MessageBox.Show(
                    ((MouseEventArgs)e).Location.ToString());
            };
        }

        // Use a try-catch statement for most exception handling.
        static string GetValueFromArray(string[] array, int index)
        {
            try
            {
                return array[index];
            }
            catch (System.IndexOutOfRangeException ex)
            {
                Console.WriteLine("Index is out of range: {0}", index);
                throw;
            }
        }

        #region Misc
        //string[] nameList = new string[]
        //{
        //    "First", "Second", "Third"
        //};

        //public string DisplayName { get => displayName; set => displayName = value; }

        #endregion
    }


struct Name {
        internal string LastName;
        internal string FirstName;
    }
}
