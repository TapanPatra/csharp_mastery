using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.Fundamentals.Async
{
    [TestFixture]
    public class AsyncAwait
    {
        public string GetHtml(string url)
        {
            var webClient = new WebClient();
            return webClient.DownloadString(url);
        }

        public async Task<string> GetHtmlAync(string url)
        {
            var webClient = new WebClient();
            Console.WriteLine("Executing Task");
            return await webClient.DownloadStringTaskAsync(url);
        }

        [Test]
        public void SynchonousTest()
        {
            var str = GetHtml("https://learn.microsoft.com/en-us/");
            Console.WriteLine(str.Substring(0, 10));
        }

        [Test]
        public async Task AsynchronousTest()
        {
            var getHtmlTask = GetHtmlAync("https://learn.microsoft.com/en-us/");
            Console.WriteLine("Waiting for Task to complete");
            Console.WriteLine("Waiting for Task to complete");
            Console.WriteLine("Waiting for Task to complete");

            var html = await getHtmlTask;
            Console.WriteLine(html.Substring(0, 10));
            Console.WriteLine("Task Completed");

        }

    }
}
