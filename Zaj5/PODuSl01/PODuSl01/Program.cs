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
                  LastName = "Zareba"
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

            list.WypiszOsoby();



            list.Add(new StudentWSIiZ()
            {
                FirstName = "Janusz",
                LastName = "Boniek",
                Kierunek = "IID",
                Rok = "2016",
                Semestr = "8"
            });

            list.Add(new StudentWSIiZ()
            {
                FirstName = "Jarek",
                LastName = "Bednarz",
                Kierunek = "IID",
                Rok = "2016",
                Semestr = "7"
            });

            
            list.PosortujOsobyPoNazwisku();
            list.WypiszOsoby();

            Console.ReadLine();


        }



    }
}
