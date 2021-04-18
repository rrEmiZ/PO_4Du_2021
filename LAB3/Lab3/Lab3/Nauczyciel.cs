using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Nauczyciel : Uczen
    {
        string TytulNaukowy;

        List<Uczen> PodwladniUczniowie = new List<Uczen>();

        public void WhichStudentCanGoHomeAlone()
        {
            foreach (Uczen item in PodwladniUczniowie)
            {
                if (CanGoAloneToHome())
                {
                    Console.WriteLine(GetFullName());
                }
            }
        }

    }
}
