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
        public EmployeeRepository()
        {
            
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var Employees = new Employee[]
                    {
                        new Employee
                        {
                            Id = "0",
                            Name = "Placeholder",
                            Active = true
                        }

                    };
                    ctx.Cache[CacheKey] = Employees;                  
                }
            }
        }
        public Employee[] GetAllEmployees()
        {
            var ctx = HttpContext.Current;

            return (Employee[])ctx.Cache[CacheKey];
          
        }
        public bool AddEmployee(Employee person)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Employee[])ctx.Cache[CacheKey]).ToList();
                    person.Id = Guid.NewGuid().ToString();
                    currentData.Add(person);
                    ctx.Cache[CacheKey] = currentData.ToArray();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            return false;
        }

        public bool RemoveEmployee(string id)
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                try
                {
                    var currentData = ((Employee[])ctx.Cache[CacheKey]).ToList();
               
                    Employee obj = currentData.Find(x=> x.Id==id);
                    currentData.Remove(obj);
                    ctx.Cache[CacheKey] = currentData.ToArray();
                    return true;                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                    
                }
            }
            return false;

        }
        public Employee GetEmployee(string id)
        {
            var ctx = HttpContext.Current;
            Employee obj = new Employee();
            if (ctx != null)
            {
                try
                {
                    var currentData = ((Employee[])ctx.Cache[CacheKey]).ToList();
                    obj = currentData.Find(x => x.Id == id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                  
                }
            }
            return obj;
        }
        public void UpdateEmployee(Employee update)
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                try
                {
                    var currentData = ((Employee[])ctx.Cache[CacheKey]).ToList();
                    Employee old = currentData.Find(x => x.Id == update.Id);
                    currentData.Remove(old);
                    currentData.Add(update);
                    ctx.Cache[CacheKey] = currentData.ToArray();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

        }
    }
}