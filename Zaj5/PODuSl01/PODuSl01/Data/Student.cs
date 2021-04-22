using System;
using System.Collections.Generic;
using System.Text;
using PODuSl01.Data.Interfaces;

namespace PODuSl01.Data
{
    public class Student : IStudent
    {
        public string Uczelnia { get; set; }
        public string Kierunek { get; set; }
        public int Rok { get; set;  }
        public int Semestr { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }

        //public string GetFullName => $"{FirstName} {LastName} - !!!!";

        public string GetFullName() 
        {
            return $"{FirstName} {LastName} - !!!!";
        }
        public string WypiszPelnaNazweIUczelnie()
        {
            return $"{FirstName} {LastName} {Semestr}{Kierunek} {Rok} {Uczelnia}";
        }


    }
}
