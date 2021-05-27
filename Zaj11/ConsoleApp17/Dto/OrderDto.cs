using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17.Dto
{
    public class OrderDto
    {
        public int Id { get;  set; }
        public int? CustomerId { get;  set; }
        public byte OrderStatus { get;  set; }
        public DateTime OrderDate { get;  set; }
        public DateTime RequiredDate { get;  set; }
        public DateTime? ShippedDate { get;  set; }
        public int StoreId { get;  set; }
        public int StaffId { get;  set; }

        public IQueryable<OrderProductDto> OrderItems { get; set; }
    }
}
