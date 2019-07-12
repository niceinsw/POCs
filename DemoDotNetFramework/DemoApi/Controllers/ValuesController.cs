using DemoApi.Filters;
using System.Collections.Generic;
using System.Threading;
using System.Web.Http;

namespace DemoApi.Controllers
{
    [CustomFilter]
    [BasicAuthentication]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            string userName = Thread.CurrentPrincipal.Identity.Name;

            var isAllowed = Thread.CurrentPrincipal.IsInRole("UserRole");
            var isAdmin = Thread.CurrentPrincipal.IsInRole("Admin");
            var identity = Thread.CurrentPrincipal.Identity;
            return new string[] { "value1", "value2", $"User: {userName}" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
