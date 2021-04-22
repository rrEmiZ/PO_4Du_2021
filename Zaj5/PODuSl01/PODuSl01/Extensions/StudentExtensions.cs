using System;
using System.Collections.Generic;
using System.Text;
using PODuSl01.Data;

namespace PODuSl01.Extensions
{
    public static class StudentExtensions
    {
        public static string WypiszPelnaNazweIUczelnie(this StudentWSIiZ s)
        {
            var str = $"{s.FirstName} {s.LastName} - {s.Semestr}{s.Kierunek} {s.Rok} {s.Uczelnia}";
            Console.WriteLine(str);
            return str;
        }
    }
}
