using System;

namespace Laboratorium3
{
    class Program
    {

        static void Main(string[] args)
        {
            Licz obj = new Licz(10);
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };
            Sumator obj2 = new Sumator(numbers);
            Console.WriteLine("Suma podzielnych przez 3: " + obj2.SumaPodziel3());
            Console.WriteLine("ilość elementów: " + obj2.IleElementów());
            obj2.wypiszWybrane(0, 2);
            obj2.wypiszWszystkie();

            MyDate obj3 = new MyDate();
            obj3.getNowDate();
            obj3.substract7DaysBefore();
            obj3.getNowDate();
            obj3.add7Days();
            obj3.add7Days();
            obj3.getNowDate();

            // Aby podać wybrany przez nas format daty należy sprawdzić w niżej zamieszczonej dokumentacji
            // zbiór możliwych do wpisania niestandardowych ciągów formatujących date.
            // https://docs.microsoft.com/pl-pl/dotnet/standard/base-types/custom-date-and-time-format-strings
            obj3.getDateWithSpecificFormat("dd MM yyyy");

            Liczba obj4 = new Liczba("50");
            obj4.wypisz();
            obj4.multiplication(1);
            obj4.wypisz();

            //Silnia
            obj4.factorial(5);
        }
    }
}
