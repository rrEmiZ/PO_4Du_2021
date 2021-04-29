
using System;
using System.Collections.Generic;
using System.IO;
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

            

            // zad 1
            var Zadanie1 = new Zad1();
            Zadanie1.zapiszAlbum();
            Zadanie1.WypiszAlbum();

            // zad 2
            var Zadanie2 = new Zad2();
            Zadanie2.WypiszPlik("sample.txt");

            // zad 3
            var Zadanie3 = new Zad3();
            Zadanie3.IleKobiet("pesels.txt");            
            
        }



    }
}
