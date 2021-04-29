using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PODuSl01
{
    class Zad1
    {
        readonly string mojAlbum = "w61902";
        public void zapiszAlbum()
        {
            using (var sw = new StreamWriter("mojAlbum.txt"))
            {
                sw.WriteLine(mojAlbum);
            }
        }
        public void WypiszAlbum()
        {
            using (var sr = new StreamReader("mojAlbum.txt"))
            {
                var line = sr.ReadToEnd();
                Console.WriteLine(line);
            }
        }
    }
}
