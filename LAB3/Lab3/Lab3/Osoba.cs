using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Osoba
    {
        public const string male = "Mężczyzna";
        public const string female = "Kobieta";

        protected string Imie, Nazwisko, Pesel;

        public void SetFirstName(string imie)
        {
            this.Imie = imie;
        }

        public void SetLastName(string nazwisko)
        {
            this.Nazwisko = nazwisko;
        }

        public void SetPesel(string pesel)
        {
            this.Pesel = pesel;
        }

        public int GetYearOfBirth()
        {
            int month = Int32.Parse(this.Pesel.Substring(2, 2));
            int baseYear;

            if (month > 80)
                baseYear = 1800;
            else if (month > 20)
                baseYear = 2000;
            else
                baseYear = 1900;

            return baseYear + Int32.Parse(this.Pesel.Substring(0, 2));
        }

        public string GetGender()
        {
            return Int32.Parse(this.Pesel[9].ToString()) % 2 == 0 ? Osoba.female : Osoba.male;
        }

        public virtual string GetEducationInfo() { return "-- Uczeń ukończył szkołę --"; }
        public virtual string GetFullName() { return Imie; }
        public virtual bool CanGoAloneHome(DateTime dateToCheck) { return true; }

        public int GetAge(DateTime dateToCheck)
        {
            return dateToCheck.Year - this.GetYearOfBirth();
        }

    }
}
