using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicApi.Models;

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
        List<Employee> listE;
        List<TimeCard> listT;
        [TestInitialize()]
        public void Startup()
        {

        }
        [TestMethod()]
        public void EntityControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
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
            var testProducts = new List<Employee>();
            return testProducts;
        }
        private List<TimeCard> GetTimeCards()
        {
            var testProducts = new List<TimeCard>();
            return testProducts;
        }
    }
}