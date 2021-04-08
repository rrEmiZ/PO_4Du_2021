using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_2
{
    class Data
    {
        private DateTime data;

        public void WczyajDatuTeraz()
        {
            data = DateTime.Now;
        }
        public void DodajTydzien()
        {
            data = data.AddDays(7);
        }
        public void OdejmijTydzien()
        {
            data = data.AddDays(-7);
        }
        public void PokazDatuWFormacie(String str)
        {
            Console.WriteLine( data.ToString(str));
        }
    }
}
