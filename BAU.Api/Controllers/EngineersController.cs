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
        //// GET api/<controller>
        //public IEnumerable<Models.Engineer> Get()
        //{
        //    BAU.Logic.Engineers context = new BAU.Logic.Engineers();
        //    IEnumerable<Models.Engineer> res = context.getList();
        //    return res;
        //}

        //[Route("api/Engineers/GetPagination/{paginationObject}")]
        //public IEnumerable<Models.Engineer> GetPagination(string paginationObject)
        //{
        //    paginationObject = @"{""pageNumber"": ""1"",""pageSize"": ""5"",""orderBy"": ""name"",""direction"": ""asc"", ""whereClause"": """"}";
        //    Models.Pagination page = JsonConvert.DeserializeObject<Models.Pagination>(paginationObject);
        //    BAU.Logic.Engineers context = new BAU.Logic.Engineers();
        //    IEnumerable<Models.Engineer> res = context.getListPaginated(page);
        //    return res;
        //}

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