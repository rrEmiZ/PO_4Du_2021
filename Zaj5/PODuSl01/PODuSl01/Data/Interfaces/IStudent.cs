using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01.Data.Interfaces
{
    interface IStudent : IOsoba
    {
        public string Uczelnia { get; set; }
        public string Kierunek{ get; set; }
        public int Rok { get; set; }
        public int Semestr { get; set; }

        public string WypiszPelnaNazweIUczelnie();
    }
}
