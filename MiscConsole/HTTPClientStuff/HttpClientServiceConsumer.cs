using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MiscConsole.HTTPClientStuff
{
    public class HttpClientServiceConsumer
    {
        private IHttpClientService _httpClientService = new GenericHttpClientService();

        public async Task GetRequest()
        {

            var basicAuthHeader = GetBasicAuthenticationHeader("username", "password");

            var response = await _httpClientService.Get("baseurl", "resource", string.Empty, null, basicAuthHeader);

            if (!response.IsSuccessStatusCode)
            {
                throw new System.Exception("error message here");
                //throw new CustomException((int)response.StatusCode, response.ReasonPhrase);
            }

            return; //await response.Content.ReadAsStreamAsync();
        }

        public async Task PostRequest()
        {
            dynamic requestBody = new { trk_source = "report" };

            var response = await _httpClientService.Post<dynamic>("baseurl", "resource", requestBody, null);
            if (!response.IsSuccessStatusCode)
            {
                throw new System.Exception("error message here");
                //throw new CustomException((int)response.StatusCode, response.ReasonPhrase);
            }

            var data = await response.Content.ReadAsStringAsync();
            dynamic obj = JsonConvert.DeserializeObject(data);
        }

        private AuthenticationHeaderValue GetBasicAuthenticationHeader(string userName, string password)
        {
            var basicAuthArray = Encoding.ASCII.GetBytes($"{userName}:{password}");
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(basicAuthArray));
        }

    }
}



//#region samplecode
//[HttpGet]
//public async Task<IActionResult> Get()
//{
//    var data = await GetFile(_reportToken, _runToken);
//    return File(data, "application/octet-stream", $"report-{DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds}.pdf");
//}

//[HttpGet("generate-report")]
//public async Task<IActionResult> GenerateReport(string reportToken, string runToken)
//{
//    try
//    {
//        string state = await GenerateReportFile(reportToken, runToken);
//        if (state == "completed")
//        {
//            var data = await GetFile(reportToken, runToken);
//            return File(data, "application/octet-stream", $"report-{DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds}.pdf");
//        }
//        return Ok("Download failed");
//    }
//    catch (Exception ex)
//    {
//        return Ok($"Error: Download failed. {ex.Message}");
//    }

//}

//private async Task<string> GenerateReportFile(string reportToken, string runToken)
//{
//    string state = string.Empty;
//    bool isNotFound = false;
//    var timeOut = ToTimeStamp(DateTime.UtcNow.AddMinutes(5));

//    string resource = $"reports/{reportToken}/exports/runs/{runToken}/pdf";
//    dynamic payload = new { trk_source = "report" };
//    var client = new HttpClient();
//    client.BaseAddress = new Uri(_baseUrl);

//    var byteArray = Encoding.ASCII.GetBytes($"{_userName}:{_password}");
//    var basicAuthenticationHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
//    client.DefaultRequestHeaders.Authorization = basicAuthenticationHeader;

//    var content = new StringContent(JsonConvert.SerializeObject(payload).ToString(), Encoding.UTF8, "application/json");

//    var endpoint = $"{_baseUrl}/{resource}";

//    HttpResponseMessage response = new HttpResponseMessage();

//    while (timeOut > ToTimeStamp(DateTime.UtcNow) && state != "completed" && isNotFound == false)
//    {
//        response = await client.PostAsync(new Uri(endpoint), content);


//        //add error if response.issuccessstatuscode  is false

//        //if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
//        //    isNotFound = true;
//        if (!response.IsSuccessStatusCode)
//            throw new Exception($"Error: Response code: {response.StatusCode} - Reason: {response.ReasonPhrase}");


//        //var isSuccess = response.IsSuccessStatusCode;

//        var resStatus = await response.Content.ReadAsStringAsync();

//        dynamic resObj = JsonConvert.DeserializeObject(resStatus);

//        state = resObj.state;
//    }

//    return state;
//}

//public async Task<Stream> GetFile(string reportToken, string runToken)
//{
//    string resource = $"reports/{reportToken}/exports/runs/{runToken}/pdf/download/";

//    var client = new HttpClient();
//    client.BaseAddress = new Uri(_baseUrl);

//    //AddRequestHeaders(client, headers);


//    var byteArray = Encoding.ASCII.GetBytes($"{_userName}:{_password}");
//    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

//    var basicAuthenticationHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
//    client.DefaultRequestHeaders.Authorization = basicAuthenticationHeader;


//    var endpoint = $"{_baseUrl}/{resource}";

//    //if (!String.IsNullOrEmpty(queryString))
//    //{
//    //    endpoint = $"{endpoint}?{queryString}";
//    //}



//    HttpResponseMessage response = await client.GetAsync(new Uri(endpoint));

//    if (response.IsSuccessStatusCode)
//    {
//        var stream = await response.Content.ReadAsStreamAsync();
//        return stream;
//    }

//    return null;
//}

//private void AddRequestHeaders(HttpClient client, List<KeyValuePair<string, string>> headers)
//{
//    if (headers == null) return;

//    foreach (var header in headers)
//    {
//        client.DefaultRequestHeaders.Add(header.Key, header.Value);
//    }
//}

//public Int32 ToTimeStamp(DateTime value)
//{
//    return (Int32)(value.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
//}
//#endregion