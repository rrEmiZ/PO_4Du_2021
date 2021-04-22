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

        public static void WypiszOsoby(this List<IOsoba> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].GetFullName()}");
            }
        }
        public static void PosortujOsobyPoNazwisku(this List<IOsoba> list, SortOrder ord)
        {
            if (ord == SortOrder.asc) list.Sort((p, q) => p.LastName.CompareTo(q.LastName));
            else list.Sort((p, q) => q.LastName.CompareTo(p.LastName));
        }
    }

    public enum SortOrder
    {
        asc,
        desc
    }
}
