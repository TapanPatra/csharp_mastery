using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    [TestFixture]
    internal class HowToCallRestApiInCsharp
    {
        [Test]
        public async Task GetGithubProjects()
        {
            using (var client = new HttpClient() { BaseAddress = new Uri("https://api.github.com")})
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Productive C#");
                var response = await client.GetAsync("orgs/microsoft/repos");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine((int) response.StatusCode);
                    var json = JsonConvert.DeserializeObject(content);
                    Console.WriteLine(json);
                }

            }
        }

    }
}
