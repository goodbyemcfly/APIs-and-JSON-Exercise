using static System.Net.WebRequestMethods;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 5; i++)
            {
                var client = new HttpClient();

                var kanyeURL = "https://api.kanye.rest/";

                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                Console.WriteLine($"Kanye: \"{kanyeQuote}\"");

                var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

                var ronResponse = client.GetStringAsync(ronURL).Result;

                var ronQuote = ronResponse.Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();

                Console.WriteLine($"Ron: \"{ronQuote}\"");

                Console.WriteLine();
            }
        }
    }
}
