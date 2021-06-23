using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11NieWiemCzyDobrzeKlikam.Dto
{
    class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public int product_name { get; set; }
    }
    class SalesOrders
    {
        public int customer_id { get; set; }
        public int order_status { get; set; }
    }
    class SalesStaff
    {
        public int first_name { get; set; }
        public int last_name { get; set; }
        public int email { get; set; }
    }
}
