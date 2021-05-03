using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab5
{
    class Program
    {
        public static void zad1and2()
        {
            Console.WriteLine("Podaj nr albumu:");
            string nrAlbumu = Console.ReadLine();

            //Otwieramy stream pliku DataFile.txt i zapis nr albumu użytkownika bez napisaywania
            using (var sw = new StreamWriter("DataFile.txt", append: true))
            {
                sw.WriteLine(nrAlbumu);
            }

            Console.WriteLine("Wprowadzone dane:");
            //Otwieramy stream pliku DataFile.txt
            using (var sr = new StreamReader("DataFile.txt"))
            {
                var line = sr.ReadToEnd();
                Console.WriteLine(line);
            }
        }

        public static void zad3()
        {
            int ilePeseli = 0;
            //otwieranie
            using (var sr = new StreamReader("Pesele.txt"))
            {
                var line = sr.ReadLine();
                while (line != null)
                {
                    if (line[9] % 2 == 0)
                    {
                        ilePeseli++;
                    }
                    line = sr.ReadLine();
                }
            }
            Console.WriteLine(ilePeseli + " - ilość peseli żeńskich w pliku pesele.txt");
        }

        //zad4
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
        
        public static int Populacja(string country, string data1)
        {
            List<Root> list;
            using (var sr = new StreamReader("db.json"))
            {
                var json = sr.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Root>>(json);
            }
            var populacja = list.Where(x => x.country.id == $"{country}" && x.date == $"{data1}").Select(x => x.value).First().ToString();
            return Convert.ToInt32(populacja);
        }
        public static int SredniaPopulacji(string country, string data1, string data2)
        {
            List<Root> list;
            using (var sr = new StreamReader("db.json"))
            {
                var json = sr.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Root>>(json);
            }
            var populacjaA = list.Where(x => x.country.id == $"{country}" && x.date == $"{data1}").Select(x => x.value).First().ToString();
            var populacjaB = list.Where(x => x.country.id == $"{country}" && x.date == $"{data2}").Select(x => x.value).First().ToString();
            return Convert.ToInt32(populacjaB) - Convert.ToInt32(populacjaA);
        }
        public static double ProcntowyWzrostPopulacji(string country, string data1)
        {
            List<Root> list;
            using (var sr = new StreamReader("db.json"))
            {
                var json = sr.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Root>>(json);
            }
            int data2 = Convert.ToInt32(data1) - 1;
            var populacjaA = list.Where(x => x.country.id == $"{country}" && x.date == $"{data2}").Select(x => x.value).First().ToString();
            var populacjaB = list.Where(x => x.country.id == $"{country}" && x.date == $"{data1}").Select(x => x.value).First().ToString();
            return ((double)(Convert.ToInt32(populacjaB) - Convert.ToInt32(populacjaA)) / Convert.ToInt32(populacjaB))*100;
        }

        public static void zad4()
        {

            //Pozwalający sprawdzić ile wynosiróżnica populacji pomiędzy rokiem 1970 a 2000 dla Indii
            Console.WriteLine("Różnica populacji pomiędzy rokiem 1970 a 2000 dla Indi: " + SredniaPopulacji("IN","1970", "2000"));

            //Pozwalający sprawdzić ile wynosiróżnica populacji pomiędzy rokiem 1965 a 2010 dla USA
            Console.WriteLine("Różnica populacji pomiędzy rokiem 1965 a 2010 dla USA: " + SredniaPopulacji("US", "1965", "2010"));

            //Pozwalający sprawdzić ile wynosiróżnica populacji pomiędzy rokiem 1980 a 2018 dla Chin
            Console.WriteLine("Różnica populacji pomiędzy rokiem 1980 a 2018 dla Chin: " + SredniaPopulacji("CN", "1980", "2018"));

            //Pozwalający użytkownikowi na wybranie rokui kraju,z którego populację chciałby wyświetlić.
            //Console.WriteLine("Wybierz dla jakiego kraju chcesz sprawdzić dane:\n1 - Indie\n2 - USA\n3 - Chiny");
            Console.WriteLine("Wybierz dla jakiego kraju chcesz sprawdzić ilość populacji:\n1 - Indie\n2 - USA\n3 - Chiny");
            int choose = Convert.ToInt32(Console.ReadLine());
            string data1, data2;
            switch (choose)
            {
                case 1:
                    Console.WriteLine("Wpisz date:");
                    data1 = Console.ReadLine();
                    Console.WriteLine($"Populacji pomiędzy rokiem {data1}  dla Indi: " + Populacja("IN", Convert.ToString(data1)));
                    break;
                case 2:
                    Console.WriteLine("Wpisz date:");
                    data1 = Console.ReadLine();
                    Console.WriteLine($"Populacji pomiędzy rokiem {data1}  dla USA: " + Populacja("US", Convert.ToString(data1)));
                    break;
                case 3:
                    Console.WriteLine("Wpisz date:");
                    data1 = Console.ReadLine();
                    Console.WriteLine($"Populacji pomiędzy rokiem {data1}  dla Chin: " + Populacja("CN", Convert.ToString(data1)));
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }

            //Pozwalający użytkownikowi na sprawdzenie różnicy populacji dla wskazanego zakresu lat i kraju
            Console.WriteLine("Wybierz dla jakiego kraju chcesz sprawdzić Różnica populacji:\n1 - Indie\n2 - USA\n3 - Chiny");
            choose = Convert.ToInt32(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    Console.WriteLine("wpisz pierszą starszą date:");
                    data1 = Console.ReadLine();
                    Console.WriteLine("wpisz pierszą młodszą date:");
                    data2 = Console.ReadLine();
                    Console.WriteLine($"Różnica populacji pomiędzy rokiem {data1} a {data2} dla Indi: " + SredniaPopulacji("IN", Convert.ToString(data1), Convert.ToString(data2)));
                    break;
                case 2:
                    Console.WriteLine("wpisz pierszą starszą date:");
                    data1 = Console.ReadLine();
                    Console.WriteLine("wpisz pierszą młodszą date:");
                    data2 = Console.ReadLine();
                    Console.WriteLine($"Różnica populacji pomiędzy rokiem {data1} a {data2} dla USA: " + SredniaPopulacji("US", Convert.ToString(data1), Convert.ToString(data2)));
                    break;
                case 3:
                    Console.WriteLine("wpisz pierszą starszą date:");
                    data1 = Console.ReadLine();
                    Console.WriteLine("wpisz pierszą młodszą date:");
                    data2 = Console.ReadLine();
                    Console.WriteLine($"Różnica populacji pomiędzy rokiem {data1} a {data2} dla Chin: " + SredniaPopulacji("CN", Convert.ToString(data1), Convert.ToString(data2)));
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
            
            //Pozwalający użytkownikowi na sprawdzenie procentowego wzrostu populacji dla każdego kraju względem roku poprzedniego do wskazanego,
            Console.WriteLine("Wybierz dla jakiego kraju chcesz sprawdzić Różnica populacji:\n1 - Indie\n2 - USA\n3 - Chiny");
            choose = Convert.ToInt32(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    Console.WriteLine("wpisz date:");
                    data1 = Console.ReadLine();
                    Console.WriteLine($"Procentowego wzrostu populacji pomiędzy rokiem {data1} a rokiem poprzednim dla Indi: { ProcntowyWzrostPopulacji("IN", Convert.ToString(data1))}% ");
                    break;
                case 2:
                    Console.WriteLine("wpisz date:");
                    data1 = Console.ReadLine();
                    Console.WriteLine($"Procentowego wzrostu populacji pomiędzy rokiem {data1} a rokiem poprzednim dla USA: { ProcntowyWzrostPopulacji("US", Convert.ToString(data1))}% ");
                    break;
                case 3:
                    Console.WriteLine("wpisz date:");
                    data1 = Console.ReadLine();
                    Console.WriteLine($"Procentowego wzrostu populacji pomiędzy rokiem {data1} a rokiem poprzednim dla Chin: {ProcntowyWzrostPopulacji("CN", Convert.ToString(data1))}%");
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }

        //zad5
        public interface IPersonRepository
        {
            List<Person> GetAll();
            Person GetById(int id);
            void Add(Person personToAdd);
            void Update(Person personToUpdate);
            void Remove(int id);

            int CountPersonOverYrs(int yearsFromCount);
        }
        public class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Pesel { get; set; }
        }
        public class PersonListAndAction : IPersonRepository
        {
            List<Person> listOfPersons = new List<Person>();
            public List<Person> GetAll()
            {
                return listOfPersons;
            }
            public Person GetById(int id)
            {
                return (Person)listOfPersons.Where(x => x.Id == id).FirstOrDefault();
            }
            public void Add(Person personToAdd)
            {
                listOfPersons.Add(personToAdd);
                SaveListOfPerson();
            }
            public void Update(Person personToUpdate)
            {
                Person person = GetById(personToUpdate.Id);
                if(!person.FirstName.Equals(personToUpdate.Id) || !person.LastName.Equals(personToUpdate.LastName) || !person.Pesel.Equals(personToUpdate.Pesel))
                {
                    person.FirstName = personToUpdate.FirstName;
                    person.LastName = personToUpdate.LastName;
                    person.Pesel = personToUpdate.Pesel;
                    SaveListOfPerson();
                }
            }
            public void Remove(int id)
            {
                listOfPersons.Remove(GetById(id));
                SaveListOfPerson();
            }
            public int CountPersonOverYrs(int yearsFromCount)
            {
                int peopleCount = 0;
                foreach (var person in listOfPersons)
                {
                    var month = person.Pesel.Substring(2, 2);
                    int  year = 0;
                    if (int.Parse(month) >= 1 && int.Parse(month) <= 12)
                    {
                        year = 1900 + int.Parse(person.Pesel.Substring(0, 2));
                    }
                    else if (int.Parse(month) >= 21 && int.Parse(month) <= 32)
                    {
                        year = 2000 + int.Parse(person.Pesel.Substring(0, 2));
                    }
                    else if (int.Parse(month) >= 41 && int.Parse(month) <= 52)
                    {
                        year = 2100 + int.Parse(person.Pesel.Substring(0, 2));
                    }

                    if (year > yearsFromCount) peopleCount++;
                }
                return peopleCount;
            }

            public void SaveListOfPerson()
            {
                using (var sw = new StreamWriter("listOfPersons.json"))
                {
                    var line = JsonConvert.SerializeObject(listOfPersons);
                    sw.WriteLine(line);
                }
            }
            public void ShowListOfPerson()
            {
                using (var sw = new StreamReader("listOfPersons.json"))
                {
                    var json = sw.ReadToEnd();
                    listOfPersons = JsonConvert.DeserializeObject<List<Person>>(json);
                    
                    foreach (var item in listOfPersons)
                    {
                        Console.WriteLine($"{item.FirstName} {item.LastName} {item.Pesel}");
                    }
                }
            }
        }
  
        public static void zad5()
        {
            PersonListAndAction person = new PersonListAndAction();
            person.Add(new Person
            {
                Id = 1,
                FirstName = "Janusz",
                LastName = "Lusek",
                Pesel = "92110296815" //1992
            });
            person.Add(new Person
            {
                Id = 2,
                FirstName = "Marek",
                LastName = "Kowalska",
                Pesel = "92040282412" //1992
            });
            person.Add(new Person
            {
                Id = 3,
                FirstName = "Konrad",
                LastName = "Kowalska",
                Pesel = "05310225536" //2005
            });
            person.Add(new Person
            {
                Id = 4,
                FirstName = "Paweł",
                LastName = "Majewski",
                Pesel = "98040282412" //1998
            });
            person.Update(new Person
            {
                Id = 2,
                FirstName = "Marek",
                LastName = "Majeczek",
                Pesel = "94040282412" //1994
            });

            person.ShowListOfPerson();
            Console.WriteLine($"\nIlość osób urodzonych po roku 1992: {person.CountPersonOverYrs(1992)}");
            person.Remove(2);
            Console.WriteLine($"Ilość osób urodzonych po roku 1992: {person.CountPersonOverYrs(1992)}\n");
            person.ShowListOfPerson();

        }
        static void Main(string[] args)
        {
            //zad1and2();
            //zad3();
            //zad4();
            zad5();
        }
    }
}
