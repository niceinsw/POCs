using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscConsole
{
    public class JsonEscapeUnescape
    {
        public string escapedJson { get; set; } = "[{\"Status\":\"error\",\"Errors\":[{\"ErrorIdentifier\":\"226c961c-a408-466a-8e83-a6d976e2d1a8\",\"ErrorCode\":\"send-0010\",\"StatusCode\":400,\"ErrorMessage\":\"Template id \\\"589465\\\" doesn't exist for your account.\",\"ErrorRelatedTo\":[\"TemplateID\"]}]}]";

        public void Run()
        {
            //var str = escapedJson.Replace(@"\""", @"""");
            //Console.WriteLine("Json");
            //var obj = JsonConvert.DeserializeObject<MailjetReponseModel>(str);

            dynamic result = JsonConvert.DeserializeObject(escapedJson);

            return;

        }
    }

    public class Error
    {
        public string ErrorIdentifier { get; set; }
        public string ErrorCode { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string[] ErrorRelatedTo { get; set; }
    }

    public class MailjetReponseModel
    {
        public string Status { get; set; }
        public Error[] Errors { get; set; }
    }
}
