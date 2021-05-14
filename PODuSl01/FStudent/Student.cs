using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01.FStudent
{
    public class Student : IStudent
    {
        public int Id { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string NrAlbumu { get; set; }
        public string Grupa { get; set; }
    }
}
