using ConsoleApp17.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    class Program
    {
        public static List<ProductDto> GetProductDtos()
        {
            try
            {
                using (var ctx = new BikeStoresEntities())
                {
                    return ctx.products.Select(x => new ProductDto()
                    {
                        Id = x.product_id,
                        Name = x.product_name,
                        BrandName = x.brand.brand_name,
                        BrandId = x.brand_id,
                        CategoryName =  x.category.category_name,
                        CategoryId = x.category_id
                    }).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        static void Main(string[] args)
        {
            var ctx = new BikeStoresEntities();
            //var productObj = ctx.products.FirstOrDefault();

            //ctx.products.Remove(productObj);

            //ctx.SaveChanges();

            //              var productDtos = GetProductDtos();

            var orders = ctx.orders.FirstOrDefault();


            orders.



            Console.ReadLine();
        }
    }
}
