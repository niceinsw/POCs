using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using MyApi.ApiServices;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    //return new string[] { "value1", "value2" };
        //}
        public ActionResult<IEnumerable<User>> Get()
        {
            //user dataaccess layer
            var users = new UserService().GetUsers();
            
            return users;            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            //Using business layer
            var user = new NewUserService().GetUser(id);

            if (user==null)            
                return NotFound();
            
            return user;
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
