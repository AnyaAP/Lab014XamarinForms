using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Headers;

namespace Lab014XamarinForms
{
    public class TrainService
    {
        const string Url = "https://localhost:7138/api/Trains/";
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Train>> Get()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Train>>(result, options);
        }

        public async Task<Train> Add(Train train)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(train),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return System.Text.Json.JsonSerializer.Deserialize<Train>(
                await response.Content.ReadAsStringAsync(), options);
        }
        public async Task<Train> Update(Train train)
        {
            HttpClient client = GetClient();
            var response = await client.PutAsync(Url + train.Id,
                new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(train),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return System.Text.Json.JsonSerializer.Deserialize<Train>(
                await response.Content.ReadAsStringAsync(), options);
        }
        public async Task<Train> Delete(int id)
        {
            HttpClient client = GetClient();
            var response = await client.DeleteAsync(Url + id);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return System.Text.Json.JsonSerializer.Deserialize<Train>(
               await response.Content.ReadAsStringAsync(), options);
        }
    }
}

