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
                 FirstName = "Maksymilian",
                  LastName = "Cep"
            });


            list.Add(new Osoba()
            {
                FirstName = "Janina",
                LastName = "Anusiak"
            });


            list.Add(new Osoba()
            {
                FirstName = "Katarzyna",
                LastName = "Rakusz"
            });
            list.Add(new Osoba()
            {
                FirstName = "Jakub",
                LastName = "Joń"
            });
            list.Add(new Osoba()
            {
                FirstName = "Kuba",
                LastName = "Joń"
            });

            list.Add(new Osoba()
            {
                FirstName = "Kamil",
                LastName = "Ślimak"
            });

            list.Add(new Osoba()
            {
                FirstName = "Patryk",
                LastName = "Ósmak"
            });

            list.Add(new Osoba()
            {
                FirstName = "Ksawery",
                LastName = "Anatoli"
            });

            list.PosortujOsobyPoNazwisku();
            list.WypiszOsoby();

            Console.WriteLine();

            var list2 = new List<IStudent>();
            list2.Add(new StudentWSIiZ()
            {
                FirstName = "Karyna",
                LastName = "Janusz",
                Kierunek = "Kosmetologia",
                Rok = 2019,
                Semestr = 4
            });
            list2.Add(new StudentWSIiZ()
            {
                FirstName = "Robert",
                LastName = "Ancymon",
                Kierunek = "Informatyka",
                Rok = 2018,
                Semestr = 5
            });
            list2.Add(new StudentWSIiZ()
            {
                FirstName = "Artur",
                LastName = "Muł",
                Kierunek = "Dietetyka",
                Rok = 2016,
                Semestr = 6
            });
            list2.WypiszOsoby();
            

            Console.ReadLine();

        }



    }
}
