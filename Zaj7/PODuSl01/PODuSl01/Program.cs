
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PODuSl01
{
    public class SuperException : ApplicationException
    {
        public int Dzielnik { get; set; }

        public SuperException() : base() { }
        public SuperException(string message) : base(message)
        {
        }
        public SuperException(string message, Exception inner, int dzielnik) : base(message, inner)
        {
            Dzielnik = dzielnik;
        }
        public SuperException(string message, int dzielnik) : base(message)
        {
            Dzielnik = dzielnik;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               DzielenieKalkulator(10, 2);
            }
            catch (SuperException supEx)
            {
                Console.WriteLine(supEx.Message + " " + supEx.Dzielnik);
            }
            catch (ApplicationException sysEx)
            {
                Console.WriteLine("Wyjatek aplikacji");
            }
            catch (SystemException sysEx)
            {
                Console.WriteLine("Wyjatek systemowy");
            }
            catch (Exception ex)
            {
        
                Console.WriteLine(ex.Message);
            }



            Console.ReadLine();

        }




        public static int? DzielenieKalkulator(int? a, Nullable<int> b)
        {
            if (!a.HasValue || !b.HasValue)
            {
                throw new SuperException("Jednen z parametrów pusty");
            }

            if (b.Value == 0)
            {
                throw new SuperException("Proba dzielenia przez:", b.Value);
            }

            return a / b;
        }


    }

}
