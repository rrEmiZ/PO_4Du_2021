using System;
using System.Collections.Generic;
using System.Text;

namespace Zaj18.ApiCovid
{
    class Root
    {
        public string ID { get; set; }
        public string Message { get; set; }
        public Global Global { get; set; }
        public List<Countries> Countries { get; set; }
        public DateTime Date { get; set; }
    }
}
