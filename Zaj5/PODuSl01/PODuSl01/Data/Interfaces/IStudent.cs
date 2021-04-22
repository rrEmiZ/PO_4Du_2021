using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01.Data.Interfaces
{
    public interface IStudent : IOsoba
    {
        string Uczelnia { get; set; }
        string Kierunek { get; set; }
        string Semester { get; set; }
        int year { get; set; }
        string WriteFullNameCollage();
    }
}
