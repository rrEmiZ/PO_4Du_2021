using PODuSl01.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01.Extensions
{
    public static class IOsobaExtensions
    {
        //public static string GetFullName(this IOsoba osoba)
        //{
        //    return $"{osoba.FirstName} {osoba.LastName}";
        //}

        public static void WypiszOsoby(this List<IStudent> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].WypiszPelnaNazweIUczelnie());
            }
        }
        public static void WypiszOsoby(this List<IOsoba> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].GetFullName()}");
            }
        }

        public static void PosortujOsobyPoNazwisku(this List<IOsoba> list)
        {
            list.Sort((IOsoba x, IOsoba y) => string.Compare(x.LastName, y.LastName));
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].GetFullName()}");
            }
        }

    }
}
