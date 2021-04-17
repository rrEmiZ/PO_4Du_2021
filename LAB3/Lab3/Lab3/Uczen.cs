using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Uczen : Osoba
    {
        public String Szkoła { get; private set; }
        public bool MozeSamWracacDoDomu { get; private set; }

        public Uczen(String szkoła, String imie, String nazwisko, String pesel) : base(imie, nazwisko, pesel) {
            Szkoła = szkoła;
            DateTime date = DateTime.Now;
            if (getAge(date) >= 12) {
                MozeSamWracacDoDomu = true;
            }
            else
            {
                MozeSamWracacDoDomu = false;
            }
        }

        public String getSchool()
        {
            return Szkoła;
        }
        public void setSchool(String value)
        {
            Szkoła = value;
        }
 
        public void changeSchool(String value)
        {
            Szkoła = value;
        }

        public void setCanGoHomeAlone(bool value)
        {
            MozeSamWracacDoDomu = value;
        }

        public override bool canGoAloneToHome()
        {
           if(MozeSamWracacDoDomu == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void getFullName()
        {
            Console.WriteLine(Imie + " " + Nazwisko);
        }

        public override void getEducationInfo()
        {
            Console.Write("Szkoła: " + Szkoła);
        }

        public void info()
        {
            DateTime date = DateTime.Now;
            int age = getAge(date);

            if(age < 12)
            {
                setCanGoHomeAlone(false);
            }
            else
            {
                setCanGoHomeAlone(true);
            }
        }
    }
}
