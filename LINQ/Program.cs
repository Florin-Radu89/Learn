using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/var
    class Program
    {
        internal class Customer
        {
            public string Name { set; get; }
            public string City { get; set; }
            public string Phone { get; set; }
        }
        static void Main(string[] args)
        {
            // Example #1: var is optional when the select clause specifies a string
            string[] words = { "apple", "strawberry", "grape", "peach", "banana" };
            var wordQuery = from word in words
                            where word[0] == 'g'
                            select word;

            // Because each element in the sequence is a string, not an anonymous type, var is optional here also.
            //foreach (string s in wordQuery)
            foreach (var s in wordQuery)
                {
                Console.WriteLine(s);
            }

            Customer[] customers =
            {
                new Customer { City = "Phoenix", Phone ="0123", Name = "Customer from Phoenix"},
                new Customer { City = "two", Phone ="01235"},
            };

            List<Customer> custList = new List<Customer>()   
            {
                new Customer { City = "Phoenix", Phone ="0123", Name = "Customer from Phoenix"},
                new Customer { City = "two", Phone ="01235"},
            };


            List<Customer> custList_1 = new List<Customer>
            {
                new Customer { City = "Phoenix", Phone ="0123", Name = "Customer from Phoenix"},
                new Customer { City = "two", Phone ="01235"},
            };


            // Example #2: var is required because the select clause specifies an anonymous type
            var custQuery = 
                            //from cust in customers
                            from cust in custList
                            where cust.City == "Phoenix"
                            select new { cust.Name, cust.Phone };

            // var must be used because each item in the sequence is an anonymous type
            foreach (var item in custQuery)
            {
                Console.WriteLine("Name={0}, Phone={1}", item.Name, item.Phone);
            }

            // Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };
            int[] scores_1 =  { 97, 92, 81, 60 };   // alternative syntax for initialization

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            var scoreQuery_1 =
                from score in scores
                where score > 80
                select score;

            // Execute the query.
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }
        }
    }
}
