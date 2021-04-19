using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public abstract class Osoba
    {
        public string Imie { get; private set; }
        public string Nazwisko { get;  private set; }
        string Pesel { get; set; }

        public void SetFirstName(string Imie_)
        {
            Imie = Imie_;
        }
        public void SetLastName(string Nazwisko_)
        {
            Nazwisko = Nazwisko_;
        }
        public void SetPesel(string Pesel_)
        {
            Pesel = Pesel_;
        }
        public int GetAge()
        {
            PeselParts pp = new PeselParts();
            pp.day = Pesel.Substring(4, 2);
            pp.month = Pesel.Substring(2, 2);
            if (int.Parse(pp.month) > 12 && int.Parse(pp.month) <= 32)
            {
                pp.year = "20"+ Pesel.Substring(0, 2);
                pp.month = (int.Parse(pp.month) - 20).ToString();
                if (pp.month.Length == 1) pp.month = "0" + pp.month;
            }
            else if (int.Parse(pp.month) > 32 && int.Parse(pp.month) <= 52)
            {
                pp.year = "21" + Pesel.Substring(0, 2);
                pp.month = (int.Parse(pp.month) - 40).ToString();
            }
            else if (int.Parse(pp.month) > 52 && int.Parse(pp.month) <= 72)
            {
                pp.year = "22" + Pesel.Substring(0, 2);
                pp.month = (int.Parse(pp.month) - 60).ToString();
            }
            else pp.year = "19" + Pesel.Substring(0, 2);

            string today = DateTime.Today.ToString("yyyyMMdd");
            string bday = pp.year + pp.month + pp.day;

            int res = int.Parse(today) - int.Parse(bday);
            return int.Parse(res.ToString().Substring(0, res.ToString().Length-4));
        }
        public char GetGender()
        {
            if ((int)Pesel[9] % 2 == 0) return 'k';
            else return 'm';
        }

        public abstract string GetEducationInfo();
        public abstract string GetFullName();
        public abstract bool CanGoAloneToHome();

        struct PeselParts
        {
            public string year { get; set; }
            public string month { get; set; }
            public string day { get; set; }
        }
    }

    public class Uczen : Osoba
    {
        string Szkola { get; set; }
        bool MozeSamWracacDoDomu { get; set; }

        public void SetSchool(string Szkola_)
        {
            Szkola = Szkola_;
        }
        public void ChangeSchool(string Szkola_)
        {
            Szkola = Szkola_;
        }
        public void SetCanGoHomeAlone(bool MozeSamWracacDoDomu_)
        {
            MozeSamWracacDoDomu = MozeSamWracacDoDomu_;
        }
        public override bool CanGoAloneToHome()
        {
            if (GetAge() >= 12 || MozeSamWracacDoDomu) return true;
            else return false;
        }

        public override string GetEducationInfo()
        {
            return Szkola;
        }

        public override string GetFullName()
        {
            return Imie + " " + Nazwisko;
        }
    }

    public class Nauczyciel : Uczen
    {
        public string TytulNaukowy { get; set; }
        public List<Uczen> PodwladniUczniowie { get; set; }

        public override string GetFullName()
        {
            return TytulNaukowy + " " + Imie + " " + Nazwisko;
        }

        public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
        {
            Console.WriteLine(GetEducationInfo() + ", Dnia: " + dateToCheck.ToString("dd-MM-yyyy"));
            Console.WriteLine("Nauczyciel: " + GetFullName());

            int x = 1;
            foreach(var uczen in PodwladniUczniowie)
            {
                Console.Write(x + " " + uczen.GetFullName() + " " + uczen.GetGender());
                if (uczen.CanGoAloneToHome()) Console.Write(" - Może wracać sam");
                else Console.Write(" - Nie może wracać sam");
                if (uczen.GetGender() == 'k') Console.Write("a");
                Console.WriteLine();
                x++;
            }
        }
    }
}
