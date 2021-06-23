using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.Dto
{
    class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        //zaj13
        public DateTime OrderDate { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
