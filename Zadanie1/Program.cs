using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            Licz ob1 = new Licz(4);
            Licz ob2 = new Licz(2);
        }
    }

    class Licz
    {
        private int i = 0;

        public void Dodaj(int i) { this.i += i; }
        public void Odejmij(int i) { this.i -= i; }
        public void Wartosc() { Console.WriteLine(i.ToString()); }

        public Licz(int i) { this.i = i; }
    }

    class Sumator
    {
        private List<double> liczby = new List<double>();
        
        public double Suma() { return liczby.Sum();}
        public double SumaPodziel3() 
        {
            double zwroc = liczby.Sum()/3;
            return zwroc;
        }
        public int IleElementow() { return liczby.Count(); }
        public void Wypisz()
        {
            foreach (var item in liczby)
            {
                Console.WriteLine(item.ToString());
            }
        }
        //2) e)
        public void DwaParametry(double lowIndex, double highIndex)
        {
            foreach (var item in liczby)
            {
                if (lowIndex <= item && highIndex >= item)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            
        }

        public Sumator()
        {

        }
    }

    class Data
    {
        private int day;
        private int month;
        private int year;

        private void dayBlock(int a) { Console.WriteLine(" dzień: " + (day+a).ToString()); }
        private void monthBlock() { Console.WriteLine(" miesiąc: " + month.ToString()); }
        private void yearBlock() { Console.WriteLine(" rok: " + year.ToString()); }
        //YYYY-MM-DD || MM-DD-YYYY || DD-MM-YYYY
        private void YYYYMMDD(int a)
        {
            yearBlock();
            monthBlock();
            dayBlock(a);
        }
        private void MMDDYYYY(int a)
        {
            monthBlock();
            dayBlock(a);
            yearBlock();
        }
        private void DDMMYYYY(int a)
        {
            dayBlock(a);
            monthBlock();
            yearBlock();
        }
        //nie musze zabezpieczać i sprawdzać czy tydzień nie będzie za duży ani za mały, nie ma nic w poleceniu  
        public Data(string format, int idkCoTo)
        {
            //idkCoTo to jest wykonanie dziwnego polecenia, które każe dodać, albo odjąć tydzień
            int weekPlusOrMinus = -7;
            if (idkCoTo == 0)
                weekPlusOrMinus = 7;
            if (format == "YYYY-MM-DD")
                YYYYMMDD(weekPlusOrMinus);
            else if (format == "MM-DD-YYYY")
            {
                MMDDYYYY(weekPlusOrMinus);
            }
            else
            {
                DDMMYYYY(weekPlusOrMinus);
            }
        }
    }

    class Liczba
    {
        //nie do końca rozumiem polecenia :<
    }
}
