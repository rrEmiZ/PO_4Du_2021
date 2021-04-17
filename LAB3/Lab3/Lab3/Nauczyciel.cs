using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Nauczyciel : Uczen
    {
        public String TytulNaukowy { get; private set; }
        public List<Uczen> uczniowie = new List<Uczen>();
        public Nauczyciel(string TytulNaukowy, List<Uczen> uczniowie, String szkola, String imie, String nazwisko, String pesel) : 
            base(szkola, imie, nazwisko, pesel) {
            this.TytulNaukowy = TytulNaukowy;
            this.uczniowie = uczniowie;
        }

        public void WhichStudentCanGoHomeAlone(DateTime dateToCheck) {

            List<Uczen> canGoHomeAlone = new List<Uczen>();
            foreach(Uczen element in uczniowie)
            {
                if(element.getAge(dateToCheck) >= 12 )
                {
                    canGoHomeAlone.Add(element);
                }
            }

            foreach(Uczen element in canGoHomeAlone)
            {
                Console.WriteLine(element.Imie + " " + element.Nazwisko);
            }
        }
    }
}
