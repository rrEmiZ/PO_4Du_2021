using System;
using System.Collections.Generic;
using System.Text;
using PODuSl01.Data;

namespace PODuSl01.Extensions
{
    public static class  StudentExtensions
    {
        public static string  WypiszPelnaNazweIUczelnie(this StudentWSIiZ stw )
        {
            var uczen = $"{stw.FirstName} {stw.LastName} - {stw.Semestr}{stw.Kierunek} {stw.Rok} {stw.Uczelnia}";
            Console.WriteLine(uczen);
            return uczen;
        }
    }
}
