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
            var Studenci = new List<StudentWSIiZ>();


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
           
            Studenci.Add(new StudentWSIiZ()
            {
                FirstName = "John",
                LastName = "Kowal",
                Uczelnia = "UPD",
                Kierunek = "Kowalstwo",
                Rok = 2019,
                Semestr = 2
            });
            Studenci.Add(new StudentWSIiZ()
            {
                FirstName = "Johnathan",
                LastName = "Kribki",
                Uczelnia = "USD",
                Kierunek = "Zielarstwo",
                Rok = 2021,
                Semestr = 2
            });
            Studenci.Add(new StudentWSIiZ()
            {
                FirstName = "Matthew",
                LastName = "Boss",
                Uczelnia = "TSGOP",
                Kierunek = "Programming",
                Rok = 2023,
                Semestr = 10
            });
            foreach (var Student in Studenci) 
            {
                Student.WypiszPelnaNazweIUczelnie();          
            }
            Console.ReadLine();           
        }
    }
}
