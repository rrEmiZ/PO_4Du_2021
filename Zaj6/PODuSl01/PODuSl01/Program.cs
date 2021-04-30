
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace PODuSl01
{
    public class Fruit
    {
        [JsonProperty(PropertyName ="fruit")]
        public string Type { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }

    public class Indicator
    {
        public string id { get; set; }
        public string value { get; set; }
    }

    public class Country
    {
        public string id { get; set; }
        public string value { get; set; }
    }

    public class Root
    {
        public Indicator indicator { get; set; }
        public Country country { get; set; }
        public string value { get; set; }
        public string @decimal { get; set; }
        public string date { get; set; }
    }

    public class Zad4
    {
        List<Root> list;
        public Zad4()
        {
            list = JsonConvert.DeserializeObject<List<Root>>(Program.Zad2(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\") + "db.json"));
        }
        public void Zad4_()
        {
            Console.WriteLine("India population difference 1970-2000: " + PopDiff("IN", "1970", "2000"));
            Console.WriteLine("USA population difference 1965-2010: " + PopDiff("IN", "1965", "2010"));
            Console.WriteLine("China population difference 1980-2018: " + PopDiff("IN", "1980", "2018"));
        }
        public void Zad4_(int year)
        {
            foreach(var country in GetCountries())
            {
                var prc = ((double)GetPop(year.ToString(), country.id) / GetPop((year - 1).ToString(), country.id) * 100) - 100;
                Console.WriteLine($"{country.value} population difference percentage {year - 1}-{year}: {prc}");
            }
        }

        public List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();
            foreach(var root in list)
            {
                if (countries.Any(p => p.id == root.country.id)) continue;
                else countries.Add(root.country);
            }
            return countries;
        }
        public int GetPop(string year, string countryId)
        {
            return int.Parse(list.Where(c => c.country.id == countryId && c.date == year).First().value);
        }
        public int PopDiff(string countryId, string year1, string year2)
        {
            return GetPop(year2, countryId) - GetPop(year1, countryId);
        }
    }

    class Program
    {
        static void Main()
        {
            Zad1("NazwaPliku");
            Console.Write(Zad2("NazwaPliku.txt"));
            Zad3();

            Zad4 zad4 = new Zad4();
            zad4.Zad4_();
            zad4.Zad4_(2016);

            FilePersonRepository zad5 = new FilePersonRepository();
            zad5.Add(new Person
            {
                Id = 1,
                FirstName = "Janusz",
                LastName = "Kowalski",
                Pesel = "48052441471"
            });
            zad5.Add(new Person
            {
                Id = 2,
                FirstName = "Grażyna",
                LastName = "Kowalska",
                Pesel = "55552441421"
            });
            zad5.Update(new Person
            {
                Id = 3,
                FirstName = "Grażyna",
                LastName= "Nowak",
                Pesel = "55552441421"
            });
            Console.WriteLine($"Ilość osób urodzonych po roku 1800: {zad5.CountPersonOverYrs(1800)}");
            zad5.Remove(1);
            Console.WriteLine($"Ilość osób urodzonych po roku 1800: {zad5.CountPersonOverYrs(1800)}");

            Console.ReadLine();
        }

        static void Zad1(string path)
        {
            using (var sw = new StreamWriter($"{ path }.txt"))
            {
                sw.WriteLine("w61906");
            }
        }

        public static string Zad2(string path)
        {
            var sr = new StreamReader(path);
            var text = sr.ReadToEnd();
            sr.Close();
            return text;
        }

        static void Zad3()
        {
            int f = 0, m = 0;
            var data = Zad2(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\") + "pesels.txt");
            using (StringReader sr = new StringReader(data))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    if ((int)line[9] % 2 == 0) f++;
                    else m++;
                }
            }
            Console.WriteLine($"Mężczyzn: {m}\nKobiet:{f}");
        }
    }
}
