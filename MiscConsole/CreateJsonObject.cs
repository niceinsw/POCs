using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscConsole
{
    public class CreateJsonObject
    {
        public void CreateAndPrint()
        {
            //JArray array = new JArray();
            //JValue text = new JValue("Manual text");
            //JValue date = new JValue(new DateTime(2000, 5, 23));

            //array.Add(text);
            //array.Add(date);

            //string jsonString = array.ToString();

            var jsonString = GetJsonArray(CreateRequest());


            Console.WriteLine($"Json: {jsonString}");
        }

        private static EmailRequest CreateRequest()
        {
            int templateId = 10;
            var request = new EmailRequest()
            {
                From = new From() { Email = "jani@test.com", Name = "Jani Sender" },
                To = new To { Email = "jani@receivetest.com", Name = "Jani Receiver" },
                IsHtmlBody = true,
                Subject = "Cloud Reporting - Onboarding",
                HtmlBody = $"Hello {"Tester"}, <p>Welcome to Cloud Reporting</p>"
            };

            if (templateId > 0)
                request.TemplateId = templateId;

            return request;
        }

        private static JArray GetJsonArray1(EmailRequest emailRequest)
        {
            var jArray = new JArray {
                new JObject {
                    {"From", new JObject {
                        {"Email", emailRequest.From.Email},
                        {"Name", emailRequest.From.Name}
                    }},
                    {"To", new JArray {
                        new JObject {
                            {"Email", emailRequest.To.Email},
                            {"Name", emailRequest.To.Name}
                        }
                    }},

                    {"TemplateID", emailRequest?.TemplateId.Value },
                    {"TemplateLanguage", true },

                    {"Subject", emailRequest.Subject},
                    {"TextPart", emailRequest.IsHtmlBody == false ? emailRequest.TextBody : string.Empty },
                    {"HTMLPart", emailRequest.IsHtmlBody ? emailRequest.HtmlBody : string.Empty}
                }
            };

            return jArray;
        }

        private static JArray GetJsonArray(EmailRequest emailRequest)
        {
            var jArray = new JArray {
                new JObject {
                    {"From", new JObject {
                        {"Email", emailRequest.From.Email},
                        {"Name", emailRequest.From.Name}
                    }},
                    {"To", new JArray {
                        new JObject {
                            {"Email", emailRequest.To.Email},
                            {"Name", emailRequest.To.Name}
                        }
                    }},

                    //{"TemplateID", emailRequest?.TemplateId.Value },
                    //{"TemplateLanguage", true },

                    {"Subject", emailRequest.Subject},
                    {"TextPart", emailRequest.IsHtmlBody == false ? emailRequest.TextBody : string.Empty },
                    {"HTMLPart", emailRequest.IsHtmlBody ? emailRequest.HtmlBody : string.Empty}
                }
            };

            JArray array = new JArray();
            JObject obj = new JObject {
                    {"From", new JObject {
                        {"Email", emailRequest.From.Email},
                        {"Name", emailRequest.From.Name}
                    }},
                    {"To", new JArray {
                        new JObject {
                            {"Email", emailRequest.To.Email},
                            {"Name", emailRequest.To.Name}
                        }
                    }},
                {"Subject", emailRequest.Subject }
            };
            if (emailRequest.TemplateId > 0)
            {
                obj.Add("TemplateID", emailRequest.TemplateId);
                obj.Add("TemplateLanguage", true);
            }
            else
            {
                obj.Add("TextPart", emailRequest.IsHtmlBody == false ? emailRequest.TextBody : string.Empty);
                obj.Add("HTMLPart", emailRequest.IsHtmlBody ? emailRequest.HtmlBody : string.Empty);
            }

            array.Add(obj);

            return array;
        }
    }





    public class EmailRequest
    {
        public From From { get; set; }
        public To To { get; set; }
        public string Subject { get; set; }
        public bool IsHtmlBody { get; set; }
        public string TextBody { get; set; }
        public string HtmlBody { get; set; }
        public int? TemplateId { get; set; }
    }

    public class From
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }

    public class To
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
