using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _3_Http_Client
{
    internal class Program
    {
        private static HttpClient _httpClient = new HttpClient();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            GetPage();
            Initialise();


            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }

        private static async void Initialise()
        {
            var result = await GetFromWikipediaAsync("청정실");
            Console.WriteLine(result);
        }


        private async static void GetPage()
        {
            var text = await _httpClient.GetStringAsync(@"http://www.bing.com/");
            Console.WriteLine(text);
        }

        private static async Task<string> GetFromWikipediaAsync(string keyword)
        {
            var builder = new UriBuilder("https://ko.widipedia.org/w/api.php");
            var content = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                ["action"] = "query",
                ["prop"] = "revisions",
                ["rvprop"] = "content",
                ["format"] = "xml",
                ["titles"] = "keyword",
            });

            builder.Query = await content.ReadAsStringAsync();

            var str = await _httpClient.GetStringAsync(builder.Uri);

            var xmldoc = XDocument.Parse(str);
            var rev = xmldoc.Root.Descendants("rev").FirstOrDefault();
            return WebUtility.HtmlDecode(rev?.Value);
        }
    }
}
