using System;
using System.Collections.Generic;

namespace Lab3
{
    class Nauczyciel : Uczen {
        String tytulNaukowy;
    List<Uczen> podwladniUczniowie = new List<Uczen>();

    public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
    {
        Console.WriteLine(this.szkola + " Dnia : " + dateToCheck.ToString());
        Console.WriteLine("Nauczyciel: " + this.tytulNaukowy + " " + this.imie + " " + this.nazwisko);
        Console.WriteLine("Lista studentów: ");

        List<Uczen> canGo = new List<Uczen>();
        for (int i = 0; i < podwladniUczniowie.Count; i++)
        {
            Uczen tmp = podwladniUczniowie[i];
            Console.WriteLine(i.ToString() + ". " + tmp.imie + " " + tmp.nazwisko + " - " + tmp.getGender() + " - ");
            if (tmp.getAge(dateToCheck) < 12 && tmp.getPerm())
            {
                Console.Write("NIE Brak pozwolenia lub wiek poniżej 12 lat");
            }
            else
            {
                Console.Write("TAK");
            }
        }
    }
}
}
