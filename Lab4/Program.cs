using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    //zad1
    public interface IOsoba
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        string GetFullName();
    }
    public class Osoba : IOsoba
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName} - !!!!";
        }
    }
    //zad2
    public static class IOsobaExtensions
    {
        //public static string GetFullName(this IOsoba osoba)
        //{
        //    return $"{osoba.FirstName} {osoba.LastName}";
        //}
        public static void WypiszOsoby(this List<IOsoba> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].GetFullName()}");
            }
        }
        //zad3
        public static void PosortujOsobyPoNazwisku(this List<IOsoba> list)
        {
            Console.WriteLine("Posortowane po nazwiskach:");
            var sortedList = list.OrderBy(x => x.LastName).ToList();
            for (int i = 0; i < sortedList.Count; i++)
            {
               Console.WriteLine($"{i + 1}. {sortedList[i].GetFullName()}");
            }
        }
        //zad5
        public static void WypiszWszystkichDane(this List<IStudent> list)
        {
            Console.WriteLine("Dane studentów WSIiZ:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].WypiszPelnaNazweIUczelnie()}");
            }
        }
    }
    //zad4
    public interface IStudent : IOsoba
    {
        string Uczelnia { get; set; }
        string Kierunek { get; set; }
        int Rok { get; set; }
        int Semestr { get; set; }
        string WypiszPelnaNazweIUczelnie();
    }
    public class Student : IStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Uczelnia { get; set; }
        public string Kierunek { get; set; }
        public int Rok { get; set; }
        public int Semestr { get; set; }
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
        public string WypiszPelnaNazweIUczelnie()
        {
            return $"{FirstName} {LastName} - {Semestr}{Kierunek} {Rok} {Uczelnia}";
        }
    }
    //zad5
    public class StudentWSIiZ : Student{}

    class Program
    {
        static void Main(string[] args)
        {
            /*var list = new List<IOsoba>();


            list.Add(new Osoba()
            {
                FirstName = "Jan",
                LastName = "Bowalski"
            });


            list.Add(new Osoba()
            {
                FirstName = "Janina",
                LastName = "Awalska"
            });


            list.Add(new Osoba()
            {
                FirstName = "Janusz",
                LastName = "Kowalskyj"
            });

            list.WypiszOsoby();
            list.PosortujOsobyPoNazwisku();*/

            var list = new List<IStudent>();


            list.Add(new StudentWSIiZ() //w zad 4 zamiast StudentWSIiZ ma być Student
            {
                FirstName = "Jan",
                LastName = "Bowalski",
                Uczelnia = "WSIiZ",
                Kierunek = "IID-P-Du",
                Rok = 2021,
                Semestr = 4
            });


            list.Add(new StudentWSIiZ()
            {
                FirstName = "Janina",
                LastName = "Awalska",
                Uczelnia = "WSIiZ",
                Kierunek = "IID-P-Du",
                Rok = 2021,
                Semestr = 4
            });


            list.Add(new StudentWSIiZ()
            {
                FirstName = "Janusz",
                LastName = "Kowalskyj",
                Uczelnia = "WSIiZ",
                Kierunek = "IID-P-Du",
                Rok = 2021,
                Semestr = 4
            });

            //list.WypiszStudentow();
            list.WypiszWszystkichDane();

            Console.ReadLine();

        }
    }
    
}
