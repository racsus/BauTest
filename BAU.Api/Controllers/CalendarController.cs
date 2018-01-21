using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BAU.Api.Controllers
{
    [AllowCrossSiteJson]
    public class CalendarController : ApiController
    {
        //// GET: api/Calendar
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public HttpResponseMessage Get(int pageNumber = 1)
        {
            HttpResponseMessage response = null;
            BAU.Logic.Calendar context = new BAU.Logic.Calendar();
            Models.CalendarWithPaging model = context.getPaginated(pageNumber);
            response = Request.CreateResponse(HttpStatusCode.OK, model);
            return response;
        }

        [Route("api/Calendar/SetEngineer")]
        [HttpGet]
        public HttpResponseMessage SetEngineer()
        {
            HttpResponseMessage response = null;
            BAU.Logic.Calendar context = new BAU.Logic.Calendar();
            int res = context.InsertRandomEngineer();
            response = Request.CreateResponse(HttpStatusCode.OK, res);
            return response;
        }

        //// GET: api/Calendar/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Calendar
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Calendar/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Calendar/5
        //public void Delete(int id)
        //{
        //}
    }
}
