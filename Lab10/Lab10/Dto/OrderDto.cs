using Lab10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab10.Dto
{
    class OrderDto
    {
        
        public int OrderId { get; set; }
        public int? CustometID { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderProductDto> listOfProducts { get; set; }
    }
}
