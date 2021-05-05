
using System;
using System.Collections.Generic;
using System.IO;
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
        public static void Zad1(string FileName)
        {
            
            using (var sw = new StreamWriter(FileName))
            {
                sw.WriteLine("w61957");
            }
        }
        public static string Zad2 (string Filename)
        {
            using (var sr = new StreamReader(Filename))
            {
                var line = sr.ReadToEnd();
                return line;
            }
        }
        public static void Zad3()
        {
            using (var sr = new StreamReader("pesels.txt"))
            {
                var line = sr.ReadLine();
                int counter=0;
                while (line != null)
                {
                    if ((int)line[9] % 2 == 0)
                    {
                        counter++;
                    }
                    line = sr.ReadLine();
                }
                Console.WriteLine("peselów należących do kobiet jest: " + counter);
            } 
        }
        public static void Zad4(string from, string to, string country)
        {
            List<Root> list;

            using (var sr = new StreamReader("db.json"))
            {
                var json = sr.ReadToEnd();

                list = JsonConvert.DeserializeObject<List<Root>>(json);
            }
            string firstPopulation="";
            string secondPopulation="";
            foreach(var info in list)
            {
                if (info.date == from && info.country.value == country)
                {
                    firstPopulation = info.value;
                }
                if (info.date == to && info.country.value == country)
                {
                    secondPopulation = info.value;
                }
            }

            int result = Int32.Parse(secondPopulation) - Int32.Parse(firstPopulation);
            Console.WriteLine("różnica populacji to: "+result);
        }
        public static void Zad4(string year, string country)
        {
            List<Root> list;

            using (var sr = new StreamReader("db.json"))
            {
                var json = sr.ReadToEnd();

                list = JsonConvert.DeserializeObject<List<Root>>(json);
            }
            string firstPopulation="";
            string secondPopulation="";
            int previousYear = Int32.Parse(year) - 1;
            string previousYearString = previousYear.ToString();
            foreach (var info in list)
            {
                if (info.date == previousYearString && info.country.value == country)
                {
                    firstPopulation = info.value;
                }
                if (info.date == year && info.country.value == country)
                {
                    secondPopulation = info.value;
                }
            }

            Double result = (Double.Parse(secondPopulation) - Double.Parse(firstPopulation))/Double.Parse(firstPopulation);
            result = Math.Round(result, 4);
            Console.WriteLine("wzrost populacji wzgledem poprzedniego roku to: "+result+'%');

        }
        static void Main(string[] args)
        {

            Zad1("test.txt");
            string test = Zad2("test.txt");
            Console.WriteLine(test);
            Zad3();
            Zad4("1970", "2000", "India");
            Zad4("1965", "2010", "United States");
            Zad4("1980", "2018", "China");
            Zad4("1980", "China");

            Person p1 = new Person
            {
                Id = 1,
                FirstName = "Roman",
                LastName = "Kowalski",
                Pesel = "99070103421"
            };
            Person p2 = new Person
            {
                Id = 2,
                FirstName = "Julian",
                LastName = "Kowalski",
                Pesel = "99070103432"
            };
            Person p3 = new Person
            {
                Id = 3,
                FirstName = "Adam",
                LastName = "Kowalski",
                Pesel = "99070103433"
            };
            Person p4 = new Person
            {
                Id = 3,
                FirstName = "Adam",
                LastName = "Kowalskitest",
                Pesel = "99070103433"
            };
            FilePersonRepository testDB = new FilePersonRepository();
            testDB.Add(p1);
            testDB.Add(p2);
            testDB.Add(p3);
            Console.WriteLine(testDB.CountPersonOverYrs(1900));
            testDB.Remove(3);
            testDB.Update(p4);



        }



    }
}
