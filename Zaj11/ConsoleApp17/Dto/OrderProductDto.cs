using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17.Dto
{
    public class OrderProductDto
    {
        public int OrderId { get; internal set; }
        public int ItemId { get; internal set; }
        public int ProductId { get; internal set; }
        public int Quantity { get; internal set; }
        public decimal ListPrice { get; internal set; }
        public decimal Discount { get; internal set; }
    }
}
