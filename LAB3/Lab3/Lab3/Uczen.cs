using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Uczen : Osoba
    {
        public string Szkola { get; set; }
        public bool MozeSamWracacDoDomu { get; set; }

        public Uczen(string imie, string nazwisko, string szkola, string pesel)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Szkola = szkola;
            Pesel = pesel;
        }
        public void SetSchool(string szkola)
        {
            Szkola = szkola;
        }

        public void ChangeSchool(string szkola)
        {
            Szkola = szkola;
        }

        public void SetCanGoHomeAlone(bool permission)
        {
            MozeSamWracacDoDomu = permission;
        }

        public override string GetEducationInfo()
        {
            return Szkola;
        }

        public override string GetFullName()
        {
            return Imie + ' ' + Nazwisko;
        }

        public override bool CanGoAloneHome(DateTime dateToCheck)
        {
            return MozeSamWracacDoDomu || this.GetAge(dateToCheck) >= 12;
        }
    }
}
