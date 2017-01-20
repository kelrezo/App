using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace BasicApi
{
    public class EntityController : ApiController
    {
        // GET: api/Default
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet,Route("")]
        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent("<html><body>Hello World</body></html>");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
            // return "<html><body>Hello word</body><html/>";
            // return new string[]
            // {
            //  "Hello?",
            //  "World"

            //};
        }

        // GET: api/Default/5
        [HttpGet, Route("test2")]
        public Entity Get2()
        {
            return new Entity
            {
                Id = 1,
                Name = "travis",
                Dead = true
            };
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
