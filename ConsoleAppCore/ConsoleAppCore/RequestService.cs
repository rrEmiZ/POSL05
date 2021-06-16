using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCore
{
    public class RequestService
    {

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(uri);

            await HandleResponse(response);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }

        public Task<T> PostAsync<T>(string uri, T obj)
        {
            return PostAsync<T, T>(uri, obj);
        }


        public async Task<TResult> PostAsync<TPost,TResult>(string uri, TPost obj)
        {
            var requestJson = JsonConvert.SerializeObject(obj);

            HttpClient client = new HttpClient();

            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, content);

            await HandleResponse(response);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResult>(json);
        }


        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new Exception($"{response.StatusCode.ToString()} - {content}");

            }
        }
    }
}
