using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01.Data.Interfaces
{
    public interface IStudent : IOsoba
    {
        // Uczelnia, Kierunek, Rok, Semestr
        string Uczelnia { get; set; }
        string Kierunek { get; set; }
        int Rok { get; set; }
        int Semestr { get; set; }
        string WypiszPelnaNazweIUczelnie();
    }
}
