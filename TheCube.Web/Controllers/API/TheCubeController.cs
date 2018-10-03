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
            return Request.CreateResponse(HttpStatusCode.OK, response);
            

        }

        
            // GET: api/TheCube'
            [Route("questions"), HttpGet]
            public HttpResponseMessage GetAllQuestions()
            {
                var response = CubeServices.GetAllQuestions();
                return Request.CreateResponse(HttpStatusCode.OK, response);


            }

            // GET: api/TheCube/5
            [Route("Results/{id:int}") ,HttpGet]
        public HttpResponseMessage GetById(int Id)

        {
            var response = CubeResultsServices.GetById(Id);
            if (response == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
          
        }

        // POST: api/TheCube
        [Route("Results"), HttpPost]
        public HttpResponseMessage Post(TheCubeCreateRequest theCubeCreateRequest)
        {
            var response = CubeResultsServices.Create(theCubeCreateRequest);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // PUT: api/TheCube/5
        [Route("Results/{Id:int}"), HttpPut]
        public HttpResponseMessage Put(int Id, TheCubeUpdateRequest model)

        {
            if (model == null)
            {
                ModelState.AddModelError("", "missing body data");
            }
            else if (Id != model.Id)
                {
                ModelState.AddModelError("Id", " Id in the /URL doesn't match the Id in the body");
            }
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
                CubeResultsServices.Update(model);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        
        // DELETE: api/TheCube/5
        [Route("Results/{Id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
           CubeResultsServices.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
