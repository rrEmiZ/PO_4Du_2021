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



            var Student1 = new Student()
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Rok = "2018",
                Kierunek = "IID-P",
                Semestr = "4",
                Uczelnia = "WSIiZ"
            };
            

            var list1 = new List<StudentWSIiZ>();
            list1.Add(new StudentWSIiZ()
            {
                FirstName = "Jan",
                LastName = "Nowak",
                Rok = "2018",
                Kierunek = "IID-P",
                Semestr = "4",
                Uczelnia = "WSIiZ"
            });

            list1.Add(new StudentWSIiZ()
            {
                FirstName = "Radosław",
                LastName = "Micał",
                Rok = "2019",
                Kierunek = "IID-Pdu",
                Semestr = "4",
                Uczelnia = "WSIiZ"
            });

            list.PosortujOsobyPoNazwisku();
            Console.WriteLine(Student1.WypiszPelnaNazweIUczelnie());            
            list1.WypiszOsoby();
            Console.ReadLine();
        }



    }
}
