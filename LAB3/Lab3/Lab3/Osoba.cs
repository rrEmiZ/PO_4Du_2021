using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Osoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public Osoba()
        {

        }
        public Osoba(string Imie, string Nazwisko, string Pesel)
        {
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
            this.Pesel = Pesel;
        }
        public void SetFirstName(string Imie)
        {
            this.Imie = Imie;
        }
        public void SetLastName(string Nazwisko)
        {
            this.Nazwisko = Nazwisko;
        }
        public void SetPesel(string Pesel)
        {
            if (Pesel.Length == 11)
            {
                this.Pesel = Pesel;
            }
            else
            {
                throw new InvalidOperationException("Pesel powinien mieć 11 cyfr");
            }
        }
        public int GetAge()
        {
            int first = Int32.Parse(Pesel[0].ToString());
            first *= 10;
            int second = Int32.Parse(Pesel[1].ToString());
            int Age;
            if (Int32.Parse(Pesel[2].ToString()) == 2 || Int32.Parse(Pesel[2].ToString()) == 3)
            {
                Age = 2000 + first + second;
            }
            else
            {
                Age = 1900 + first + second;
            }
            return (System.DateTime.Today.Year - Age);
        }
        public string GetGender()
        {
            int bufor = Pesel[9] % 2;
            if (bufor == 0)
            {
                return "Kobieta";
            }
            else
            {
                return "Mężczyzna";
            }
        }

        public virtual string GetEducationInfo()
        {
            return null;
        }
        public virtual string GetFullName()
        {
            return null;
        }
        public virtual string CanGoAloneRoHome()
        {
            return null;
        }
    }
}

