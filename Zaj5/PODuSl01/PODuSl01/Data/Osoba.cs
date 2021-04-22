using PODuSl01.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01.Data
{
    public class Osoba : IOsoba
    {
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
