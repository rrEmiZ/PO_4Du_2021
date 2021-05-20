using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17.Dto
{
    public class ProductDto
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string BrandName { get;  set; }
        public int BrandId { get;  set; }
        public string CategoryName { get;  set; }
        public int CategoryId { get;  set; }
    }
}
