using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientPoc
{
    public class Class1
    {
        public async Task<HttpResponseMessage> Get(string baseUrl, string resource, string queryStrig, List<KeyValuePair<string, string>> headers, AuthenticationHeaderValue authHeader)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                AddRequestHeaders(client, headers);

                if (authHeader != null)
                    client.DefaultRequestHeaders.Authorization = authHeader;

                string endpoint = $"{baseUrl}/{resource}";

                if (!string.IsNullOrEmpty(queryStrig))
                    endpoint = $"{endpoint}?{queryStrig}";

                return await client.GetAsync(endpoint);
            }
        }

        public async Task<HttpResponseMessage> Post<T>(string baseUrl, string resource, T body, List<KeyValuePair<string, string>> headers, AuthenticationHeaderValue authHeader)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                AddRequestHeaders(client, headers);
                if (authHeader != null)
                    client.DefaultRequestHeaders.Authorization = authHeader;

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

        private AuthenticationHeaderValue GetBasicAuthHeader(string username, string password)
        {
            var authByteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authByteArray));
        }
    }
}
