using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Zajecia10ZadanieToJuzNieWiemSam
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Car: ICarRepository
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Manufactured { get; set; }
        public int EngineCapacity { get; set; }
        public double Power { get; set; }
        public string Type { get; set; }
        public string LicensePlate { get; set; }

        //a to nie wiem czy dobrze zrobiłem, bo dowiedziałem sie jak to zrobić z neta a nie z lekcji, to chyba nie dobrze jest :/
        //ale już kilka rzeczy nie wiedziałej jak zrobić z lekcji to pomyślałem że moze czegoś nie dosłyszałem idk
        public void Add(Car carToAdd)
        {
            using (var sr = new StreamWriter("cars.json"))
            {
                var stuff = JsonConvert.SerializeObject(carToAdd);
                sr.WriteLine(stuff);
            }
        }

        //tego staffu nauczyłem się w sumie z ostatnich lekcji, nie widziałem jak to zrobić z pierwszym zadaniem
        public List<Car> GetAll()
        {
            var list = new List<Car>();
            using (var sr = new StreamReader("cars.json"))
            {
                var json = sr.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Car>>(json);
                return list;
            }
        }


        public void Remove(int id)
        {
            using (var sr = new StreamReader("cars.json"))
            {
                var json = sr.ReadToEnd();
                var jObj = JsonConvert.DeserializeObject(json);
                HashSet<int> idsToDelete = new HashSet<int>() { id };
                //no na wykładach tego dalej nie widziałem jak usunąć, to próbowałem na necie znaleźć, ale się nie udało
                //jObj.Where(x => idsToDelete.Contains((string)x["EngineCapacity"])).ToList().ForEach(doc => doc.Remove());

                var newJson = jObj.ToString();
            }
        }

        public void Update(Car carToUpdate)
        {
            //no tak jak wyżej na laborkach nie było to nwm
        }
    }

    public interface ICarRepository
    {
        List<Car> GetAll();
        void Add(Car carToAdd);
        void Update(Car carToUpdate);
        void Remove(int id);
    }

    class Program
    {
        static void Main(string[] args)
        {
            //stuff z lekcji
            {
                var carsy = new List<Car>();
                int[] numbers = { 2, 3, 4, 5 };

                var squaredNumbers = numbers.Select((parametrWej) =>
                {
                    return (parametrWej * parametrWej).ToString();
                });
                var squaredNumbers2 = numbers.Select((parametrWej) => parametrWej * parametrWej);
                var result = carsy.Select(s => s.Manufactured);

                var whereEx = carsy.Where(s => s.Manufacturer == "AUDI").Select(s => s.LicensePlate).ToList();

                var countEx = carsy.Where(s => s.Manufacturer == "AUDI").Count();
                var countExEx = carsy.Count(s => s.Manufacturer == "AUDI");
            }
            using (var sr = new StreamReader("cars.json"))
            {
                List<Car> list;
                var json = sr.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Car>>(json);
                Console.WriteLine(ileAUDI(list).ToString());
                Console.WriteLine(ilePowyzej2L(list).ToString());
                Console.WriteLine(ileBMW(list).ToString());
                Console.WriteLine(ilePonizej2L(list).ToString());
            }
        }
        static int ileAUDI(List<Car> list)
        {
            int rezult = 0;
            rezult = list.Where(s => s.Manufacturer == "AUDI").Count();
            return rezult;
        }
        static int ilePowyzej2L(List<Car> list)
        {
            int rezult = 0;
            rezult = list.Count(s => s.EngineCapacity >= 2000);
            return rezult;
        }
        static int ileBMW(List<Car> list)
        {
            int rezult = 0;
            rezult = list.Count(s => s.Manufacturer == "BMW");
            return rezult;
        }
        static int ilePonizej2L(List<Car> list)
        {
            int rezult = 0;
            rezult = list.Count(s => s.EngineCapacity <= 2000);
            return rezult;
        }
    }
}
