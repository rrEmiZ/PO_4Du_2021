using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_2
{
    class Licz
    {
        private int wartosc;

        public Licz() { }
        public Licz(int wart)
        {
            wartosc = wart;
        }
        public void Dodaj(int parametr) 
        {
            wartosc += parametr;
        }

        public void Odejmij(int parametr)
        {
            wartosc -= parametr;
        }

        public void PokazStan()
        {
            Console.WriteLine(wartosc);
        }
    }
}
