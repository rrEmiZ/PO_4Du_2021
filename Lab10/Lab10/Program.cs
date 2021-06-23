using System;
using System.Collections.Generic;
using System.Linq;
using Lab10.Dto;
using Lab10.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab10
{
    class Program
    {
        public static List<ProductDto> GetProductDtos()
        {
            try
            {
                using (var db = new BikeStoresContext())
                {
                    return db.Products.Select(x => new ProductDto()
                    {
                        Id = x.ProductId,
                        Name = x.ProductName,
                        BrandName = x.Brand.BrandName,
                        BrandId = x.BrandId,
                        CategoryName = x.Category.CategoryName,
                        CategoryId = x.CategoryId
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //lab13
        public static List<GetPriceDto> GetPrice(DateTime data)
        {
            try
            {
                using (var db = new BikeStoresContext())
                {
                    return db.Orders.Where(x=>x.OrderDate == data).Select(x => 
                    new GetPriceDto()
                    {
                        OrderId = x.OrderId,
                        ProductId = db.OrderItems.Where(o => o.OrderId == x.OrderId).Select(o => o.ProductId).First(),
                        ProductName = db.Products.Where(p => p.ProductId == db.OrderItems.Where(o => o.OrderId == x.OrderId).Select(o => o.ProductId).First()).Select(x=>x.ProductName).First().ToString(),
                        ListPrice = (decimal)db.OrderItems.Where(o => o.OrderId == x.OrderId).Select(o => o.ListPrice).First(),
                        Discount = (decimal)db.OrderItems.Where(o => o.OrderId == x.OrderId).Select(o => o.Discount).First()
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<OrderDto> GetOrderDtos(int customerID)
        {
            try
            {
                using (var db = new BikeStoresContext())
                {
                    return db.Orders.Where(o => o.CustomerId == customerID).Select(x => 
                    new OrderDto()
                    {
                        OrderId = x.OrderId,
                        CustometID = x.CustomerId,
                        CustomerName = (x.Customer.FirstName + " " + x.Customer.LastName),
                        OrderDate = x.OrderDate,
                        listOfProducts = (List<OrderProductDto>)db.OrderItems.Where(q => q.OrderId == x.OrderId).Select(q => 
                              new OrderProductDto()
                              {
                                  ProductId = q.ProductId,
                                  ProductName = db.OrderItems.Where(x=>x.ProductId == q.ProductId).Select(x => x.Product.ProductName).First().ToString(),
                                  Quantity = q.Quantity,
                                  Price = q.ListPrice,
                              }).ToList()
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<StorDto> GetStorDtos(int StoreID)
        {
            try
            {
                using (var db = new BikeStoresContext())
                {
                    return db.Stores.Where(s => s.StoreId == StoreID).Select(x => new StorDto()
                    {
                        StoreID = x.StoreId,
                        StoreName = x.StoreName,
                        Phone = x.Phone,
                        Email = x.Email,
                        Street = x.Street,
                        City = x.City,
                        listOfProducts = (List<ProductStoreDto>)db.Stocks.Where(q => q.StoreId == x.StoreId).Select(q =>
                             new ProductStoreDto()
                             {
                                 ProductId = q.ProductId,
                                 ProductName = db.Stocks.Where(x => x.ProductId == q.ProductId).Select(x => x.Product.ProductName).First().ToString(),
                                 Quantity = q.Quantity, //(int)db.Stocks.Where(x => x.ProductId == q.ProductId).Select(x => x.Quantity).First(),
                                 Price = db.Stocks.Where(x => x.ProductId == q.ProductId).Select(x => x.Product.ListPrice).First()
                             }).ToList()
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<SellDto> GetSellsDtos(int StaffID, DateTime Start, DateTime End)
        {
            try
            {
                using (var db = new BikeStoresContext())
                {
                    return db.Orders.Where(o => o.StaffId == StaffID && o.OrderDate >= Start && o.OrderDate <= End).Select(x => 
                    new SellDto()
                    {
                           NameOfStaff = db.Staffs.Where(x => x.StaffId == StaffID).Select(x=>(x.FirstName +" "+ x.LastName)).First().ToString(),
                           OrderId = x.OrderId,
                           OrderDate = x.OrderDate,
                           StoreID = x.StoreId,
                           StoreName = db.Staffs.Where(x => x.StaffId == StaffID).Select(x => (x.Store.StoreName)).First().ToString(),
                           listOfProducts = (List<ProductStoreDto>)db.OrderItems.Where(q => q.OrderId == x.OrderId).Select(q =>
                              new ProductStoreDto()
                              {
                                  ProductId = q.ProductId,
                                  ProductName = db.OrderItems.Where(x => x.ProductId == q.ProductId).Select(x => x.Product.ProductName).First().ToString(),
                                  Quantity = q.Quantity,
                                  Price = q.ListPrice,
                              }).ToList()

                    }).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<PersonCountTransationsDto> GetListOfMenagers()
        {
            try
            {
                using (var db = new BikeStoresContext())
                {
                     return db.Staffs.Where(s => s.ManagerId != null).Select(x =>
                     new PersonCountTransationsDto()
                     {
                         MenagerID = (int)x.ManagerId,
                         MenagerName = db.Staffs.Where(o => o.StaffId == x.ManagerId).Select(x => (x.FirstName + " " + x.LastName)).First().ToString(),
                         Name = db.Staffs.Where(o => o.StaffId == x.StaffId).Select(x => (x.FirstName + " " + x.LastName)).First().ToString(),
                         StaffID = x.StaffId,
                         CountTransations = db.Orders.Where(o => o.StaffId == x.StaffId).Count()

                     }).OrderByDescending(d => d.CountTransations).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddOrder(int CustomerID, int orderStatus) { return true; } //?

        static void Main(string[] args)
        {

            /*Console.WriteLine("/////////////////2//////////////");
           int ConsumerId = 4;
           Console.WriteLine($"Zamówienia użytkownika o ID: {ConsumerId}\n");
           var list = GetOrderDtos(ConsumerId);
           foreach (var item in list)
           {
               Console.WriteLine("Zamówienie numer: " + item.OrderId);
               foreach (var items in item.listOfProducts)
               {
                   Console.WriteLine($"Nazwa produktu: {items.ProductName} | Ilość: {items.Quantity} | Cena: {items.Price}");
               }
           }
            Console.WriteLine("/////////////////3//////////////");
            int StoreID = 2;
            Console.WriteLine($"ID sklepu: {StoreID}\n");
            var list2 = GetStorDtos(StoreID);
            foreach (var item in list2)
            {
                Console.WriteLine("Nazwa sklepu " + item.StoreName);
                foreach (var items in item.listOfProducts)
                {
                    Console.WriteLine($"Nazwa produktu: {items.ProductName} | Ilość: {items.Quantity} | Cena: {items.Price}");
                }
                Console.WriteLine($"Ilość produktów: {item.listOfProducts.Count()}"); //313
            }

            Console.WriteLine("/////////////////4//////////////");
            int StaffID = 6, i = 1, suma = 0;
            decimal sumaSprzednaychPrzemiotow = 0;
            DateTime Start = new DateTime(2017, 1, 1);
            DateTime End = new DateTime(2017, 1, 31);

            Console.WriteLine($"ID pacownika: {StaffID} | Data poczatkowa: {Start} | Data końcowa: {End}\n");
            var list3 = GetSellsDtos(StaffID, Start, End);
            foreach (var item in list3)
            {
                Console.WriteLine($"\nSprzedarz nr.{i++}:\nNazwa pracownika: {item.NameOfStaff} | Sklep w którym pracuję: {item.StoreName} | Data sprzedarzy: {item.OrderDate}");
                foreach (var items in item.listOfProducts)
                {
                    Console.WriteLine($"Nazwa produktu: {items.ProductName} | Ilość: {items.Quantity} | Cena: {items.Price}");
                    sumaSprzednaychPrzemiotow += items.Price;
                }
                Console.WriteLine($"Ilość produktów: {item.listOfProducts.Count()}");
                suma += item.listOfProducts.Count();
            }
            Console.WriteLine($"\nSuma sprzedanych produktów: {suma},  za łaczną cene: {sumaSprzednaychPrzemiotow}");
            Console.WriteLine("/////////////////5//////////////");
            var list4 = GetListOfMenagers();
            foreach (var item in list4.Take(1))
            {
                Console.WriteLine($"ID menagera: {item.MenagerID}:{item.MenagerName} | Pracownik: {item.Name} | ID pracownika: {item.StaffID} | Ilość tranzakcji: {item.CountTransations} ");
            }*/
            //Console.WriteLine("/////////////////6//////////////");
            Console.WriteLine("////////LAB13//////");

            var price = GetPrice(new DateTime(2016,1,16));
            foreach(var item in price)
            {
                Console.WriteLine($"\nProduct name == {item.ProductName}\nPrice before discount: {item.ListPrice}\nDiscount: {item.Discount}\nPrice: {item.RealPrice}");
            }
            
        }
    }
}
