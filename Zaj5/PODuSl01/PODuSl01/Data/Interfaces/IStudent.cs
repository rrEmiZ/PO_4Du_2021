using System;
namespace PODuSl01.Data.Interfaces
{
    public interface IStudent : IOsoba
    {
        string Uczelnia { get; set; }
        string Kierunek { get; set; }
        string Rok { get; set; }
        string Semestr { get; set; }
    }
}
