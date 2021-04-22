using PODuSl01.Data;
using PODuSl01.Data.Interfaces;
using System;
using System.Collections.Generic;
using PODuSl01.Extensions;

namespace PODuSl01
{
    class Program
    {
        static void Main()
        {
            var list = new List<IOsoba>();
            var list2 = new List<StudentWSIiZ>();

            list.Add(new Osoba()
            {
                 FirstName = "Jan",
                  LastName = "cKowalski"
            });


            list.Add(new Osoba()
            {
                FirstName = "Janina",
                LastName = "aKowalska"
            });


            list.Add(new Osoba()
            {
                FirstName = "Janusz",
                LastName = "bKowalskyj"
            });

            list.WypiszOsoby();

            list.PosortujOsobyPoNazwisku(SortOrder.asc);

            list.WypiszOsoby();

            list2.Add(new StudentWSIiZ()
            {
                FirstName = "Antek",
                LastName = "Kowalski",
                Uczelnia = "WSIiZ",
                Rok = 2019,
                Semestr = 3,
                Kierunek = "IID-P"
            });

            list2.Add(new StudentWSIiZ()
            {

                FirstName = "Karolina",
                LastName = "Kowalska",
                Uczelnia = "WSIiZ",
                Rok = 2020,
                Semestr = 2,
                Kierunek = "KID-F"
            });

            list2.Add(new StudentWSIiZ()
            {

                FirstName = "Sebastian",
                LastName = "Kowalski",
                Uczelnia = "WSIiZ",
                Rok = 2018,
                Semestr = 6,
                Kierunek = "AMIIZ-K"
            });
            
            foreach(var stud in list2)
            {
                stud.WypiszPelnaNazweIUczelnie();
            }
            Console.ReadLine();
        }
    }
}
