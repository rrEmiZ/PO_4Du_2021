using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorium3
{
    class Licz
    {
        private int value = 0;
        public void Dodaj(int param)
        {
            value += param;
        }
        public void Odejmij(int param)
        {
            value -= param;
        }
        public Licz(int arg)
        {
            value = arg;
        }
        public void wypisz()
        {
            Console.WriteLine("Wartość: " + value);
        }
    }
   
}
