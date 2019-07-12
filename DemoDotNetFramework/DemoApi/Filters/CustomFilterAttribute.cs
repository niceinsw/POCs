using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DemoApi.Filters
{
    public class CustomFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var allHeaders = GetRequestHeaders(actionContext);

            var key = actionContext.Request.Headers.GetValues("ApiKey").FirstOrDefault();

            if (key == "TestKey")
            {
                base.OnActionExecuting(actionContext);

            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid Api key");
            }


        }

        //public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        //{
        //    base.OnActionExecuted(actionExecutedContext);
        //}

        private string GetRequestHeaders(HttpActionContext context)
        {
            // Note you can replace the type names sucha as string, HttpRequestHeaders, List<KeyValuePair<string, IEnumerable<string>>>
            // with var keyword where ever possible for readability.
            string headerString = string.Empty;
            HttpRequestHeaders requestHeaders = context.Request.Headers;
            List<KeyValuePair<string, IEnumerable<string>>> headerList = requestHeaders.ToList();
            foreach (var header in headerList)
            {
                string key = header.Key;
                List<string> valueList = header.Value.ToList();
                string valueString = string.Empty;
                foreach (var v in valueList)
                {
                    valueString = valueString + v + "-";
                }
                headerString = headerString + key + ": " + valueString + Environment.NewLine;
            }

            return headerString;
        }
    }
}