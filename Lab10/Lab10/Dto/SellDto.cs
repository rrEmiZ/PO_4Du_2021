using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.Dto
{
    class SellDto
    {
        public string NameOfStaff { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public List<ProductStoreDto> listOfProducts { get; set; }
    }
}
