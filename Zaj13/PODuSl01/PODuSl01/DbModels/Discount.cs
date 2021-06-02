using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PODuSl01.DbModels
{
    public  class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal DicountProcent { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

#nullable enable
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
        public int? ProductId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand? Brand { get; set; }
        public int? BrandId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
    }
}
