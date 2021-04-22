using PODuSl01.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using PODuSl01.Data;

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

        public static void SortByLastName(this List<IOsoba> list)
        {
            list.Sort((x, y) => string.Compare(x.LastName, y.LastName));
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].GetFullName()}");
            }
        }

        public static void WypiszOsoby(this List<IStudent> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].WriteFullNameCollage());
            }
        }



    }
}
