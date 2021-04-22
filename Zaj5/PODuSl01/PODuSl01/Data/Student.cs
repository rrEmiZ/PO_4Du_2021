using System;
using System.Collections.Generic;
using System.Text;
using PODuSl01.Data.Interfaces;

namespace PODuSl01.Data
{
    public class Student : Osoba, IStudent
    {
        public string Uczelnia { get; set; }
        public string Kierunek { get; set; }
        public int Rok { get; set; }
        public int Semestr { get; set; }
        public string WypiszPelnaNazweIUczelnie()
        {
            var str = $"{FirstName} {LastName} - {Semestr}{Kierunek} {Rok} {Uczelnia}";
            Console.WriteLine(str);
            return str;
        }
    }
}
