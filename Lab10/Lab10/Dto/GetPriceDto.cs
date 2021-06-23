using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.Dto
{
    public class GetPriceDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal RealPrice => ListPrice - (Discount * ListPrice);
    }
}
