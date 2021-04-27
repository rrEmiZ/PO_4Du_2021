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

            list.WypiszOsoby();

            var lista = new List<StudentWSIIZ>();

            list.Add(new StudentWSIIZ()
            {
                FirstName = "Mateusz",
                LastName = "Lew",
                Uczelnia = " WSIIZ",
                Kierunek = "IID",
                Rok = 2019,
                Semestr = 4
            });
            list.Add(new StudentWSIIZ()
            {
                FirstName = "Adam",
                LastName = "Kot",
                Uczelnia = " WSIIZ",
                Kierunek = "IID",
                Rok = 2019,
                Semestr = 6,
            });
            list.Add(new StudentWSIIZ()
            {
                FirstName = "Anna",
                LastName = "Lech",
                Uczelnia = " WSIIZ",
                Kierunek = "IID",
                Rok = 2018,
                Semestr = 3,
            });

            Console.ReadLine();

        }



    }
}
