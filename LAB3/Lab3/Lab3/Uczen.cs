using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Uczen : Osoba
    {
        public string Szkola { get; set; }
        public bool MozeSamWracacDoDomu { get; set; }
        
        public Uczen() : base()
        {

        }
        public Uczen(string Imie, string Nazwisko, string Pesel, string Szkola, bool MozeSamWracacDoDomu) :base (Imie, Nazwisko, Pesel)
        {
            this.Szkola = Szkola;
            this.MozeSamWracacDoDomu = MozeSamWracacDoDomu;
        }
        public Uczen(string Imie, string Nazwisko, string Pesel, string Szkola) : base(Imie, Nazwisko, Pesel)
        {
            this.Szkola = Szkola;
            
        }

        public void SetSchool(string Szkola)
        {
            this.Szkola = Szkola;
        }
        public void ChangeSchool(string Szkola)
        {
            this.Szkola = Szkola;
        }
        public void SetCanGoHomeAlone(bool Can)
        {
            if (Can = true  )
            {
                this.MozeSamWracacDoDomu = true;
            }
        }
        public override string GetEducationInfo()
        {
            return Szkola;
        }
        public override string GetFullName()
        {
            return Imie + " " + Nazwisko;
        }
        public override string CanGoAloneRoHome()
        {
            if (MozeSamWracacDoDomu ==  true || GetAge() >= 12) 
            {
                return "Może wracać samemu";
            }
            else
            {
                return "Nie może wracać samemu";
            }
        }
        public string Reasoning()
        {
            if (GetAge() < 12 && MozeSamWracacDoDomu == false)
            {
                return "Jest za młody i nie ma pozwolenia od rodzica.";
            }
            else if (GetAge() < 12 && MozeSamWracacDoDomu == true)
            {
                return ("Jest za młody, ale ma pozwolenia od rodzica.");
            }
            else if(GetAge() >= 12 && MozeSamWracacDoDomu == false)
            {
                return "Ma wystarczająco ilość lat, ale ma zakaz od rodzica";
            }
            else
            {
                return "Ma wystarczającą ilość lat.";
            }
        }

    }
}
