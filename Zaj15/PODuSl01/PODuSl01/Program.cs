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
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;

namespace PODuSl01
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //AddStock(4, new Random().Next(1, 1000)); 

            //AddStock(6, new Random().Next(1, 1000));

            //await SomeLoopAsync(50, 1);
            //SomeLoopAsync(50, 2);

            HttpClient client = new HttpClient();

            var response = await client.GetAsync("https://wu.wsiz.edu.pl/");



            var contentString = await response.Content.ReadAsStringAsync();

            Console.ReadLine();
        }


       public  static async Task SomeLoopAsync(int counter, int loopNo)
        {
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine($"Loop{loopNo} + ctr {i}");
                await Task.Delay(100);
            }
        }

        static async Task AddStock(int productId, int qty)
        {
            using (var db = new BikeStoresContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {


                    var stock = await db.Stocks.FirstOrDefaultAsync(s => s.ProductId == productId && s.StoreId == 1);

                    if (stock == null)
                    {
                        stock = new Stock()
                        {
                            ProductId = productId,
                            Quantity = qty,
                            StoreId = 1

                        };

                        db.Add(stock);
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        stock.Quantity = qty;



                        db.Update(stock);
                        await db.SaveChangesAsync();
                    }


                    await Task.Delay(10000);


                    Console.WriteLine("Zakutalizowano " + productId);
                }

            }
        }



        //static async Task Main(string[] args)
        //{
        //    Coffee cup = PourCoffee();
        //    Console.WriteLine("coffee is ready");

        //    var eggsTask = FryEggsAsync(2);
        //    var baconTask = FryBaconAsync(3);
        //    var toastTask = MakeToastWithButterAndJamAsync(2);

        //    var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
        //    while (breakfastTasks.Count > 0)
        //    {
        //        Task finishedTask = await Task.WhenAny(breakfastTasks);
        //        if (finishedTask == eggsTask)
        //        {
        //            Console.WriteLine("eggs are ready");
        //        }
        //        else if (finishedTask == baconTask)
        //        {
        //            Console.WriteLine("bacon is ready");
        //        }
        //        else if (finishedTask == toastTask)
        //        {
        //            Console.WriteLine("toast is ready");
        //        }
        //        breakfastTasks.Remove(finishedTask);
        //    }

        //    Juice oj = PourOJ();
        //    Console.WriteLine("oj is ready");
        //    Console.WriteLine("Breakfast is ready!");


        //    Console.ReadLine();
        //}

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return Task.FromResult(new Toast());
        }

        private static Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return Task.FromResult(new Bacon());
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }


}


