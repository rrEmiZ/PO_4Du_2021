using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace PODuSl01
{

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


    class Program
    {
        static void Main(string[] args)
        {
            //Zadanie numer 1
            using (var sr = new StreamWriter("sample.txt", append: true)) {
                sr.WriteLine("W61955");
            }

            //Zadanie numer 2
            void readFromFile (string path) {
                using (var sr = new StreamReader(path))
                {
                    var line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }

            //Zadanie numer 3
            List<string> listOfNumbers = new List<string>();
            using (var sr = new StreamReader("pesels.txt"))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    listOfNumbers.Add(line);
                }

            }

            int womenCount = 0;
            int manCount = 0;

            void Counter(List<string> list)
            {
                foreach (string item in list) {
                    if (item[9] % 2 == 0) {
                        womenCount+=1;
                    }
                    else
                    {
                        manCount += 1;
                    }
                }

                Console.WriteLine("Mans: " + manCount);
                Console.WriteLine("Womans: " + womenCount);
            }


            //Zadanie numer 4
            List<Root> list;

            using (var sr = new StreamReader("db.json"))
            {
                var json = sr.ReadToEnd();

                list = JsonConvert.DeserializeObject<List<Root>>(json);
            }

            void UserChecks(string Country, string StartYear, string EndYear)
            {
                int PopulationInStartYear = 0;
                int PopulationInEndYear = 0;
                foreach(var item in list)
                {
                    if(item.country.value == Country && item.date == StartYear)
                    {
                        PopulationInStartYear = Int32.Parse(item.value);
                    }
                    if (item.country.value == Country && item.date == EndYear)
                    {
                        PopulationInEndYear = Int32.Parse(item.value);
                    }
                }
                int result = PopulationInStartYear - PopulationInEndYear;

                Console.WriteLine("Różnica w populacji pomiędzy rokiem " +
                    StartYear + " a " + EndYear + " w " + Country + 
                    " wynosi: " + result);
            }

            void UserChecksSingleValue(string Country, string Year)
            {
                int Population = 0;
                foreach (var item in list)
                {
                    if (item.country.value == Country && item.date == Year)
                    {
                        Population = Int32.Parse(item.value);
                    }
                }
                Console.WriteLine("Populacja " + Country + " w roku " + Year + " wynosi: " + Population);
            }

            //a) 
            UserChecks("India", "1970", "2000");
            //b)
            UserChecks("United States", "1965", "2010");
            //c)
            UserChecks("China", "1980", "2018");
            //d)
            UserChecksSingleValue("India", "1980");

            //e)
            void UserChecksRange(string Country, string StartYear, string EndYear)
            {
                IEnumerable<int> Years = Enumerable.Range(Int32.Parse(EndYear), (Int32.Parse(StartYear) - Int32.Parse(EndYear))).Select(x => x);
                List<int> Populations = new List<int>();

                foreach(var item in Years)
                {
                    Console.WriteLine(item);
                }

                for(int i = 0; i < Years.Count(); i++)
                {
                    foreach (var item in list)
                    {
                      int[] tab = Years.ToArray();
                      if(item.country.value == Country && item.date == tab[i].ToString())
                      {
                            //Console.WriteLine(tab[i].ToString());
                            //Console.WriteLine(item.value);
                            Populations.Add(Int32.Parse(item.value));
                      }
                    }
                }

                int result = 0;

                foreach(int item in Populations)
                {
                    //Console.WriteLine(item);
                    //result += item;
                    //Console.WriteLine(result);
                }

                Console.WriteLine("Różncia dla podanego przedziału: " + StartYear +" - " + EndYear + " wynosi: " + result);
               
            }

           UserChecksRange("India", "2018", "2015");

            //f)
            void UserChecksPercentege(string Country, string StartYear)
            {
                int PopulationInYear = 0;
                int PopulationInPrevYear = 0;
                foreach (var item in list)
                {
                    if (item.country.value == Country && item.date == StartYear)
                    {
                        PopulationInYear = Int32.Parse(item.value);
                    }
                    if (item.country.value == Country && item.date == (Int32.Parse(StartYear) - 1).ToString())
                    {
                        PopulationInPrevYear = Int32.Parse(item.value);
                    }
                }
                int Difference = PopulationInYear - PopulationInPrevYear;

                double Percentage = (Convert.ToDouble(Difference) / Convert.ToDouble(PopulationInPrevYear)*100);

                Console.WriteLine(Math.Round(Percentage, 2) + "%");
            }

            UserChecksPercentege("India", "2018");

            //Zad 5
            FilePersonRepository obj = new FilePersonRepository();

            //Inicjalizacja listy znajdującej się w klasie FilePersonRepository 
            //z której reszta metod z klasy korzysta
            obj.GetAll();

            //użycie metody CountPersonOverYrs z atrybutem 1992, 
            //zwróci ilość osób które urodziły się w tym konkretnym roku
            Console.WriteLine(obj.CountPersonOverYrs(1992));

            Console.ReadLine();

        }



    }
}
