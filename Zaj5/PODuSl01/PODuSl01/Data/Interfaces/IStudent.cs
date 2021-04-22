using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01.Data.Interfaces
{
    public interface IStudent : IOsoba
    {
        string Uczelnia { get; set; }

        string Kierunek { get; set; }
        int Rok { get; set; }
        string Semestr { get; set; }

        string WypiszPelnaNazweIUczelnie();
    }
}
