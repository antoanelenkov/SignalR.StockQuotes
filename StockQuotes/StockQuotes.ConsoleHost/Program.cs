namespace StockQuotes.ConsoleHost
{
    using Microsoft.Owin.Hosting;
    using System;

    public class Program
    {
        public static void Main()
        {
            string url = "http://localhost:8080";

            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
}
