using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicApi.Models;

namespace BasicApi.Services
{
    public class EmployeeRepository
    {
        //private const string CacheKey = "EntityStorage";
        List<Employee> Employees {get;}
        public EmployeeRepository()
        {
            Employees = new List<Employee>();
        }
        public EmployeeRepository(Employee[] list)
        {
            Employees = list.ToList();
                        
        }
        public Employee[] GetAllEmployees()
        {
            return Employees.ToArray();        
        }
        public Employee AddEmployee(Employee person)
        {
            //var ctx = HttpContext.Current;        
            //var currentData = ((Employee[])ctx.Cache[CacheKey]).ToList();
            //person.Id = Guid.NewGuid().ToString();
            //currentData.Add(person);
            //ctx.Cache[CacheKey] = currentData.ToArray();
            Employees.Add(person);
            return person;
            
        }
        public void RemoveEmployee(string id)
        {
            //var currentData = ((Employee[])ctx.Cache[CacheKey]).ToList();                    
            //Employee obj = currentData.Find(x=> x.Id==id);
            //currentData.Remove(obj);
            //ctx.Cache[CacheKey] = currentData.ToArray();
            var data = Employees.Find(x => x.Id == id);
            Employees.Remove(data);
        }
        public Employee GetEmployee(string id)
        {
            var obj = Employees.Find(x => x.Id == id);
            return obj;
        }
        public void UpdateEmployee(Employee update)
        {
            //var currentData = ((Employee[])ctx.Cache[CacheKey]).ToList();
            //Employee old = currentData.Find(x => x.Id == update.Id);
            //currentData.Remove(old);
            //currentData.Add(update);
            //ctx.Cache[CacheKey] = currentData.ToArray();
            Employee old = Employees.Find(x => x.Id == update.Id);
            Employees.Remove(old);
            Employees.Add(update);
        }
    }
}