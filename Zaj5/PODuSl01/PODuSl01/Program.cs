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

            var StudentSample = new Student()
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Rok = 2018,
                Kierunek = "IID-P",
                Semestr = 4,
                Uczelnia = "WSIiZ"
            };

            var list1 = new List<StudentWSIiZ>();
            list1.Add(new StudentWSIiZ()
            {
                FirstName = "Janina",
                LastName = "Kowalska",
                Rok =2019,
                Kierunek="IID-P",
                Semestr=3,
                Uczelnia="WSIiZ"
            });

            list1.Add(new StudentWSIiZ()
            {
                FirstName = "Paweł",
                LastName = "Misiewicz",
                Rok = 2020,
                Kierunek = "IID-PDu",
                Semestr =4,
                Uczelnia = "WSIiZ"
            });

            list1.Add(new StudentWSIiZ()
            {
                FirstName = "Kamil",
                LastName = "Ślimak",
                Rok = 2020,
                Kierunek = "IID-PDu",
                Semestr = 4,
                Uczelnia = "WSIiZ"
            });

        


            list.WypiszOsoby();
            Console.WriteLine("\nAlfabetycznie:");

            list.PosortujOsobyPoNazwisku();
            Console.WriteLine("\n");

            Console.WriteLine(StudentSample.WypiszPelnaNazweIUczelnie());
            Console.WriteLine("\n");
            list1.WypiszOsoby();
            Console.ReadLine();





        }





    }
}

