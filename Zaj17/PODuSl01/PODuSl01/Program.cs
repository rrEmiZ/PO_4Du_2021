using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PODuSl01
{
 
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new RequestService();

            try
            {
                //var data = await service.GetAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts");

                //foreach (var item in data)
                //{
                //    Console.WriteLine($"{item.Id} - {item.UserId} - {item.Title}");
                //}

                //var newPost = new Post()
                //{
                //    Body = "asd",
                //    Title = "asd",
                //    UserId = 1
                //};

                //var result = await service.PostAsync("https://jsonplaceholder.typicode.com/posts", newPost);


                await service.DeleteAsync("https://jsonplaceholder.typicode.com/posts/1");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
         



            Console.ReadLine();
        }
    }
}
