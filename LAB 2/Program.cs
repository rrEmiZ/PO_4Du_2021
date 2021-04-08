using System;
using System.Collections.Generic;


namespace LAB_2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Dzialanie klasy Licz
            Licz piec = new Licz(5);
            piec.PokazStan();
            piec.Dodaj(3);
            piec.PokazStan();
            piec.Odejmij(2);
            piec.PokazStan();
            Console.WriteLine();

            // Dzialanie klasy Sumator
            Sumator sumat = new Sumator(new List<int> {0,1,2,3,4,5,6,7,8,9,10});
            Console.WriteLine(sumat.Suma());
            Console.WriteLine(sumat.SumaPodziel3());
            Console.WriteLine(sumat.IleElementow());
            sumat.PokazLiczby();
            sumat.PokazLiczbyOdDo(-1, 4);
            sumat.PokazLiczbyOdDo(5, 17);
            sumat.PokazLiczbyOdDo(8, 3);
            Console.WriteLine();

            //Dzialanie klasy Data
            Data data = new Data();
            data.WczyajDatuTeraz();
            data.PokazDatuWFormacie("dd-MM-yyyy ");
            data.DodajTydzien();
            data.PokazDatuWFormacie("dd-MM-yyyy ");
            data.OdejmijTydzien();
            data.PokazDatuWFormacie("dd-MM-yyyy ");
        }
    }
}
