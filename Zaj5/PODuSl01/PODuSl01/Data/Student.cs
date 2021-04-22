using PODuSl01.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01.Data
{
    public class Student : IStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Uczelnia { get; set; }
        public string Kierunek { get; set; }
        public string Rok { get; set; }

        public string Semestr { get; set; }

        public string GetFullName()
        {
            return WypiszPelnaNazweIUczelnie();
        }

        public string WypiszPelnaNazweIUczelnie()
        {
            return $"{FirstName} {LastName} - {Semestr}{Kierunek} {Rok} {Uczelnia}";
        }
    }
}
