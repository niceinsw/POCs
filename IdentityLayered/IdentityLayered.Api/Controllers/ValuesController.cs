using IdentityLayered.DataAccess.EntityModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IdentityLayered.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //var _context = new ApplicationDbContext();
            //_context.Add(new Tester() { Name = "Tester 78" });
            //_context.SaveChanges();

            var _context = new IdentityLayeredContext();
            _context.Add(new Testers() { Name = "Tester 777" });
            _context.Add(new Testers() { Name = "Tester 778" });
            _context.SaveChanges();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
