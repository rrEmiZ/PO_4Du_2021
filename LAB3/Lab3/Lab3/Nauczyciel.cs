using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Nauczyciel : Uczen
    {
        public string TytulNaukowy { get; set; }
        public List<Uczen> PodwladniUczniowie = new List<Uczen>();
        public Nauczyciel() : base()
        {

        }
        public Nauczyciel(string Imie, string Nazwisko, string Pesel, string Szkola, string TytulNaukowy ) : base(Imie, Nazwisko, Pesel, Szkola)
        {
            this.TytulNaukowy = TytulNaukowy;
        }
        public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
        {
            Console.WriteLine(Szkola + " Dnia: " + dateToCheck);
            Console.WriteLine(TytulNaukowy + " " + Imie + " " + Nazwisko);
            Console.WriteLine("Lista studentów:");
            int numer = 1;
            foreach(Uczen item in PodwladniUczniowie)
            {
                Console.WriteLine(numer + ". " + item.Imie + " " + item.Nazwisko
                    + " - " + item.GetGender() + " - " + item.CanGoAloneRoHome()
                    + " - " + item.Reasoning());
                numer++;
            }

        }
    }
}
