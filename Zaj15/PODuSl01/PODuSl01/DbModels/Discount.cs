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


        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }
        public int BrandId { get; set; }


    }
}
