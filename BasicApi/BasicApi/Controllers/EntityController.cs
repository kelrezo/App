using BasicApi.Models;
using BasicApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace BasicApi.Controllers
{
    [RoutePrefix("app")]
    public class EntityController : ApiController
    {

        //implement path param
        //implement header param
        private EntityRepository EntityRepository;
     
        public EntityController()
        {
            this.EntityRepository = new EntityRepository();
        }

        
        [HttpGet, Route("")]
        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent("<html><body>Hello World</body></html>");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }

        [HttpGet, Route("test3")]
        public Entity[] get()
        {
            return this.EntityRepository.GetAllEntities();
        }
        // GET: api/Default/5
        [HttpGet, Route("{id:int}")]
        public Entity Get2(int id)
        {
            return this.EntityRepository.GetEntity(id);
        }

        // POST: api/Default
        [HttpPost,Route("test2")]
        public HttpResponseMessage Post([FromBody]Entity value)
        {
            var response = Request.CreateResponse<Entity>(System.Net.HttpStatusCode.Created,value);

            return response;
           
        }
        
        
        // PUT: api/Default/5
        [HttpPut,Route("test")]
        public string Put([FromBody]Entity value)
        {
            return EntityRepository.SaveContact(value) ? "Entity Added Successfully":"Error Occured And Entity Was Not Added";
        }

        // DELETE: api/Default/5
        [HttpDelete, Route("test")]
        public string Delete()
        {
            HttpContext httpContext = HttpContext.Current;
            var headerList = httpContext.Request.Headers["Id"];
            return this.EntityRepository.RemoveEntity(int.Parse(headerList)) ? "Successfully Deleted Entity" : "Error Deleting Entity";
        }
    }
}
