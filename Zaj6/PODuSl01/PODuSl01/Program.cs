
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

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

    public class FilesService
    {
        public static bool SaveData(string data, string fileName)
        {
            try
            {
                using (var sw = new StreamWriter(fileName))
                {
                    sw.WriteLine(data);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public static string ReadData(string fileName)
        {
            try
            {
                using (var sr = new StreamReader(fileName))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                return "Coś poszło nie tak";
            }
        }

    }


    public interface IReppository<T>
    {
        public List<T> GetAll();
    }

    public class RootRepository: IReppository<Root>
    {
        List<Root> objects;
        public RootRepository()
        {

            using (var sr = new StreamReader("db.json"))
            {
                var json = sr.ReadToEnd();

                objects = JsonConvert.DeserializeObject<List<Root>>(json);
            }
        }

        public List<Root> GetAll()
        {
            return objects;
        }

        public Root? FindOneByYearAndCountryName(string year, string country)
        {
            foreach(Root r in objects)
            {
                if (r.date == year && r.country.value == country)
                {
                    return r;
                }
            }
            return null;
        }
    }

    public class RootService
    {
        RootRepository rootRepository;

        public RootService()
        {
            rootRepository = new RootRepository();
        }

        public int GetPopulationDifference(string countryName, string fromDate, string toDate)
        {
            return GetPopulationByYearAndCountry(countryName, toDate) - GetPopulationByYearAndCountry(countryName, fromDate);
        }

        public int GetPopulationByYearAndCountry(string countryName, string date)
        {
            Root root = rootRepository.FindOneByYearAndCountryName(date, countryName);
            if (root == null)
            {
                throw new InvalidDataException("Nie znaleziono danych");
            }
            return Int32.Parse(root.value);
        }

        public double GetPercentagePopulationDifference(string countryName, string date)
        {
            int populationTo = GetPopulationByYearAndCountry(countryName, date);

            string fromDate = (Int32.Parse(date) - 1).ToString();
            int populationFrom = GetPopulationByYearAndCountry(countryName, fromDate);

            return ((populationTo - populationFrom) / Convert.ToDouble(populationFrom)) * 100;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            List<Root> list;

            //Otwieramy stream pliku sample.txt
            using (var sr = new StreamReader("db.json"))
            {
                var json = sr.ReadToEnd();

                list = JsonConvert.DeserializeObject<List<Root>>(json);
            }

            //sc.Add(new Fruit()
            //{
            //    Type = "Banana",
            //    Color = "Yellow",
            //    Size = "Medium"
            //});

            //using (var sw = new StreamWriter("sample.json"))
            //{
            //    var json = JsonConvert.SerializeObject(sc);

            //    sw.WriteLine(json);                
            //}

            //------------------------
            string studentNumber = GetValidString("numer albumu", 6);
            string fileName = GetValidString("nazwę pliku", 1);

            if (FilesService.SaveData(studentNumber, fileName))
            {
                Console.WriteLine("Dane zostały zapisane");
            } else
            {
                Console.WriteLine("Coś poszło nie tak :(");
            }


            Console.WriteLine("WCZYTYWANIE DANYCH Z PLIKU:");
            fileName = GetValidString("nazwę pliku", 1);
            string fileContent = FilesService.ReadData(fileName);
            Console.WriteLine("Zawartość pliku:");
            Console.WriteLine(fileContent);



            Console.WriteLine("Liczba kobiet w pliku pesels.txt:");
            string pesels = FilesService.ReadData("pesels.txt");
            int femalesNum = 0;

            using(var sr = new StringReader(pesels))
            {
                string pesel;
                while ((pesel = sr.ReadLine()) != null)
                {
                    if (Int32.Parse(pesel[9].ToString()) % 2 == 0)
                    {
                        femalesNum += 1;
                    }
                }
            }
            Console.WriteLine($"Liczba kobiet w pliku wynosi: {femalesNum}");


            //------------ZAD4----------------
            var rootService = new RootService();
            try
            {
                Console.WriteLine("Różnica populacji w Indiach między rokiem 1970 i 2000:");
                Console.WriteLine(rootService.GetPopulationDifference("India", "1970", "2000"));
            } 
            catch (Exception e)
            {
                Console.WriteLine($"Wystąpił błąd: {e.Message}");
            }

            try
            {
                Console.WriteLine("Różnica populacji w USA między rokiem 1965 i 2010:");
                Console.WriteLine(rootService.GetPopulationDifference("United States", "1965", "2010"));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Wystąpił błąd: {e.Message}");
            }

            try
            {
                Console.WriteLine("Różnica populacji w Chianch między rokiem 1980 i 2018:");
                Console.WriteLine(rootService.GetPopulationDifference("China", "1980", "2018"));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Wystąpił błąd: {e.Message}");
            }

            try
            {
                Console.WriteLine("Podaj nazwę kraju:");
                string country = Console.ReadLine();

                Console.WriteLine("Podaj datę 1:");
                string dateFrom = Console.ReadLine();

                Console.WriteLine("Podaj datę 2:");
                string dateTo = Console.ReadLine();


                Console.WriteLine("Różnica populacji dal wybranego kraju: " + rootService.GetPopulationDifference(country, dateFrom, dateTo));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Wystąpił błąd: {e.Message}");
            }

            try
            {
                Console.WriteLine("Wstrost procentowy populacji w Indiach w roku 1993:");
                Console.WriteLine(rootService.GetPercentagePopulationDifference("India", "1993") + "%");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Wystąpił błąd: {e.Message}");
            }


            Console.ReadLine();

        }

        static string GetValidString(string varName, uint numOfChars)
        {
            string value;
            Console.WriteLine("Podaj {0}:", varName);

            while (true)
            {
                value= Console.ReadLine().ToString();
                if (value.Length >= numOfChars)
                {
                    return value;
                }
                Console.WriteLine("Nieprawidłowa wartość. Podaj poprawne dane:");
            }
        }


    }
}
