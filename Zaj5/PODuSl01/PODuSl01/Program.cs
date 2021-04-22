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
                LastName = "Nowak"
            });


            list.Add(new Osoba()
            {
                FirstName = "Janusz",
                LastName = "Browarski"
            });

            list.WypiszOsoby();
            Console.ReadLine();

            // Testowanie zadania 3
            list.PosortujOsobyPoNazwisku();
            list.WypiszOsoby();
            Console.ReadLine();

            // Testowanie zadania 4-5
            // StudentWSIiZ ma domyślna uczelne WSIiZ
            list.Add(new StudentWSIiZ()
            { 
                FirstName = "Adam",
                LastName = "Adamski",
                Kierunek = "IID-P-Du",
                Rok ="2019",
                Semestr ="4"
            });

            list.Add(new StudentWSIiZ()
            {
                FirstName = "Bartek",
                LastName = "Mazur",
                Kierunek = "IID-P-Du",
                Rok = "2019",
                Semestr = "4"
            });

            list.WypiszOsoby();
            Console.ReadLine();
            list.PosortujOsobyPoNazwisku();
            list.WypiszOsoby();
        }



    }
}
