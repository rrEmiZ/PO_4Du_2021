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

            var list2 = new List<IStudent>();

            list.Add(new Student()
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Uczelnia = " WSIZ",
                Semestr = "4",
                Rok = 2019
            });

            list.Add(new Student()
            {
                FirstName = "Janek",
                LastName = "Kowal",
                Uczelnia = " WSIZ",
                Semestr = "3",
                Rok = 2014
            });

            list.Add(new Student()
            {
                FirstName = "Janek",
                LastName = "Nowak",
                Uczelnia = " WSIZ",
                Semestr = "2",
                Rok = 2016
            });

            Console.ReadLine();

        }



    }
}
