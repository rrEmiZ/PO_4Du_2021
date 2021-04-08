using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_2
{
    class Sumator
    {
        private List<int> Liczby = new List<int>();

        public Sumator() { }
        public Sumator(List<int> tab) 
        {
            Liczby = tab;
        }
        public int Suma()
        {
            int sum=0;
            foreach(int liczba in Liczby)
            {
                sum += liczba;
            }
            return sum;
        }
        public double SumaPodziel3()
        {
            return Suma() / 3.0;
        }
        public int IleElementow()
        {
            return Liczby.Count;
        }
        public void PokazLiczby()
        {
            foreach (int liczba in Liczby)
            {
                Console.Write(liczba + " ");
            }
            Console.WriteLine();
        }

        public void PokazLiczbyOdDo(int lowIndex, int highIndex)
        {
            int temp;
            if (lowIndex < 0)
                lowIndex = 0;
            if (highIndex < 0)
                highIndex = 0;
            if (lowIndex >= Liczby.Count)
                lowIndex = Liczby.Count - 1;
            if (highIndex >= Liczby.Count)
                highIndex = Liczby.Count - 1;
            if (highIndex < lowIndex) 
            {
                temp = highIndex;
                highIndex = lowIndex;
                lowIndex = temp;
            }
            for (int i = lowIndex; i <= highIndex; i++)
                Console.Write(Liczby[i] + " ");
            Console.WriteLine();
        }
    }
}
