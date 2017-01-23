﻿using BasicApi.Models;
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
        private EmployeeRepository EmployeeRepository { get;}
        private TimeCardRepository TimeCardRepository{ get; }
        public EntityController()
        {
            this.EmployeeRepository = new EmployeeRepository();
            this.TimeCardRepository = new TimeCardRepository();
        }
        public EntityController(EmployeeRepository RepositoryE,TimeCardRepository RepositoryT)
        {
            this.EmployeeRepository = RepositoryE;
            this.TimeCardRepository = RepositoryT;
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
            this.EmployeeRepository.UpdateEmployee(person);
        }

        [HttpPost,Route("")]
        public Employee Post([FromBody]Employee value)
        {
            return this.EmployeeRepository.AddEmployee(value);
        }

        [HttpDelete, Route("{id}")]
        public void Delete(string id)
        {
            this.TimeCardRepository.RemoveTimeCards(id);
            this.EmployeeRepository.RemoveEmployee(id);
        }
        [HttpPost,Route("{id}/time")]
        public TimeCard PostCard([FromBody] TimeCard time,string id)
        {
            var ctx = HttpContext.Current;
            var data = ctx.Request;
            Employee worker = Get(id);
            if (worker.Active)
            {
                time.Id = id;
                time.Date = ctx.Timestamp;
                this.TimeCardRepository.AddTimeCard(time);
            } 
            return time;
        }
        [HttpGet, Route("{id}/time")]
        public TimeCard[] GetCard(string id)
        {  
            return this.TimeCardRepository.GetTimeCards(id);
        }
        [HttpGet, Route("time")]
        public TimeCard[] GetCards()
        {
            return this.TimeCardRepository.GetTimeCards();
        }
    }
}
