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

        static void Main(string[] args)
        {
           
            using(var db = new DbModels.BikeStoresContext())
            {
                // var brands = db.Brands.Include(x => x.Products).ToList();

                // var products = db.Products.Include(x => x.Brand).Include(x => x.Category).ToList();


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


            Console.ReadLine();

        }

      
    }

}
