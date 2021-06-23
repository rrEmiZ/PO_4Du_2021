using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Zadanie4._5
{
    public class Person: IPersonRepository
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }

        public void Add(Person personToAdd)//totalnie nie jestem pewien co ja tu robię
        {
            this.Id = personToAdd.Id;
            this.FirstName = personToAdd.FirstName;
            this.LastName = personToAdd.LastName;
            this.Pesel = personToAdd.Pesel;
        }

        public int CountPersonOverYrs(int yearsFromCount)
        {
            return (yearsFromCount - this.Pesel[0] + this.Pesel[1]);//mam przeczucie że to chyba o coś innego chodzi w tym wszystkim :c
        }

        public List<Person> GetAll()// a jak to w ogóle działa że tu ta lista jest jakby metodą, a jednak nie jest?
        {
            //nie mam bladego pojęcia o co chodzi w tym całym podpunckie
        }

        public Person GetById(int id)
        {
            this.Id = id;
            //tu mam error, a to jest konstruktor, i każe on mi coś zwracać wtf
        }

        public void Remove(int id)
        {
            //aaaaaaaaaaaaa
        }

        public void Update(Person personToUpdate)
        {
            //aaaaaaaaaaa
        }
    }


    public interface IPersonRepository
    {
        List<Person> GetAll();
        Person GetById(int id);
        void Add(Person personToAdd);
        void Update(Person personToUpdate);
        void Remove(int id);

        int CountPersonOverYrs(int yearsFromCount);
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
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
            //1. Napisz program pozwalający na zapisanie do pliku o wskazanej nazwie, nr albumu 
            //osoby, która napisała program.
            using (var sw = new StreamWriter("zadanieDoLaborkow4i5BoZapomnialemOTym.txt", append: true))
            {
                //sw.WriteLine("61936");//zakomentowane bo mi się cały czas dopisywało podczas debugowania
            }
            //2. Napisz program pozwalający na wczytanie zawartości pliku o wskazanej nazwie.
            using (var sr = new StreamReader("zadanieDoLaborkow4i5BoZapomnialemOTym.txt"))
            {
                var text = sr.ReadToEnd();
                Console.WriteLine(text);
            }
            //3. Napisz program wczytujący listę peseli z pliku pesels.txt, a następnie zaimplementuj 
            //funkcję sprawdzającą, ile jest żeńskich peseli we wczytanym zbiorze.
            using (var sr = new StreamReader("pesel.txt"))
            {
                int WomenNumber = 0;
                var line = sr.ReadLine();
                string holdMe;
                while (line != null)
                {
                    holdMe = sr.ReadLine();
                    if (holdMe[0] == '2' || holdMe[0] == '4' || holdMe[0] == '6' || holdMe[0] == '8' || holdMe[0] == '0')
                        WomenNumber++;
                    line = sr.ReadLine();
                }
                Console.WriteLine(WomenNumber.ToString());//21
            }

            //4. Wykorzystując bazę danych „db.json”, zawierającą informację o populacji USA, Indii i 
            //Chin od roku 1960, napisz program:
            using (var sr = new StreamReader("sample.json"))
            {
                int PopulacjaIndii1970 = 0;
                int PopulacjaIndii2000 = 0;
                int PopulacjaUSA1965 = 0;
                int PopulacjaUSA2010 = 0;
                int PopulacjaChina1980 = 0;
                int PopulacjaChina2018 = 0;
                string samSeWybierz="China";
                string samSeWybierzz="2000";
                int samSeWybrales = 0;
                int ostatniPodpunkt = 0;

                List<Root> list;
                var json = sr.ReadToEnd();

                list = JsonConvert.DeserializeObject<List<Root>>(json);

                foreach (var item in list)
                {
                    if (item.country.value == "India" && item.date == "1970")
                        PopulacjaIndii1970 = Int32.Parse(item.value);
                    if (item.country.value == "India" && item.date == "2000")
                        PopulacjaIndii2000 = Int32.Parse(item.value);
                    if (item.country.value == "United States" && item.date == "1965")
                        PopulacjaUSA1965 = Int32.Parse(item.value);
                    if (item.country.value == "United States" && item.date == "2010")
                        PopulacjaUSA2010 = Int32.Parse(item.value);
                    if (item.country.value == "China" && item.date == "1980")
                        PopulacjaChina1980 = Int32.Parse(item.value);
                    if (item.country.value == "China" && item.date == "2018")
                        PopulacjaChina2018 = Int32.Parse(item.value);
                    //samSeWybierz = Console.ReadLine();
                    //samSeWybierzz = Console.ReadLine(); <-------------------------------------do wybrania, zakomentowane bo nie chce za każdym razem klikać
                    if (item.country.value == samSeWybierz && item.date == samSeWybierzz)
                        samSeWybrales = Int32.Parse(item.value);
                    //samSeWybierz = Console.ReadLine();
                    //samSeWybierzz = Console.ReadLine(); <-------------------------------------do wybrania, zakomentowane bo nie chce za każdym razem klikać
                    if (item.country.value == samSeWybierz && item.date == samSeWybierzz)
                        samSeWybrales = Int32.Parse(item.value);
                    //samSeWybierz = Console.ReadLine();
                    //samSeWybierzz = Console.ReadLine(); <-------------------------------------do wybrania, zakomentowane bo nie chce za każdym razem klikać
                    if (item.country.value == samSeWybierz && item.date == samSeWybierzz)
                        samSeWybrales = Int32.Parse(item.value);
                    //samSeWybierz = Console.ReadLine();
                    //samSeWybierzz = Console.ReadLine(); <-------------------------------------do wybrania, zakomentowane bo nie chce za każdym razem klikać
                    if (item.country.value == samSeWybierz && item.date == samSeWybierzz)
                        ostatniPodpunkt = Int32.Parse(item.value);
                    if (item.country.value == samSeWybierz && item.date == (Int32.Parse(samSeWybierzz)-1).ToString())
                        ostatniPodpunkt = Int32.Parse(item.value);

                }
                Console.WriteLine("ile wynosi różnica populacji pomiędzy rokiem 1970 a 2000 dla Indii: " + (PopulacjaIndii2000 - PopulacjaIndii1970).ToString());
                Console.WriteLine("ile wynosi różnica populacji pomiędzy rokiem 1965 a 2010 dla USA: " + (PopulacjaUSA2010 - PopulacjaUSA1965).ToString());
                Console.WriteLine("ile wynosi różnica populacji pomiędzy rokiem 1980 a 2018 dla China: " + (PopulacjaChina2018 - PopulacjaChina1980).ToString());
                Console.WriteLine("sam se wybierz: " + (samSeWybrales).ToString());
                Console.WriteLine("wskazanego zakresu lat i kraju: " + (samSeWybrales - samSeWybrales).ToString());
                Console.WriteLine("nie pamietam jak zrobic procentowy przyrost i mieni mi sie w glowie od tego kodu: " + (ostatniPodpunkt - ostatniPodpunkt).ToString());
            }
            //5. Napisz program implementujący interfejs IPersonRepository, poprzez klasę 
            //FilePersonRepository pracującą na plikowej bazie danych. (Json, record per line, etc).
            using (var sr = new StreamReader("pesel.txt"))
            {
                var ob = new Person();
                var text = sr.ReadToEnd();
                ob.Pesel = text;
                // no pracuje na plikach, i spełnia zadanie, ale totalnie nie wiem po co ta implementacja, co mam zrobić z tymi metodami, nie ma napisane
            }
        }
    }
}
