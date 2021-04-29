using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PODuSl01
{
    class Zad3
    {
        List<string> listaPeseli;
        int counter;
        public Zad3()
        {
            listaPeseli = new List<string>();
            counter = 0;
        }
        public void IleKobiet(string plikTekstowy)
        {            
            using (var sr = new StreamReader(plikTekstowy))
            {                
                var line = sr.ReadLine();
                while (line != null)
                {
                    line = sr.ReadLine();
                    listaPeseli.Add(line);                    
                }
            }

            for(int i = 0; i < listaPeseli.Count-1;i++)
            {
                
                char _10thNumber = listaPeseli[i][9];
                if (_10thNumber % 2 == 0)
                {
                    counter++;
                }
            }
            Console.WriteLine($"Z {listaPeseli.Count} osób na liście, jest {counter} kobiet");
        }
       
            
    }
}
