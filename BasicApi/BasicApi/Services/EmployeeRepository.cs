using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicApi.Models;

namespace BasicApi.Services
{
    public class EmployeeRepository
    {
        private const string CacheKey = "EntityStorage";
        List<Employee> Employees { get; set; }
        public EmployeeRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var contacts = new Employee[]{};
                    ctx.Cache[CacheKey] = contacts;
                }
            }
        }
        public EmployeeRepository(Employee[] list)
        {
            var ctx = HttpContext.Current;
            ctx.Cache[CacheKey] = list;

        }
        public Employee[] GetAllEmployees()
        {
            var ctx = HttpContext.Current;
            return ctx!=null ? ((Employee[])ctx.Cache[CacheKey]).ToArray() : this.Employees.ToArray();
        }

        public Employee AddEmployee(Employee person)
        {
            var ctx = HttpContext.Current;
            var currentData = ((Employee[])ctx.Cache[CacheKey]).ToList();
            person.Id = Guid.NewGuid().ToString();
            currentData.Add(person);
            ctx.Cache[CacheKey] = currentData.ToArray();
            return person;           
        }
        public void RemoveEmployee(string id)
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                var currentData = ((Employee[])ctx.Cache[CacheKey]).ToList();
                Employee obj = currentData.Find(x => x.Id == id);
                currentData.Remove(obj);
                ctx.Cache[CacheKey] = currentData.ToArray();
                this.Employees = currentData.ToList();
                return;
            }
        }
        public Employee GetEmployee(string id)
        {
            var ctx = HttpContext.Current;
            var currentData = ((Employee[])ctx.Cache[CacheKey]).ToList();
            var obj = Employees.Find(x => x.Id == id);
            return currentData.Find(x => x.Id == id);
        }
        public void UpdateEmployee(Employee update)
        {
            var ctx = HttpContext.Current;
            var currentData = ((Employee[])ctx.Cache[CacheKey]).ToList();
            Employee old = currentData.Find(x => x.Id == update.Id);
            currentData.Remove(old);
            currentData.Add(update);
            ctx.Cache[CacheKey] = currentData.ToArray();
        }
    }
}