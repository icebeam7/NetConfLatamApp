using System;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Text.Json;

using System.Web;
using System.Net;

using Microsoft.Maui.Essentials;

using NetConfLatamApp.Models;
using NetConfLatamApp.Helpers;

namespace NetConfLatamApp.Services
{
    internal static class ApiService
    {
        private static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        private static HttpClient CreateClient(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private static HttpClient client = CreateClient(Constants.NetConfLatamApiUrl);

        private static async Task<HttpResponseMessage> SendApiRequest(
            HttpMethod method, string controller, HttpContent content)
        {
            var message = new HttpRequestMessage(method, controller);

            if (content != null)
                message.Content = content;

            var response = await client.SendAsync(message);
            return response;
        }

        public static async Task<IEnumerable<T>> GetItems<T>(string controller)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var response = await SendApiRequest(HttpMethod.Get, controller, null);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStreamAsync();
                    return await JsonSerializer.DeserializeAsync<IEnumerable<T>>(content, options);
                }
            }

            return default;
        }

        public static async Task<T> GetItem<T>(string controller)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var response = await SendApiRequest(HttpMethod.Get, controller, null);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStreamAsync();
                    return await JsonSerializer.DeserializeAsync<T>(content, options);
                }
            }

            return default;
        }

        public static async Task<bool> AddItem<T>(string controller, T item)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var body = JsonSerializer.Serialize(item);
                var content = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await SendApiRequest(HttpMethod.Post, controller, content);
                return response.IsSuccessStatusCode;
            }

            return default;
        }
    }
}
