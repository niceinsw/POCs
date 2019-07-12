using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using RestSharp;

namespace MiscDemo.ClientServices
{
    public class RestClientService
    {
        public async Task<string> Get(string baseUrl, string resource, string queryString, List<KeyValuePair<string, string>> headers)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            AddRequestHeaders(client, headers);

            var endpoint = $"{baseUrl}/{resource}";
            if (!String.IsNullOrEmpty(queryString))
            {
                endpoint = $"{endpoint}?{queryString}";
            }

            HttpResponseMessage response = await client.GetAsync(new Uri(endpoint));

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Post<T>(string baseUrl, string resource, T body, List<KeyValuePair<string, string>> headers) where T : class, new()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };

            AddRequestHeaders(client, headers);

            var endpoint = $"{baseUrl}/{resource}";

            var temp = JsonConvert.SerializeObject(body).ToString();

            var content = new StringContent(JsonConvert.SerializeObject(body).ToString(), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(new Uri(endpoint), content);

            return await response.Content.ReadAsStringAsync();
        }

        private void AddRequestHeaders(HttpClient client, List<KeyValuePair<string, string>> headers)
        {
            if (headers == null) return;

            foreach (var header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }
    }
}

