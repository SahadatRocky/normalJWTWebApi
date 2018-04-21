using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace JwtWebAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("{id}")]
        public string Get([FromRoute]int id)
        {
            return "value";
        }
        [HttpPost]
        public void post([FromBody]string value)
        {

        }
        [HttpPut("{id}")]
        public void put([FromRoute]int id,[FromBody]string value)
        {

        }

    }
}