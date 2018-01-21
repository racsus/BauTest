using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BAU.Api.Controllers
{
    [AllowCrossSiteJson]
    public class EngineersController : ApiController
    {
        /// <summary>
        /// Get engineers paginated
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <returns></returns>
        public HttpResponseMessage Get(int pageNumber = 1)
        {
            HttpResponseMessage response = null;
            BAU.Logic.Engineers context = new BAU.Logic.Engineers();
            Models.EngineerWithPaging model = context.getPaginated(pageNumber);
            response = Request.CreateResponse(HttpStatusCode.OK, model);
            return response;
        }

        /// <summary>
        /// Get engineers without paginate
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <returns></returns>
        [Route("api/Engineers/GetAll")]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = null;
            BAU.Logic.Engineers context = new BAU.Logic.Engineers();
            List<Models.Engineer> res = context.getAll();
            response = Request.CreateResponse(HttpStatusCode.OK, res);
            return response;
        }

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}