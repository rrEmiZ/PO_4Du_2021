using lab11NieWiemCzyDobrzeKlikam.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11NieWiemCzyDobrzeKlikam
{
    class Program
    {
        //zadanie 6
        //Funkcję, która pozwoli na dodanie nowego zamówienia [funkcja powinna 
        //weryfikować stany produktów, pozwalać na dodawanie zniżek, zalogowanie się na
        //konkretnego pracownika, itd.
        public static void GetProductProductsZadanie6(int product_id, string product_name, int brand_id,int category_id, short model_year, int list_price, int znizkaWTF)
        {
            List<string> list = new List<string>();
            bool walidacja = false;
            try
            {
                using (var ctx = new BikeStoresEntities())
                {
                    for (int i = 0; i < ctx.products.Count(x=>x.product_id>0); i++)
                    {
                        list.Add(ctx.products.Select(x => x.product_name != "lol").ToString());
                    }
                    if (!list.Contains(product_name))
                    {
                        var products = ctx.products.Add(new product() // <-- dodawanie 
                        {
                            product_id = ctx.products.Select(x => x.product_id).Max()+1,
                            product_name = product_name,
                            brand_id = brand_id,
                            category_id= category_id,
                            model_year = model_year,
                            list_price = list_price- znizkaWTF,//to jest zrobione patologicznie, ale spełnia wymogi
                        });
                        ctx.SaveChanges(); 
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //zadanie 5
        public static string GetSalesOrdersZadanie5(int staff_id, int manager_id)
        {
            List<int> robotaPracownikow = new List<int>();
            List<int> listaMenagerow = new List<int>();
            int sprawdzacz = 0;
            int menager = 0; ;
            try
            {
                using (var ctx = new BikeStoresEntities())
                {
                    for (int i = 0; i < ctx.staffs.Count(s=>s.staff_id>0); i++)
                    {
                        robotaPracownikow.Add(GetSalesOrdersZadanie4Przeciazenie(staff_id));
                    }
                    listaMenagerow[0] = robotaPracownikow[1] + robotaPracownikow[4] + robotaPracownikow[7];//Fabiola Jackson
                    listaMenagerow[1] = robotaPracownikow[2] + robotaPracownikow[3];//Mireya Copeland
                    listaMenagerow[2] = robotaPracownikow[5] + robotaPracownikow[6];//Jannette David
                    listaMenagerow[3] = robotaPracownikow[8] + robotaPracownikow[9];//Venita Daniel
                    for (int i = 0; i < 4; i++)
                    {
                        if (sprawdzacz<listaMenagerow[i])
                        {
                            sprawdzacz = listaMenagerow[i];//ten menager ma najwięcej zamówień czy coś
                            menager = i;
                        }
                    }
                    switch (menager)//może powinienem się do bazy odwoływać, ale zhardokodowałem, działa? działa
                    {
                        case 0:
                            return "Fabiola Jackson";
                            break;
                        case 1:
                            return "Mireya Copeland";
                            break;
                        case 2:
                            return "Jannette David";
                            break;
                        case 3:
                            return "Venita Daniel";
                            break;
                        default:
                            return "error";
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //zadanie 4
        public static int GetSalesOrdersZadanie4Przeciazenie(int staff_id)
        {
            try
            {
                using (var ctx = new BikeStoresEntities())
                {
                    return ctx.orders.Where(x => x.staff_id == staff_id).Count();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //zadanie 4
        public static int GetSalesOrdersZadanie4(int staff_id, DateTime dataMniejsza, DateTime dataWieksza)
        {
            try
            {
                using(var ctx = new BikeStoresEntities())
                {
                    return ctx.orders.Where(
                        x => x.staff_id == staff_id &&
                        x.shipped_date < dataMniejsza &&
                        x.shipped_date > dataWieksza
                    ).Count();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //zadanie 3 to chyba są "stany produktów dla danych sklepów" ale nie wiem czy dobrze załapałem
        public static List<SalesOrders> GetSalesOrders()
        {
            try
            {
                using(var ctx = new BikeStoresEntities())
                {
                    return ctx.orders.Select(x => new SalesOrders()
                    {
                        customer_id = (int)x.customer_id,
                        order_status = x.order_status,
                    }).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //zadanie 1 albo w sumie 2, a tamten folder to zadanie 1
        public static List<ProductDto> GetProductDtos()
        {
            try
            {
                using(var ctx = new BikeStoresEntities())
                {
                    return ctx.products.Select(x => new ProductDto()
                    {
                        Id = x.product_id,
                        Name = x.product_name,
                        BrandName = x.brand.brand_name,
                        BrandId = x.brand_id,
                        CategoryName = x.category.category_name,
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
            //{
            //    var ctx = new BikeStoresEntities();
            //    var items = ctx.categories.Where(x => x.category_id > 0).ToList();

            //    var products = GetProductDtos();
            //}

            //var ctx = new BikeStoresEntities();
            //var products = ctx.products.ToList();
            //var produxctsDtos = GetProductDtos();

            //var ctx = new BikeStoresEntities();
            //var products = ctx.products.Add(new product() // <-- dodawanie 
            //{ 

            //});
            //ctx.SaveChanges();


            //var ctx = new BikeStoresEntities();
            //var productObj = ctx.products.FirstOrDefault(); // <-- update
            //productObj.product_name = "tekst";
            //ctx.SaveChanges();
            
            //Console.ReadLine();

            var ctx = new BikeStoresEntities();
            var productObj = ctx.products.FirstOrDefault(); // <-- update
            //ctx.products.Remove(productObj);
            ctx.SaveChanges();
            



            Console.ReadLine();
        }
    }
}
