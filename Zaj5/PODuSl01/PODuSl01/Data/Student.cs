using System;
using System.Collections.Generic;
using System.Text;
using PODuSl01.Data.Interfaces;
namespace PODuSl01.Data
{
    class Student : IStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Uczelnia { get; set; }
        public string Kierunek { get; set; }
        public string Semester { get; set; }
        public int year { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public String WriteFullNameCollage()
        {
            return GetFullName() + " - " + Semester + " " + year.ToString() + " " + Uczelnia;
        }

    }
}
