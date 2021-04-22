using PODuSl01.Data;
using PODuSl01.Data.Interfaces;
using System;
using System.Collections.Generic;
using PODuSl01.Extensions;

namespace PODuSl01
{
 
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<IOsoba>();


            list.Add(new Osoba()
            {
                 FirstName = "Jan",
                  LastName = "Kowalski"
            });


            list.Add(new Osoba()
            {
                FirstName = "Janina",
                LastName = "Kowalska"
            });


            list.Add(new Osoba()
            {
                FirstName = "Janusz",
                LastName = "Kowalskyj"
            });

            var list1 = new List<IStudent>();

            list1.Add(new StudentWSIIZ() {
                FirstName = "Jan",
                LastName = "Matej",
                Uczelnia = "WSIIZ",
                Kierunek = "IID-P-Du",
                Rok = "2018",
                Semestr = "4"
            });

            list1.Add(new StudentWSIIZ()
            {
                FirstName = "Michał",
                LastName = "Jankowski",
                Uczelnia = "WSIIZ",
                Kierunek = "IID-P-Du",
                Rok = "2018",
                Semestr = "4"
            });

            list1.Add(new StudentWSIIZ()
            {
                FirstName = "Andrzej",
                LastName = "Zaucha",
                Uczelnia = "WSIIZ",
                Kierunek = "IID-P-Du",
                Rok = "2018",
                Semestr = "4"
            });
            list1.WypiszOsoby();
            Console.WriteLine("-------");
            list.PosortujOsobyPoNazwisku();

            Console.ReadLine();

        }



    }
}
