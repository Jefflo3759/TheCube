using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheCube.Models.Domain;
using TheCube.Models.Request;
using TheCube.Services;

namespace TheCube.Web.Controllers.API
{
    [RoutePrefix("api/thecube")]
    public class TheCubeController : ApiController
    {
        // GET: api/TheCube'
        [Route ,HttpGet]
        public HttpResponseMessage GetAll()
        {
            var response = CubeServices.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, "test");
            
        }

        // GET: api/TheCube/5
        [Route("{id:int}") ,HttpGet]
        public HttpResponseMessage GetById(int id)
        {
       


            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST: api/TheCube
        [Route, HttpPost]
        public HttpResponseMessage Post(TheCubeCreateRequest model)
        {
            return Request.CreateResponse(HttpStatusCode.OK, 42);
        }

        // PUT: api/TheCube/5
        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Put(int id, TheCubeUpdateRequest model)
        {
            return Request.CreateResponse(HttpStatusCode.OK, 42);
        }

        // DELETE: api/TheCube/5
        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
