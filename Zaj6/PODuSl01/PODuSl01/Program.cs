
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

    


    class Program
    {
        static void Main(string[] args)
        {
            /* List<Root> list;

             //Otwieramy stream pliku sample.txt
             */

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



            // zad 1 ---------------------------
            var Zadanie1 = new Zad1();
            Zadanie1.zapiszAlbum();
            Zadanie1.WypiszAlbum();
            Console.WriteLine();

            // zad 2 ---------------------------
            var Zadanie2 = new Zad2();
            Zadanie2.WypiszPlik("sample.txt");
            Console.WriteLine();

            // zad 3 ---------------------------
            var Zadanie3 = new Zad3();
            Zadanie3.IleKobiet("pesels.txt");
            Console.WriteLine();

            // zad 4 ---------------------------
            var Zadanie4 = new Zad4();
            Zadanie4.DoListy("db.json");
            Zadanie4.Zad4A();
            Zadanie4.Zad4B();
            Zadanie4.Zad4C();
            //Zad4D
            Zadanie4.WyswietlPopulacje("2000", "United States");
            //Zad4E
            Zadanie4.PorownajPopulacje("1960", "1970", "United States");
            //Zad4F
            Zadanie4.ProcWzorst("2000");
            Console.WriteLine();
            // zad 5 ---------------------------
            Person Person1 = new Person { Id = 1, FirstName = "Kamil", LastName = "Ślimak", Pesel = "98010843214" };
            Person Person2 = new Person { Id = 2, FirstName = "Zenon", LastName = "Bury", Pesel = "00241474798" };
            Person Person3 = new Person { Id = 3, FirstName = "Kunegunda", LastName = "Kowalski", Pesel = "053018171464" };
            Person Person4 = new Person { Id = 4, FirstName = "Marcin", LastName = "Krasucki", Pesel = "92062886753" };
            FilePersonRepository Przyklad = new FilePersonRepository();

            Przyklad.RemoveAll();
            Przyklad.Add(Person1);
            Przyklad.Add(Person2);
            Przyklad.Add(Person3);
            Przyklad.Add(Person4);
            Przyklad.ConsoleWriteAll();
            Console.WriteLine(Przyklad.CountPersonOverYrs(2000));
            Console.WriteLine(Przyklad.CountPersonOverYrs(1990));
            Console.WriteLine();
            Przyklad.Remove(2);
            Przyklad.ConsoleWriteAll();
            Console.WriteLine();
            Person4.FirstName = "Marek";
            Person4.LastName = "Mostowiak";
            Przyklad.Update(Person4);
            Przyklad.ConsoleWriteAll();
            Console.WriteLine();
            Console.WriteLine(Przyklad.CountPersonOverYrs(2000));
            Console.WriteLine(Przyklad.CountPersonOverYrs(1990));
        }



    }
}
