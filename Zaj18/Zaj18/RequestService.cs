using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Zaj18
{
    class RequestService
    {
        
        public async Task<T> GetAsync<T>(string uri)
        {
            var client = new HttpClient();

            HttpResponseMessage resposne = await client.GetAsync(uri);

            await HandleResponse(resposne);

            //var json = await resposne.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(await resposne.Content.ReadAsStringAsync());
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
