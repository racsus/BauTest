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
        public const int _PAGE_SIZE = 10;

        public HttpResponseMessage Get(int pageNumber = 1)
        {
            HttpResponseMessage response = null;
            BAU.Logic.Calendar context = new BAU.Logic.Calendar();
            Models.CalendarWithPaging model = context.getPaginated(pageNumber, _PAGE_SIZE);
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
    }
}
