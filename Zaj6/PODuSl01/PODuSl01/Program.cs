
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
            string studentNumber = getValidString("numer albumu", 6);
            string fileName = getValidString("nazwę pliku", 1);


            Console.ReadLine();

        }

        static string getValidString(string varName, uint numOfChars)
        {
            string value;
            Console.WriteLine("Podaj {0}:", varName);

            while (true)
            {
                value= Console.ReadLine().ToString();
                if (value.Length >= numOfChars && Regex.IsMatch(value, "^[a-zA-Z0-9]*$"))
                {
                    return value;
                }
                Console.WriteLine("Nieprawidłowa wartość. Podaj poprawne dane:");
            }
        }


    }
}
