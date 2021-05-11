using System;
using System.Collections.Generic;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<IOsoba>();

            list.Add(new Osoba()
            {
                FirstName = "Jan",
                LastName = "CKolwalski"
            });
            list.Add(new Osoba()
            {
                FirstName = "Janina",
                LastName = "AKolwalska"
            });
            list.Add(new Osoba()
            {
                FirstName = "Janusz",
                LastName = "BKolwalskyj"
            });

            Console.WriteLine("wypisz osoby: ");
            list.WypiszOsoby();
            Console.WriteLine("sortowanie po nazwisku: ");
            list.PosortujOsobyPoNazwisku();

            var  ob = new Strudent(); 
            ob.WypiszPelnaNazweIUczelnie();

            var list5 = new List<StudentWSLiZ>();
            var a = new StudentWSLiZ();
            var b = new StudentWSLiZ();
            var c = new StudentWSLiZ();
            list5.Add(a);
            list5.Add(b);
            list5.Add(c);
            Console.ReadLine();
        }
    }
    public interface IStudent
    {
        string Uczelnia { get; set; }
        string Kierunek { get; set; }
        string Rok { get; set; }
        string Semestr { get; set; }
    }
    public interface IOsoba:IStudent
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        string GetFullName();

        public string ForSortingProblem();
    }
    public class Strudent : IOsoba
    {
        public string Uczelnia { get ; set; }
        public string Kierunek { get ; set ; }
        public string Rok { get ; set ; }
        public string Semestr { get ; set ; }
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }

        public string ForSortingProblem()
        {
            throw new NotImplementedException();
        }

        public string GetFullName()
        {
            throw new NotImplementedException();
        }

        public void WypiszPelnaNazweIUczelnie()//paradoks w zadaniu jest zeby to był string, a nie lepiej po prostu void z writelinem?
        {
            Console.WriteLine($"{FirstName} {LastName} - {Kierunek} {Rok} {Uczelnia} auauauau");
        }
    }
    public class Osoba : IOsoba
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Uczelnia { get ; set ; }
        public string Kierunek { get ; set ; }
        public string Rok { get ; set ; }
        public string Semestr { get ; set ; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
        public string ForSortingProblem()
        {
            return $"{LastName} {FirstName}";
        }
    }
    public static class IOsobaExtensions
    {
        public static void WypiszOsoby(this List<IOsoba> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{list[i].GetFullName()}");
            }
        }
        public static void PosortujOsobyPoNazwisku(this List<IOsoba> list)
        {
            List<string> gruper = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                gruper.Add(list[i].ForSortingProblem());
            }
            gruper.Sort();
            for (int i = 0; i < gruper.Count; i++)
            {
                Console.WriteLine(gruper[i]);
            }
        }
    }

    public class StudentWSLiZ:Strudent
    {
        public  void WypiszOsoby()
        {
            WypiszPelnaNazweIUczelnie();// xD
        }
    }
}
