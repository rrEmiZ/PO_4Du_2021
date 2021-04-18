using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Nauczyciel : Uczen
    {
        public string TytulNaukowy { get; set; }
        public List<Uczen> PodwladniUczniowie;

        public Nauczyciel(string imie, string nazwisko, string szkola, string pesel, string tytul)
            : base(imie, nazwisko, szkola, pesel)
        {
            TytulNaukowy = tytul;
            PodwladniUczniowie = new List<Uczen>();
        }

        public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
        {
            foreach (Uczen u in PodwladniUczniowie)
            {
                if (u.CanGoAloneHome(dateToCheck))
                {
                    Console.WriteLine(u.GetFullName());
                }
            }
        }
    }
}
