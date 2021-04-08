using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorium3
{
    class Liczba
    {
        private int[] tab;
         
        public Liczba(String arg)
        {
            tab = new int[arg.Length];
            for(int i=0; i < arg.Length; i++)
            {
                this.tab[i] = (int)Char.GetNumericValue(arg, i);
            }
        }
        public void wypisz()
        {
            foreach(int element in tab)
            {
                Console.Write(element.ToString());
            }
            Console.WriteLine();
        }
        public void multiplication(int value)
        {
            String number = "";
            foreach(int element in tab)
            {
                number += element.ToString();
            }
            int result = Int32.Parse(number) * value;

            String resultString = result.ToString();

            if (tab.Length < resultString.Length) {
                tab = new int[resultString.Length];
                Console.WriteLine("Powiekszenie tablicy");
            }
            
            for(int i=0; i<resultString.Length; i++)
            {
                tab[i] = (int)Char.GetNumericValue(resultString, i);
            }
        }

        public void factorial(int value)
        {
            int result = 1;
            for(int i=1; i <= value; i++)
            {
                result = result * i;
            }

            Console.WriteLine(result);
        }

    }
}
