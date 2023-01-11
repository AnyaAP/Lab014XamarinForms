using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab014XamarinForms
{
    public class PassengerService
    {
        const string Url = "https://localhost:7138/api/Passengers/"; // обращайте внимание на конечный слеш
        // настройки для десериализации для нечувствительности к регистру символов
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        // настройка клиента
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        // получаем всех друзей
        public async Task<IEnumerable<Passenger>> Get()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonSerializer.Deserialize<IEnumerable<Passenger>>(result, options);
        }

        // добавляем одного друга
        public async Task<Passenger> Add(Passenger passenger)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonSerializer.Serialize(passenger),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<Passenger>(
                await response.Content.ReadAsStringAsync(), options);
        }
        public async Task<Passenger> Update(Passenger passenger)
        {
            HttpClient client = GetClient();
            var response = await client.PutAsync(Url + passenger.Id,
                new StringContent(
                    JsonSerializer.Serialize(passenger),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<Passenger>(
                await response.Content.ReadAsStringAsync(), options);
        }
        // удаляем друга
        public async Task<Passenger> Delete(int id)
        {
            HttpClient client = GetClient();
            var response = await client.DeleteAsync(Url + id);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<Passenger>(
               await response.Content.ReadAsStringAsync(), options);
        }
    }
}