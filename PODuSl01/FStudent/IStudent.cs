using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01.FStudent
{
    public interface IStudent
    {
        int Id { get; set; }
        string Nazwisko { get; set; }
        string Imie { get; set; }
        string NrAlbumu { get; set; }
        string Grupa { get; set; }
    }
}
