using System;
using System.Collections.Generic;
using System.Text;
public static class Extensions
{
    public static int findIndex<T>(this T[] array, T item)
    {
        return Array.IndexOf(array, item);
    }
}

namespace Laboratorium3
{
    class Sumator
    {
        private int[] numbers;

        public Sumator(int[] arg)
        {
            numbers = new int[arg.Length];
            numbers = arg;
        }
        public int Suma()
        {
            int total = 0;
            foreach(int element in numbers)
            {
                total += element;
            }
            return total;
        }
        public int SumaPodziel3()
        {
            int total = 0;
            foreach (int element in numbers)
            {
                if(element % 3 == 0)
                {
                    total += element;
                }
            }
            return total;
        }
        public int IleElementów()
        {
            return numbers.Length;
        }
        public void wypiszWszystkie()
        {
            foreach (int element in numbers)
            {
                Console.Write(element);
            }
            Console.WriteLine();
        }

        public void wypiszWybrane(int lowIndex, int highIndex)
        {
            foreach (int element in numbers)
            {
                int index = numbers.findIndex(element);
                if(index >= lowIndex && index <= highIndex)
                {
                    Console.WriteLine(element);
                }

            }
        }
    }
}
