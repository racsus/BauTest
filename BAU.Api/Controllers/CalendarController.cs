using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BAU.Api.Controllers
{
    /// <summary>
    /// API for "Support Wheel of Fate"
    /// </summary>
    [AllowCrossSiteJson]
    public class CalendarController : ApiController
    {
        /// <summary>
        /// Pagination size for paginated data
        /// </summary>
        public const int _PAGE_SIZE = 10;

        /// <summary>
        /// Get paginated calendar information.
        /// </summary>
        /// <param name="pageNumber">Page number (Pagination)</param>
        /// <returns></returns>
        public HttpResponseMessage Get(int pageNumber = 1)
        {
            HttpResponseMessage response = null;
            BAU.Logic.Calendar context = new BAU.Logic.Calendar();
            Models.CalendarWithPaging model = context.getPaginated(pageNumber, _PAGE_SIZE);
            response = Request.CreateResponse(HttpStatusCode.OK, model);
            return response;
        }

        /// <summary>
        /// This method found an engineer that accomplish the 3 rules described in the task
        /// </summary>
        /// <returns></returns>
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
