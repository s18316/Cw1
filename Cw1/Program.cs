using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
       public static async Task Main(string[] args)
        {
            // int tmp1 = 1;
            // string tmp2 = "Ala ma kota";
            // string tmp4 = " i psa";
            // bool tmp3 = true;
            // int tmp5 = 5;
            // Console.WriteLine($"{tmp2} {tmp4} { tmp1+tmp5}");


            // string path = @"C:\Users\s18316\Desktop\Cw1";

            // var tmp6 = true;

            // var newPerson = new Person { FirstName = "Daniel" };
            //Console.WriteLine("Hello World!");



            var url = "https://www.pja.edu.pl";
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            //2xx
            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+",RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                foreach (var match in matches)
                {

                    Console.WriteLine(match.ToString());
                }

            }
        }
    }
}
