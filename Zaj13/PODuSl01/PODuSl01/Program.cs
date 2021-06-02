using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Linq;
using PODuSl01.DbModels;
using Microsoft.EntityFrameworkCore;

namespace PODuSl01
{
    class Program
    {
        public class NoEntryFound : Exception
        {
            public NoEntryFound(string message)
                : base(message)
            {
            }
        }

        public static decimal GetProducts(int ProductId, DateTime date)
        {
            using (var ctx = new BikeStoresContext())
            {
                var product = ctx.Products.FirstOrDefault(p => p.ProductId == ProductId);
                if (product == null) throw new NoEntryFound("Nie znaleziono produktu");
                var discount = GetDiscount(product, DateTime.Now);
                if (discount == null) return product.ListPrice;
                else return product.ListPrice - discount.DicountProcent * product.ListPrice;
            }
        }

        public static Discount GetDiscount(Product product, DateTime date)
        {
            var discount = new Discount();

            using (var ctx = new BikeStoresContext())
            {
                discount = ctx.Discounts.FirstOrDefault(
                d => d.ProductId == product.ProductId &&
                d.DateFrom <= date && d.DateTo >= date);
                if (discount != null) return discount;

                discount = ctx.Discounts.FirstOrDefault(
                d => d.BrandId == product.BrandId &&
                d.DateFrom <= date && d.DateTo >= date);
                if (discount != null) return discount;

                discount = ctx.Discounts.FirstOrDefault(
                d => d.CategoryId == product.CategoryId &&
                d.DateFrom <= date && d.DateTo >= date);
                if (discount != null) return discount;
            }
            return null;
        }

        static void Main(string[] args)
        {
           
            using(var db = new DbModels.BikeStoresContext())
            {
                // var brands = db.Brands.Include(x => x.Products).ToList();

                // var products = db.Products.Include(x => x.Brand).Include(x => x.Category).ToList();

                //db.Discounts.Add(new Discount
                //{
                //    Name = "Znizka pracownicza",
                //    DicountProcent = 0.05m,
                //    DateFrom = DateTime.Now.AddDays(-5),
                //    DateTo = DateTime.Now.AddDays(5),
                //    ProductId = 1
                //});

                //db.Discounts.Add(new Discount
                //{
                //    Name = "Znizka 1000+",
                //    DicountProcent = 0.1m,
                //    DateFrom = DateTime.Now.AddDays(-5),
                //    DateTo = DateTime.Now.AddDays(5),
                //    CategoryId = 5
                //});

                //db.Discounts.Add(new Discount
                //{
                //    Name = "Znizka brand+",
                //    DicountProcent = 0.1m,
                //    DateFrom = DateTime.Now.AddDays(-5),
                //    DateTo = DateTime.Now.AddDays(5),
                //    BrandId = 5
                //});

                //db.SaveChanges();

                var discounts = db.Discounts.ToList();


                //using (var transaction = db.Database.BeginTransaction( isolationLevel: IsolationLevel.ReadCommitted))
                //{

                //    var brand = new Brand()
                //    {
                //        BrandName = "Testowy"
                //    };

                //    db.Brands.Add(brand);

                //    db.SaveChanges();


                //    var prod = new Product()
                //    {
                //        BrandId = brand.BrandId
                //    };


                //   // int zero = 0;

                //   // var result = 10 / zero;


                //    transaction.Commit();
                //}


                ///db.Products.up
            }

            var priceAfterDiscount1 = GetProducts(1, DateTime.Now);
            var priceAfterDiscount2 = GetProducts(2, DateTime.Now);
            var priceAfterDiscount3 = GetProducts(9, DateTime.Now);
            var priceAfterDiscount4 = GetProducts(3, DateTime.Now);
            Console.ReadLine();
        }
    }
}
