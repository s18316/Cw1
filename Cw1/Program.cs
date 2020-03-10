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

            if (args.Length < 1) throw new ArgumentNullException(); 
//            

            var response = await httpClient.GetAsync(url);

            //2xx
            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                int czyPojawilosie = 0;

                string[] tab = new string[10];
                int ktoryStr = 0;

                foreach (var match in matches)
                {
                    int powtorzenie = 0;
                    for (int i = 0; i < tab.Length; i++)
                    {
                        if (tab[i].Equals(match)) powtorzenie++;
                    }
                    
                    if(powtorzenie != 0)  tab[ktoryStr++] = match.ToString();
                    
                   // Console.WriteLine(match.ToString());
                    czyPojawilosie++;
                }
                for (int i = 0; i < ktoryStr; i++)
                {
                    Console.WriteLine(tab[i]);
                }


                if (czyPojawilosie == 0) throw new Exception("nie znaleziono adresow email");

                httpClient.Dispose();

            }
            else throw new Exception("Błąd w trakcie pobierania strony");
            

        }
    }
}
