using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicApi.Models;
using BasicApi.Services;

namespace BasicApi.Controllers.Tests
{
    [TestClass()]
    public class EntityControllerTests
    {
        //make mock data to represent the data in the models
        //make mock respositories 
        //will make changes to mock data and as well in mock repository , then do assertions to check both
        //make mock controller to make mock services
        //use controller functionality and assert the return values
        //might have to edit controller to return entites instead of strings
        //make repostiorry public?

        List<Employee> listE;
        List<TimeCard> listT;'
        static readonly Random rnd = new Random();
        [TestInitialize()]
        public void Startup()
        {
            //initalize the repositories? or jsuti tnmialzie for each testmethod?
        }
        [TestMethod()]
        public void EntityControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Should_GetAllEmployees()
        {
            //intialize repostiroy,then do a method
          
            var Employees = GetTestEmployees();
            var TimeCards = GetTestTimeCards();
            var employeeRepository = new EmployeeRepository(Employees.ToArray());
            var timecardRepository = new TimeCardRepository(TimeCards.ToArray());
            var controller = new EntityController(employeeRepository,timecardRepository);
            Assert.Equals(Employees,employeeRepository.GetAllEmployees());
            Assert.Fail();
        }

        [TestMethod()]
        public void Should_GetAnemployee()
        {
            var Employees = GetTestEmployees();
            var employeeRepository = new EmployeeRepository(Employees.ToArray());
            Assert.Equals(Employees.Find(x=> x.Id =="1"), employeeRepository.GetEmployee("1"));
            Assert.Fail();
        }

        [TestMethod()]
        public void PutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostCardTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCardTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCardsTest()
        {
            Assert.Fail();
        }
        private List<Employee> GetTestEmployees()
        {
            var testEmployees = new List<Employee>();
            testEmployees.Add(new Employee {Id="1",Name="Travis",Active=true });
            testEmployees.Add(new Employee {Id="2",Name="Travis",Active=true});
            testEmployees.Add(new Employee {Id="3",Name="John",Active=false});
            return testEmployees;
        }
        private List<TimeCard> GetTestTimeCards()
        {
            var testTimeCards = new List<TimeCard>();
            testTimeCards.Add(new TimeCard { Id = "1", Hours = 3.5f, Date = GetRandomDate(new DateTime(2016, 5, 1), new DateTime(2016, 9, 1)) });
            testTimeCards.Add(new TimeCard { Id = "1", Hours = 0.5f, Date = GetRandomDate(new DateTime(2016, 5, 1), new DateTime(2016, 9, 1)) });
            testTimeCards.Add(new TimeCard { Id = "2", Hours = 4f, Date = GetRandomDate(new DateTime(2016, 5, 1), new DateTime(2016, 9, 1)) });
            return testTimeCards;
        }
        public static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }
    }
}