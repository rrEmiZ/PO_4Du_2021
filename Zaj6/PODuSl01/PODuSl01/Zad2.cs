using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PODuSl01
{
    class Zad2
    {
        public void WypiszPlik(string plikTekstowy)
        {
            using (var sr = new StreamReader(plikTekstowy))
            {
                var line = sr.ReadToEnd();
                Console.WriteLine(line);
            }
        }
    }
}
