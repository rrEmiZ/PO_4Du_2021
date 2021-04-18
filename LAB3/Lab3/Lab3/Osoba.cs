using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;

namespace ConsoleApp1
{
    class Osoba
    {

        string Imie;
        string Nazwisko;
        int[] Pesel = new int [11];

        public virtual void SetFirstName(string FName)
        {
            Imie = FName;
        }

        public virtual void SetLastName(string LName)
        {
            Nazwisko = LName;
        }

        public virtual void SetPesel(int pesel)
        {
            for (double i = 0; i < 11; i++)
            {
                Pesel[(int)(10-i)] = (int)(pesel % Math.Pow(10.0, i));
            }
        }

        
        public int GetAge()
        {
            int Now = DateTime.Today.Year;

            int bYear = 1900 + Pesel[0] * 10 + Pesel[1];
            if (Pesel[2] >= 2 && Pesel[2] < 8)
                bYear += Pesel[2] / 2 * 100;
            if (Pesel[2] >= 8)
                bYear -= 100;

            return Now - bYear;

        }

        public string GetGender()
        {
            if(Pesel[9]%2==0)
            {
                return "F";
            }
            else
            {
                return "M";
            }
        }

        public virtual string GetEducationInfo()
        {
            return "";
        }


       public virtual string GetFullName()
        {
            return Imie + " " + Nazwisko;
        }

        public virtual bool CanGoAloneToHome()
        {
            return false;
        }


    }
}
