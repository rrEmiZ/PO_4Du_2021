﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.Dto
{
    class OrderProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
