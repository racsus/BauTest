using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BAU.Api.Controllers
{
    public class EngineersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Models.Engineer> Get()
        {
            BAU.Logic.Engineers obj = new BAU.Logic.Engineers();
            IEnumerable<Models.Engineer> res = obj.getList();
            return res;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}