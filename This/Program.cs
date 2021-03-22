using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace This
{
    class Program
    {
        static void Main(string[] args)
        {
            Book csharpBook = new Book("Mahesh Chand", "C# 8 Programming", "Microsoft",
            new DateTime(2019, 7, 10), 49.95m);
            decimal price = csharpBook.CalculateSalePrice();
            Console.WriteLine($"Author {csharpBook.Author}");
            Console.WriteLine($"Title {csharpBook.Title}");
            Console.WriteLine($"Publisher {csharpBook.Publisher}");
            Console.WriteLine($"PublishedOn {csharpBook.PublishedOn}");
            Console.WriteLine($"Book price is {price} ");
            Console.ReadKey();
        }
    }
    public class Book
    {
        private string author;
        private string title;
        private string publisher;
        private DateTime publishedOn;
        private decimal price;
        public Book(string author, string title, string publisher,
        DateTime pubdate, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Publisher = publisher;
            this.PublishedOn = pubdate;
            this.Price = price;
        }
        public string Author { get => author; set => author = value; }
        public string Title { get => title; set => title = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public DateTime PublishedOn { get => publishedOn; set => publishedOn = value; }
        public decimal Price { get => price; set => price = value; }
        public decimal CalculateSalePrice()
        {
            return (this.Price + BookPrice.FinalPrice(this));
        }
    }
    public class BookPrice
    {
        public static decimal FinalPrice(Book book)
        {
            return book.Price * 0.06m;
        }
    }
}
