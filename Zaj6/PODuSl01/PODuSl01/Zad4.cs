using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PODuSl01
{
    class Zad4
    {
        public class Indicator
        {
            public string id { get; set; }
            public string value { get; set; }
        }

        public class Country
        {
            public string id { get; set; }
            public string value { get; set; }
        }

        public List<Zad4> listaPanstw;
        public Indicator indicator { get; set; }
        public Country country { get; set; }
        public string value { get; set; }
        public string @decimal { get; set; }
        public string date { get; set; }

        public void DoListy(string NazwaPlikuJson)
        {
            using (var sr = new StreamReader(NazwaPlikuJson))
            {
                var json = sr.ReadToEnd();

                listaPanstw = JsonConvert.DeserializeObject<List<Zad4>>(json);
            }
        }
        public void Zad4A()
        {
            PorownajPopulacje("1970", "2000", "India");
        }
        public void Zad4B()
        {
            PorownajPopulacje("1965", "2010", "United States");
        }
        public void Zad4C()
        {
            PorownajPopulacje("1980", "2018", "China");
        }
        //Zad4D
        public void  WyswietlPopulacje(string rok, string panstwo)
        {
            int populacja = 0;
            for (int i = 0; i < listaPanstw.Count - 1; i++)
            {
                if (listaPanstw[i].country.value == panstwo && listaPanstw[i].date == rok)
                {
                    populacja = Int32.Parse(listaPanstw[i].value);
                }

            }
            Console.WriteLine($"Populacji w państwie {panstwo} w roku {rok} wynosi {populacja} osób");            
        }

        //Zad4E
        
        public void PorownajPopulacje(string rok1, string rok2, string panstwo)
        {
            int populacja1 = 0;
            int populacja2 = 0;
            for(int i=0; i < listaPanstw.Count-1;i++)
            {
                if (listaPanstw[i].country.value == panstwo && listaPanstw[i].date == rok1)
                {
                    populacja1 = Int32.Parse(listaPanstw[i].value);
                }
                if (listaPanstw[i].country.value == panstwo && listaPanstw[i].date == rok2)
                {
                    populacja2 = Int32.Parse(listaPanstw[i].value);
                }
                               
            }
            Console.WriteLine($"Rożnica w populacji w państwie {panstwo} między latami {rok1} i {rok2} wynosi {Math.Abs(populacja1 - populacja2)} osób");
        }

        //Zad4F
        public int ZwrocPopulacje(string rok, string panstwo)
        {
            int populacja = 0;
            for (int i = 0; i < listaPanstw.Count - 1; i++)
            {
                if (listaPanstw[i].country.value == panstwo && listaPanstw[i].date == rok)
                {
                    populacja = Int32.Parse(listaPanstw[i].value);
                }

            }
            return populacja;
        }
        public void ProcWzorst(string rok)
        {
            List<string> lista = new List<string>();
            for (int i = 0; i < listaPanstw.Count; i++)
            {
                if (!lista.Contains(listaPanstw[i].country.value))
                {
                    lista.Add(listaPanstw[i].country.value);
                }
            }
            Console.WriteLine($"Procentowy wzrost populacji w roku {rok} wzlędem roku poprzedniego wynosi:");
            for (int i = 0; i < lista.Count; i++)
            {
               float procenty = (((float)ZwrocPopulacje(rok, lista[i]) - (float)ZwrocPopulacje((Int32.Parse(rok) - 1).ToString(), lista[i])) / (float)ZwrocPopulacje((Int32.Parse(rok) - 1).ToString(), lista[i]))*100f ;
                Console.WriteLine($"W {lista[i]}: {procenty}%");                  
                
            }
        }
        
    }
}
