using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    class Author
    {

        public string Name
        {
            get;  set;
        }
        public string Publisher
        {
            get;
            set;
        }
        public string Book
        {
            get;
            set;
        }
        public Int16 Year
        {
            get;
            set;
        }
        public double Price
        {
            get;
            set;
        }
        public string PriceInString
        {
            get
            {
                return string.Format("${0}", Price);
            }
        }

        public string Names
        {
            get;
        }

        public double AuthorCount
        {
            get;
            private set;
        } = 99;

        public Author(string name, string publisher, string book, Int16 year, double price)
        {
            Name = name;
            Publisher = publisher;
            Book = book;
            Year = year;
            Price = price;
            //AuthorCount = 150;  //new
        }

        public string AuthorDetails()
        {
            return string.Format("{0} is an author of {1} published by {2} in year {3}. Price: ${4}", Name, Book, Publisher, Year, Price);
        }
        public double CostOfThousandBooks()
        {
            if (Price > 0) return Price * 1000;
            return 0;
        }
    }

    //The code in Listing is creates an instance of the class and calls its methods and properties.

    class Program
    {
        static void Main()
        {
            Author author = new Author("Mahesh Chand", "Apress", "Programming C#", 2003, 49.95);
            Console.WriteLine(author.AuthorDetails());
            Console.WriteLine("Author published his book in {0}", author.Year);
            author.Price = 50;
            Console.WriteLine(author.CostOfThousandBooks().ToString());
            Console.WriteLine("count = {0}", author.AuthorCount);
            //author.AuthorCount = 55;  //err The property or indexer 'Author.AuthorCount' cannot be used in this context because the set accessor is inaccessible 

            Console.WriteLine($"PrinceinString={author.PriceInString}");
            Console.ReadKey();
        }
    }
}
