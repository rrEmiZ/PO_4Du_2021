using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17.Dto
{
    class OrderDto
    {
       public int OrderId { get; set; }
       public List<OrderProductDto> OrderProductDtoList = new List<OrderProductDto>();
    }
}
