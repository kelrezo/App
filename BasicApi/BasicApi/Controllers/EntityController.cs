using BasicApi.Models;
using BasicApi.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace BasicApi.Controllers
{
    [RoutePrefix("employees")]
    public class EntityController : ApiController
    {
        private EmployeeRepository EmployeeRepository;
        private TimeCardRepository TimeCardRepository;
     
        public EntityController()
        {
            this.EmployeeRepository = new EmployeeRepository();
            this.TimeCardRepository = new TimeCardRepository();
        }

        [HttpGet,Route("")]
        public Employee[] GetAll()
        {
            return this.EmployeeRepository.GetAllEmployees();
        }

        [HttpGet, Route("{id}")]
        public Employee Get(string id)
        {
            
            return this.EmployeeRepository.GetEmployee(id);
        }

        [HttpPut, Route("{id}")]
        public void Put(string id,[FromBody]Employee person)
        {
            person.Id = id;
            EmployeeRepository.UpdateEmployee(person);

        }

        [HttpPost,Route("")]
        public string Post([FromBody]Employee value)
        {
            return EmployeeRepository.AddEmployee(value) ? "Employee Added Successfully":"Error Occured And Employee Was Not Added";
        }

        [HttpDelete, Route("{id}")]
        public string Delete(string id)
        {
            return this.EmployeeRepository.RemoveEmployee(id) ? "Successfully Deleted Employee" : "Error Deleting Employee";
        }
        [HttpPost,Route("{id}/time")]
        public string PostCard([FromBody] TimeCard time,string id)
        {
            //var request = data.GetBufferlessInputStream();
            //request.Read(data.BinaryRead(data.TotalBytes), 0, data.TotalBytes);
            //NameValueCollection headerList = ctx.Request.Headers;
            //var authorizationField = headerList.Get("this");
            //JObject joResponse = JObject.Parse(response);
            //JObject ojObject = (JObject)joResponse["response"];
            //JArray array = (JArray)ojObject["hours"];
            //int id = Convert.ToInt32(array[0].ToString());
            var ctx = HttpContext.Current;
            var data = ctx.Request;
            Employee worker = Get(id);
            if (worker.Active)
            {
                time.Id = id;
                time.Date = ctx.Timestamp;
                TimeCardRepository.AddTimeCard(time);
                return "TimeCarded Added";
            }
            return "TimeCard Not Added, Worker is not active.";
        }
        [HttpGet, Route("{id}/time")]
        public TimeCard[] GetCard(string id)
        {
            var ctx = HttpContext.Current;
            var data = ctx.Request;    
            return TimeCardRepository.GetTimeCards(id);
        }
    }
}
