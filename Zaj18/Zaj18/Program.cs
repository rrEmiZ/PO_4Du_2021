using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Zaj18.ApiCovid;

namespace Zaj18
{
    class Program
    {
        public static async Task ShowDataAsync(string? countyName, string? countyCode)
        {
            var service = new RequestService();
            try
            {
                var lista = await service.GetAsync<Root>("https://api.covid19api.com/summary");
                var typedCuntyList = lista.Countries.Where(c => c.Country == countyName || c.CountryCode == countyCode);

                foreach (var item in typedCuntyList)
                {
                    Console.WriteLine($"\n{item.Country}\n{item.CountryCode}\nSlug:{item.Slug}\nTotalConfirmed:{item.TotalConfirmed}\nTotalDeaths:{item.TotalDeaths}\nTotalRecovered:{item.TotalRecovered}\nDate:{item.Date}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static async Task Main(string[] args)
        {
            //wyświetlenia statystyk Covid19 dla podanej nazwy
            Task task = ShowDataAsync(null, "PL");
            Task task1 = ShowDataAsync("Italy", null);

            var service = new RequestService();
            try
            {
                //var client = new HttpClient();
                //HttpResponseMessage response = await client.GetAsync("https://api.covid19api.com/summary");

                //if (response.IsSuccessStatusCode)
                //{
                //    var lista = JsonConvert.DeserializeObject<Root>(await response.Content.ReadAsStringAsync());

                //    Console.WriteLine($"{lista.ID} - {lista.Message} - {lista.Date} ");
                //    //Wyświetli Globalne dane o przypadkach Covid19
                //    Console.WriteLine($"Global : {lista.Global.TotalConfirmed} - {lista.Global.TotalDeaths} - {lista.Global.TotalRecovered} \n");

                //    //Wszystkie dane
                //    //foreach (var item in lista.Countries)
                //    //{
                //    //    Console.WriteLine($"{item.Country} - {item.TotalConfirmed} - {item.TotalDeaths} - {item.TotalRecovered} ");
                //    //}

                //}

                var lista = await service.GetAsync<Root>("https://api.covid19api.com/summary");
                Console.WriteLine($"{lista.ID} - {lista.Message} - {lista.Date} ");
                //Wyświetli Globalne dane o przypadkach Covid19
                Console.WriteLine($"Global : {lista.Global.TotalConfirmed} - {lista.Global.TotalDeaths} - {lista.Global.TotalRecovered} \n");
                //Wszystkie dane
                foreach (var item in lista.Countries)
                {
                    Console.WriteLine($"{item.Country} - {item.TotalConfirmed} - {item.TotalDeaths} - {item.TotalRecovered} ");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
