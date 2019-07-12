using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CoreConfig.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private AddressConfig _addressConfig;
        private ConnectionConfig _connectionConfig;
        private IConfiguration _config;

        public ValuesController(IOptions<AddressConfig> addressConfig, IOptions<ConnectionConfig> connectionConfig, IConfiguration config)
        {
            _addressConfig = addressConfig.Value;
            _connectionConfig = connectionConfig.Value;
            _config = config;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var connectionString = _connectionConfig.ConnectionString;
            var address = _addressConfig;

            var connectionValue = _config.GetValue<string>("ConnectionString");

            var testValue = StaticConfig.TestConfig;

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


    public class ConnectionConfig {
        public string ConnectionString { get; set; }

    }

    public class AddressConfig
    {
        public string BuildingName { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }

    }
}
