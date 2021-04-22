using PODuSl01.Data.Interfaces;
using PODuSl01.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        public static void WypiszOsoby(this List<StudentWSIiZ> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].WypiszPelnaNazweIUczelnie());
            }
        }
        public static void PosortujOsobyPoNazwisku(this List<IOsoba> list)
        {
            var newList = list.OrderBy(x => x.LastName).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {newList[i].GetFullName()}");
            }
        }

    }
}
