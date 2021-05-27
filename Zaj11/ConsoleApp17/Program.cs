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
            using (var ctx = new BikeStoresEntities())
            {
                return ctx.products.Select(x => new ProductDto()
                {
                    Id = x.product_id,
                    Name = x.product_name,
                    BrandId = x.brand_id,
                    CategoryId = x.category_id,
                    ModelYear = x.model_year,
                    ListPrice = x.list_price
                }).ToList();
            }
        }

        public static ProductDto GetProductDtos(int productId)
        {
            using (var ctx = new BikeStoresEntities())
            {
                return ctx.products.Where(p => p.product_id == productId).Select(x => new ProductDto()
                {
                    Id = x.product_id,
                    Name = x.product_name,
                    BrandId = x.brand_id,
                    CategoryId = x.category_id,
                    ModelYear = x.model_year,
                    ListPrice = x.list_price
                }).FirstOrDefault();
            }
        }

        public static List<OrderDto> GetOrderDtos(int customerId)
        {
            using (var ctx = new BikeStoresEntities())
            {
                return ctx.orders.Where(p => p.customer_id == customerId).Select(x => new OrderDto()
                {
                    Id = x.order_id,
                    CustomerId = x.customer_id,
                    OrderStatus = x.order_status,
                    OrderDate = x.order_date,
                    RequiredDate = x.required_date,
                    ShippedDate = x.shipped_date,
                    StoreId = x.store_id,
                    StaffId = x.staff_id,
                    OrderItems = ctx.order_items.Where(y => y.order_id == x.order_id).Select(p => new OrderProductDto()
                    {
                        OrderId = p.order_id,
                        ItemId = p.item_id,
                        ProductId = p.product_id,
                        Quantity = p.quantity,
                        ListPrice = p.list_price,
                        Discount = p.discount
                    })
                }).ToList();
            }
        }

        public static List<StocksDto> GetProductsStateDtos(int storeId)
        {
            using (var ctx = new BikeStoresEntities())
            {
                return ctx.stocks.Where(p => p.store_id == storeId).Select(x => new StocksDto()
                {
                    product = ctx.products.Where(k => k.product_id == x.product_id).Select(g => new ProductDto
                    {
                        Id = g.product_id,
                        Name = g.product_name,
                        BrandId = g.brand_id,
                        CategoryId = g.category_id,
                        ModelYear = g.model_year,
                        ListPrice = g.list_price
                    }).FirstOrDefault(),
                    quantity = x.quantity
                }).ToList();
            }
        }

        public static StocksDto GetProductsStateDtos(int storeId, int productId)
        {
            using (var ctx = new BikeStoresEntities())
            {
                return ctx.stocks.Where(p => p.store_id == storeId).Select(x => new StocksDto()
                {
                    product = ctx.products.Where(k => k.product_id == productId).Select(g => new ProductDto
                    {
                        Id = g.product_id,
                        Name = g.product_name,
                        BrandId = g.brand_id,
                        CategoryId = g.category_id,
                        ModelYear = g.model_year,
                        ListPrice = g.list_price
                    }).FirstOrDefault(),
                    quantity = x.quantity
                }).FirstOrDefault();
            }
        }

        public static List<OrderDto> GetOrderDtos(int staffId, DateTime loDate, DateTime hiDate)
        {
            using (var ctx = new BikeStoresEntities())
            {
                return ctx.orders.Where(p => p.staff_id == staffId && p.order_date >= loDate && p.order_date <= hiDate)
                .Select(x => new OrderDto()
                {
                    Id = x.order_id,
                    CustomerId = x.customer_id,
                    OrderStatus = x.order_status,
                    OrderDate = x.order_date,
                    RequiredDate = x.required_date,
                    ShippedDate = x.shipped_date,
                    StoreId = x.store_id,
                    StaffId = x.staff_id
                }).ToList();
            }
        }

        public static StaffDto GetBestManagerDto()
        {
            Dictionary<StaffDto, int> managers = new Dictionary<StaffDto, int>();

            using (var ctx = new BikeStoresEntities())
            {
                var staffs = ctx.staffs.Select(x => new StaffDto()
                {
                    Id = x.staff_id,
                    FirstName = x.first_name,
                    LastName = x.last_name,
                    Email = x.email,
                    Phone = x.phone,
                    Active = x.active,
                    StoreId = x.store_id,
                    ManagerId = x.manager_id,
                    Orders = ctx.orders.Where(y => y.staff_id == x.staff_id).Count()
                }).ToList();

                foreach (var staff in staffs)
                {
                    managers.Add(staff, staffs.Where(p => p.ManagerId == staff.Id).Select(q => q.Orders).Sum());
                }

                return managers.OrderByDescending(p => p.Value).First().Key;
            }
        }

        public static DateTime GetRequiredDate()
        {
            var today = DateTime.Today;
            if (today.DayOfWeek == DayOfWeek.Thursday) return today.AddDays(4);
            else if (today.DayOfWeek == DayOfWeek.Friday) return today.AddDays(4);
            else if (today.DayOfWeek == DayOfWeek.Saturday) return today.AddDays(4);
            else if (today.DayOfWeek == DayOfWeek.Sunday) return today.AddDays(3);
            else return today.AddDays(2);
        }

        public static void PlaceOrder(List<OrderItem> orderItemsRaw, int storeId, int customerId, int staffId)
        {
            List<order_items> orderItems = new List<order_items>();
            int itemId = 1;
            order order = new order
            {
                customer_id = customerId,
                order_status = 0,
                order_date = DateTime.Today,
                required_date = GetRequiredDate(),
                store_id = storeId,
                staff_id = staffId
            };

            using (var ctx = new BikeStoresEntities())
            {
                ctx.orders.Add(order);
                ctx.SaveChanges();
            }
            using (var ctx = new BikeStoresEntities())
            {
                foreach (var item in orderItemsRaw)
                {
                    if (item.quantity <= GetProductsStateDtos(storeId, item.productId).quantity)
                    {
                        ctx.order_items.Add(new order_items
                        {
                            order_id = order.order_id,
                            item_id = itemId,
                            product_id = item.productId,
                            quantity = item.quantity,
                            list_price = GetProductDtos(item.productId).ListPrice,
                            discount = item.discount
                        });
                        itemId++;
                    }
                    else
                    {
                        Console.WriteLine($"Nie dodano do zamówienia produktu o id: {item.productId}" +
                            $"\nPowód: niewystarczająca ilość w magazynie");
                    }
                }
                ctx.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            //var ctx = new BikeStoresEntities();
            //var productObj = ctx.products.FirstOrDefault();
            //ctx.products.Remove(productObj);
            //ctx.SaveChanges();
            //var productDtos = GetProductDtos();
            //var orders = ctx.orders.FirstOrDefault();
            try
            {
                var products = GetProductDtos();
                var orders = GetOrderDtos(259);
                var stocks = GetProductsStateDtos(1);
                var orders2 = GetOrderDtos(6, new DateTime(2016, 12, 30), new DateTime(2017, 02, 01));
                var manager = GetBestManagerDto();

                List<OrderItem> items = new List<OrderItem>();
                items.Add(new OrderItem
                {
                    productId = 1,
                    quantity = 1000000,
                    discount = 0.20m
                });
                items.Add(new OrderItem
                {
                    productId = 2,
                    quantity = 1,
                    discount = 0.10m
                });
                items.Add(new OrderItem
                {
                    productId = 3,
                    quantity = 3,
                    discount = 0.30m
                });

                PlaceOrder(items, 1, 1, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Console.ReadLine();
        }
    }

    public class OrderItem
    {
        public int productId { get; set; }
        public int quantity { get; set; }
        public decimal discount { get; set; }
    }
}
