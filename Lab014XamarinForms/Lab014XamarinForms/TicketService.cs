using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab014XamarinForms
{
    public class TicketService
    {
        const string Url = "https://localhost:7138/api/Tickets/";
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

        public async Task<IEnumerable<Ticket>> Get()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonSerializer.Deserialize<IEnumerable<Ticket>>(result, options);
        }
        public async Task<Ticket> Add(Ticket ticket)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonSerializer.Serialize(ticket),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<Ticket>(
                await response.Content.ReadAsStringAsync(), options);
        }
        public async Task<Ticket> Update(Ticket ticket)
        {
            HttpClient client = GetClient();
            var response = await client.PutAsync(Url + ticket.Id,
                new StringContent(
                    JsonSerializer.Serialize(ticket),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<Ticket>(
                await response.Content.ReadAsStringAsync(), options);
        }
        public async Task<Ticket> Delete(int id)
        {
            HttpClient client = GetClient();
            var response = await client.DeleteAsync(Url + id);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<Ticket>(
               await response.Content.ReadAsStringAsync(), options);
        }
    }
}
