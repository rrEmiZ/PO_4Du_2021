using PODuSl01.Data.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01.Extensions
{
    public static class IOsobaExtensions
    {

        public static void PosortujOsobyPoNazwisku(this List<IOsoba> list)
        {
            list.Sort((x, y) => string.Compare(x.LastName, y.LastName));

        }

        // działa jeżeli nie ma powtórzeń inaczej wywala wyjątek bo w sorted list nie mogą powtarzać się klucze, ale zostawiam :)
        /*public static void PosortujOsobyPoNazwisku(this List<IOsoba> list)
          {
              SortedList sorted = new SortedList();

              for (int i = 0; i < list.Count; i++)
              {
                  int count = 0;
                  for (int j = 0; j < list.Count; j++)
                  {

                      int compare = String.Compare(list[j].LastName, list[i].LastName, StringComparison.InvariantCulture);
                      if (compare < 0)
                      {
                          count++;

                      }
                      else
                      {
                          continue;
                      }
                  }

                  sorted.Add(count, list[i]);

              }
              for (int i = 0; i < list.Count; i++)
              {
                  list[i] = (IOsoba)sorted[i];
              }
          }*/
        public static void WypiszOsoby(this List<IOsoba> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].GetFullName()}");
            }
        }
        public static void WypiszOsoby(this List<IStudent> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].WypiszPelnaNazweIUczelnie()}");
            }
        }

    }
}
