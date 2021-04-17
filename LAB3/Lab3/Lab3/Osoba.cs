using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Osoba
    {
        public String Imie { get; private set; }
        public String Nazwisko { get; private set; }
        public String Pesel { get; private set; }

        public Osoba(String imie, String nazwisko, String pesel)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            if (pesel.Length > 11 | pesel.Length < 11)
            {
                throw new ArgumentException("Parameter cannot be less and higher than 11");
            }
            else
            {
                Pesel = pesel;
            }
        }


        public void setFirstName(String value)
        {
            Imie = value;
        }

        public void setLastName(String value)
        {
           Nazwisko = value;
        }

        public void setPesel(String value)
        {
            Pesel = value;
        }

       public String getGender()
        {
            if (Int32.Parse(Pesel[9].ToString()) % 2 == 0)
            {
                return "K";
            }
            else
            {
                return "M";
            }
        }

        public int getAge(DateTime date)
        {
            int baseYear = 1900;

            if(Int32.Parse(Pesel[2].ToString()) == 2 || Int32.Parse(Pesel[2].ToString()) == 3)
            {
                baseYear = 2000;
            }
            int yearOfBirth = Int32.Parse(Pesel[0].ToString() + Pesel[1].ToString());
            int age = date.Year - (yearOfBirth + baseYear);
            return age;
        }

        public virtual void getEducationInfo()
        {

        }
        public virtual void getFullName()
        {

        }

        public virtual bool canGoAloneToHome() {
            return false;
        }
        


    }
}
