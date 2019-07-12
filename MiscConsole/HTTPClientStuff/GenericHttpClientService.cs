using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MiscConsole.HTTPClientStuff
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> Get(string baseUrl, string resource, string queryString, List<KeyValuePair<string, string>> headers);

        Task<HttpResponseMessage> Get(string baseUrl, string resource, string queryString, List<KeyValuePair<string, string>> headers, AuthenticationHeaderValue authenticationHeader = null);

        Task<HttpResponseMessage> Post<T>(string baseUrl, string resource, T body, List<KeyValuePair<string, string>> headers, AuthenticationHeaderValue authenticationHeader = null) where T : class, new();
    }

    public class GenericHttpClientService : IHttpClientService
    {
        public async Task<HttpResponseMessage> Get(string baseUrl, string resource, string queryString, List<KeyValuePair<string, string>> headers)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                AddRequestHeaders(client, headers);

                var endpoint = $"{baseUrl}/{resource}";
                if (!String.IsNullOrEmpty(queryString))
                {
                    endpoint = $"{endpoint}?{queryString}";
                }

                return await client.GetAsync(new Uri(endpoint));
            }

        }

        public async Task<HttpResponseMessage> Get(string baseUrl, string resource, string queryString, List<KeyValuePair<string, string>> headers, AuthenticationHeaderValue authenticationHeader = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                if (authenticationHeader != null)
                    client.DefaultRequestHeaders.Authorization = authenticationHeader;

                AddRequestHeaders(client, headers);

                var endpoint = $"{baseUrl}/{resource}";
                if (!String.IsNullOrEmpty(queryString))
                {
                    endpoint = $"{endpoint}?{queryString}";
                }

                return await client.GetAsync(new Uri(endpoint));
            }
        }

        public async Task<HttpResponseMessage> Post<T>(string baseUrl, string resource, T body, List<KeyValuePair<string, string>> headers, AuthenticationHeaderValue authenticationHeader = null) where T : class, new()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                if (authenticationHeader != null)
                    client.DefaultRequestHeaders.Authorization = authenticationHeader;

                AddRequestHeaders(client, headers);

                var endpoint = $"{baseUrl}/{resource}";

                var temp = JsonConvert.SerializeObject(body).ToString();

                var content = new StringContent(JsonConvert.SerializeObject(body).ToString(), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(new Uri(endpoint), content);

                //return await response.Content.ReadAsStringAsync();
                return response;
            }
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
