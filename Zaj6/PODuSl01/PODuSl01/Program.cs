
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
