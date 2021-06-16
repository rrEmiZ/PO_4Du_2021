using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PODuSl01
{
    public class RequestService
    {
        public async Task<T> GetAsync<T>(string uri)
        {
            var client = new HttpClient();

            HttpResponseMessage resposne = await client.GetAsync(uri);

            await HandleResponse(resposne);

            var json = await resposne.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }

        public Task<T> PostAsync<T>(string uri, T obj)
        {
            return PostAsync<T, T>(uri,obj);
        }

        public async Task<TResult> PostAsync<TSended, TResult>(string uri, TSended obj)
        {
            var client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var resposne = await client.PostAsync(uri, content);

            await HandleResponse(resposne);

            var json = await resposne.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResult>(json);
        }



        public Task<T> PutAsync<T>(string uri, T obj)
        {
            return PutAsync<T, T>(uri, obj);
        }

        public async Task<TResult> PutAsync<TSended, TResult>(string uri, TSended obj)
        {
            var client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var resposne = await client.PutAsync(uri, content);

            await HandleResponse(resposne);

            var json = await resposne.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResult>(json);
        }


        public async Task DeleteAsync(string uri)
        {
            var client = new HttpClient();

            var resposne = await client.DeleteAsync(uri);

            await HandleResponse(resposne);
        }


        private async Task HandleResponse(HttpResponseMessage resposne)
        {
            if (!resposne.IsSuccessStatusCode)
            {
                var error = await resposne.Content.ReadAsStringAsync();
                throw new ApplicationException($"{resposne.StatusCode.ToString()} - {error}");
            }
        }

    }
}
