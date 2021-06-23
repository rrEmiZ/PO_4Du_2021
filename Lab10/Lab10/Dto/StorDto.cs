using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.Dto
{
    class StorDto
    {
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public List<ProductStoreDto> listOfProducts { get; set; }
    }
}
