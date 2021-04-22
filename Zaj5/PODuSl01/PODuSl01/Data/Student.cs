using PODuSl01.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01.Data
{
    class Student : Osoba, IStudent
    {
        public string Uczelnia { get; set; }
        public string Kierunek { get; set; }
        public int Rok { get; set; }
        public int Semestr { get; set; }

        public string WypiszPelnaNazweIUczelnie()
        {
            return GetFullName() + $"- {Semestr} {Kierunek} {Rok} {Uczelnia}";  
        }
    }
}
