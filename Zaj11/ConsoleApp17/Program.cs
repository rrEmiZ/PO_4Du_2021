using ConsoleApp17.Dto;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp17
{
    class Program
    {
        public static List<ProductDto> GetProductDtos()
        {
            try
            {
                using (var ctx = new BikeStoresEntities1())
                {
                    return ctx.products.Select( x => new ProductDto()
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

        public static List<ProductStatsDto> GetProductStats(string StoreName)
        {
            try
            {
                using (var ctx = new BikeStoresEntities1())
                {
                    return ctx.stocks.Where
                    (
                        y => y.store.store_name == StoreName
                    ).Select(x =>
                       new ProductStatsDto()
                       {
                           Id = x.product_id,
                           Name = x.product.product_name,
                           Quantity = x.quantity.Value,
                           StoreName = x.store.store_name
                       }).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static List<OrderDto> GetOrdersSpecificClient(int CustomerId)
        {
            try
            {
                using (var ctx = new BikeStoresEntities1())
                {
                    var OrdersList = ctx.orders.Where(y => y.customer_id == CustomerId)
                        .Select(n =>
                        new OrderDto()
                        {
                            OrderId = n.order_id,
                        }
                        ).ToList();

                    foreach(var item in OrdersList)
                    {
                        var list = ctx.order_items.Where(y => y.order_id == item.OrderId).Select(n =>
                        new OrderProductDto()
                        {
                            Price = n.list_price,
                            ProductId = n.product_id,
                            Quantity = n.quantity
                        }).ToList();

                        foreach (var items in list)
                        {
                            item.OrderProductDtoList.Add(items);
                        }
                        list.Clear();
                    }
                    return OrdersList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<SellOrderDto> GetSells(int StaffId, DateTime Start, DateTime End)
        {
            try
            {
                using (var ctx = new BikeStoresEntities1())
                {
                   return ctx.orders.Where(y => y.staff_id == StaffId)
                        .Select(x => new SellOrderDto() { 
                            CustomerId = (int)x.customer_id,
                            Date = x.order_date,
                            OrderId = x.order_id,
                        }).Where(i => i.Date >= Start && i.Date <= End).ToList();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public static ManagerDto MostEffectiveManager()
        {
            try
            {
                using (var ctx = new BikeStoresEntities1())
                {

                    /*Wybranie z tabeli staffs rekordów oraz 
                     zmapowanie je do obiektu StaffDto */
                    var staff = ctx.staffs.Select(x =>
                        new StaffDto()
                        {
                            Manager_id = x.manager_id,
                            Count = (from p in ctx.orders
                                     where p.staff_id == x.staff_id
                                     select p).Count()
                        });

                    /*Stworzenie nowej listy z posortowanymi i zsumowanymi transakcjami 
                     pracowników danego menadżera
                     */
                    List<StaffDto> newList = staff
                    .Where(x => x.Manager_id != null)
                    .GroupBy(o => o.Manager_id)
                    .Select(i => new StaffDto()
                    {
                        Manager_id = (Nullable<int>)i.Key,
                        Count = (int)i.Sum(x => x.Count)
                    })
                    .OrderByDescending(j => j.Count)
                    .ToList();

                    /*Wyciągnięcie pierwszego rekordu z posortowanej tabeli
                     - zwróci nam id menagera z największą liczbą transakcji dokonanych
                       przez jego pracowników
                     */
                    var item = newList.First().Manager_id;

                    /* Zwrócenie rekordu którego numer id odpowiada id wyżej pobranego 
                     elementu */
                    var managerItem = ctx.staffs.First(x => x.staff_id == item.Value);

                    ManagerDto manager = new ManagerDto()
                    {
                        Email = managerItem.email,
                        Name =  managerItem.first_name,
                        Phone = managerItem.phone,
                        StoreId = managerItem.store_id,
                        Surname = managerItem.last_name
                    };
                    return manager;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AddOrder(int CustomerId, int ShopId, int StaffId, decimal Discount, order obj)
        {
            try {
                using (var ctx = new BikeStoresEntities1())
                {
                    obj.customer_id = CustomerId;
                    obj.store_id = ShopId;
                    obj.staff_id = StaffId;
                    int lastItem = int.Parse(ctx.orders
                             .OrderByDescending(p => p.order_id)
                             .Select(r => r.order_id)
                             .First().ToString());
                   obj.order_id = lastItem + 1;
                   Console.WriteLine(lastItem);

                    var itemList = new List<order_items>();
                    foreach(var item in obj.order_items)
                    {
                        /*Element tymczasowy który wskazuje na produkt o tej samej wartości co item w pętli, 
                         * w tym momencie sprawdzamy czy produkt znajduję się w odpowiedniej ilości w bazie danych oraz czy występuję w danym sklepie
                         w przypadku gdy nie będzie spełniał wymagań produkt nie zostanie dodany do listy która zostanie dodana do orderu */

                        var obj2 = ctx.stocks.Where(x => x.product_id == item.product_id).Where(y=> y.store_id == obj.store_id).First();
                        if (obj2.quantity >= item.quantity)
                        {
                            item.discount = Discount; 
                            item.order_id = obj.order_id;

                            itemList.Add(item);
                            obj2.quantity -= item.quantity;
                        }
                    }

                    obj.order_items = itemList;
                    ctx.orders.Add(obj);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static void Main(string[] args)
        {
            //List<ProductDto> list =  GetProductDtos();

            //Zadanie 1
            /*foreach(var element in list)
            {
                Console.WriteLine(element.Name);
            }*/

            //--------------------------------------------------------------------------------------------------------
            //Zadanie 2

            //Jako argument metody podajemy identyfikator klienta
            int ConsumerId = 1;
            /*var list = GetOrdersSpecificClient(ConsumerId);
            Console.WriteLine($"Zamówienia użytkownika o identyfikatorze {ConsumerId}");
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.WriteLine("Zamówienie numer: " + item.OrderId);

                foreach (var items in item.OrderProductDtoList)
                {
                    Console.WriteLine($"ID produktu: {items.ProductId} - Ilość: {items.Quantity} - Cena: {items.Price}");
                }
                Console.WriteLine();
            }*/

            //--------------------------------------------------------------------------------------------------------
            //Zadanie 3
            /* W zależności od tego jaki sklep 
             podamy jako parametr takie będziemy mieć wyniki produktów i ich stanów*/

            //List<ProductStatsDto> store = GetProductStats("Santa Cruz Bikes");
            //List<ProductStatsDto> store2 = GetProductStats("Baldwin Bikes");
            //List<ProductStatsDto> store3 = GetProductStats("Rowlett Bikes");

            //Wypisanie z poszczególnego sklepu asortymentu
            /*foreach (var element in store)
             {
                 Console.WriteLine($"{ element.Name} - {element.Quantity} - {element.StoreName}");
             }*/

            //--------------------------------------------------------------------------------------------------------
            //Zadanie 4
            DateTime StartDate = new DateTime(2016, 1, 15);
            DateTime EndDate = new DateTime(2016, 1, 20);

            //Jako parametr podajemy identyfikator pracownika oraz date początkową i końcową 
            //var Sells = GetSells(2, StartDate, EndDate);

            /*wypisanie kilku danych z rekordów zamówień danego pracownika w określonym czasie
            Wypisze nam id obsługiwanego klienta, date zamówienia i id orderu który obsługiwał pracownik o id 2*/

            /*foreach (var items in Sells)
            {
                Console.WriteLine($"{items.CustomerId} {items.Date.ToString("yyyy/MM/dd")} {items.OrderId} ");
            }*/

            //--------------------------------------------------------------------------------------------------------

            //Zadanie 5
            var manager =  MostEffectiveManager();
            /*Console.WriteLine("Najbardziej " +
                "efektywny menadżer którego pracownicy wykonali największą ilość transakcji :");
            Console.WriteLine($"Imie: {manager.Name}");
            Console.WriteLine($"Nazwisko: {manager.Surname}");
            Console.WriteLine($"Email: {manager.Email}");
            Console.WriteLine($"Telefon: {manager.Phone}");*/

            //--------------------------------------------------------------------------------------------------------
            //Zadanie 6

            //Przykładowa definicja zamówienia
            order NewOrder = new order
            {
                customer_id = 0,
                order_id = 0,
                order_status = 1,
                order_date = new DateTime(2018, 06, 17),
                required_date = new DateTime(2018, 06, 17),
                shipped_date = null,
                store_id = 1,
                staff_id = 1,

                order_items = {
                    new order_items
                    {
                        order_id = 1,
                        item_id = 1,
                        discount = 0,
                        list_price = 599.99m,
                        quantity = 1,
                        product_id = 20
                    }, 
                }
            };
            
            /*Podajemy nowe zamówienie w którym id klienta wynosi 600, id sklepu 1, 
            id zalogowanego pracownika 8 a zniżka wynosi 0.25, po skończonej operacji metoda zaaktualizuję 
            ilość produktów które zostały zakupione*/
            //AddOrder(600, 1, 8, 0.25m, NewOrder);

            Console.ReadLine();
        }
    }
}
