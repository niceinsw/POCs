using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientPoc.SimpleHttpClient
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> Get(string baseUrl, string resource, string queryString, List<KeyValuePair<string, string>> headers, AuthenticationHeaderValue authHeaders);
        Task<HttpResponseMessage> Post<T>(string baseUrl, string resource, T body, List<KeyValuePair<string, string>> headers, AuthenticationHeaderValue authHeaders);
    }
    public class HttpClientService : IHttpClientService
    {
        public async Task<HttpResponseMessage> Get(string baseUrl, string resource, string queryString, List<KeyValuePair<string, string>> headers, AuthenticationHeaderValue authHeaders)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                AddRequestHeaders(client, headers);

                if (authHeaders != null)
                    client.DefaultRequestHeaders.Authorization = authHeaders;

                string endpoint = $"{baseUrl}/{resource}";

                if (!string.IsNullOrEmpty(queryString))
                    endpoint = $"{endpoint}?{queryString}";

                return await client.GetAsync(new Uri(endpoint));
            }
            throw new System.NotImplementedException();
        }

        public async Task<HttpResponseMessage> Post<T>(string baseUrl, string resource, T body, List<KeyValuePair<string, string>> headers, AuthenticationHeaderValue authHeaders)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                AddRequestHeaders(client, headers);

                if (authHeaders != null)
                    client.DefaultRequestHeaders.Authorization = authHeaders;

                string endpoint = $"{baseUrl}/{resource}";

                var content = new StringContent(JsonConvert.SerializeObject(body).ToString(), Encoding.UTF8, "application/json");

                return await client.PostAsync(endpoint, content);
            }
        }

        private void AddRequestHeaders(HttpClient client, List<KeyValuePair<string, string>> headers)
        {
            if (headers == null)
                return;

            foreach (var header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

        }

        private AuthenticationHeaderValue GetBasicAuthHeader(string userName, string password)
        {
            var basicAuthArray = Encoding.ASCII.GetBytes($"{userName}:{password}");
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(basicAuthArray));
        }
    }
}
