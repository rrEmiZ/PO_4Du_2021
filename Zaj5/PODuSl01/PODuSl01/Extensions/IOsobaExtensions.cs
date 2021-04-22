using PODuSl01.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PODuSl01.Extensions
{
    public static class IOsobaExtensions
    {
      
        public static void WypiszOsoby(this List<IOsoba> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].GetFullName()}");
            }
        }

        // Zadanie 3
        public static void PosortujOsobyPoNazwisku(this List<IOsoba> list)
        {
            var tempList = new List<IOsoba>(list);
            var sortedList = tempList.OrderBy(u => u.LastName);
            list.Clear();
            foreach (var i in sortedList)
                list.Add(i);
        }
    }
}
