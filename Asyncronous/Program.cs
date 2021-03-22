using System;
using System.Threading.Tasks;

namespace Asyncronous
{
    class Program
    {
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/task-asynchronous-programming-model
        public async Task<int> GetUrlContentLengthAsync()
        {
            var client = new System.Net.Http.HttpClient();
            Task<string> getStringTask = client.GetStringAsync("https://docs.microsoft.com/dotnet");
            DoIndependentWork();    // work that it can do between calling GetStringAsync and awaiting its completion

            string contents = await getStringTask;
            //If GetUrlContentLengthAsync doesn't have any work that it can do between calling GetStringAsync and awaiting its completion, you can simplify your code by calling and awaiting in the following single statement.
            contents = await client.GetStringAsync("https://docs.microsoft.com/dotnet");

            var x = System.ConsoleKey.A;

            return contents.Length;
        }
        void DoIndependentWork()
        {
            Console.WriteLine("Working...");
        }
        static void Main(string[] args)
        {

        }
    }
}
