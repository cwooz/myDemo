using System;
using Xunit;
using System.Net.Http;
using myApi.Controllers;
using myData.Services;

namespace myApi.Tests
{
    public class APITest
    {
        //private readonly PersonRepository _service;
        //private readonly PersonController _controller;

        //public APITest()
        //{
        //    _service = new PersonRepository();
        //    _controller = new PersonController(_service, );
        //}

        [Fact]
        public void GetPersonById()
        {
            //// Arrange
            //var controller = new PersonController();
            //controller.Request = new HttpRequestMessage();
            //controller.Configuration = new HttpConfiguration();

            //// Act
            //var response = controller.Get(1);

            //// Assert
            //Person person;
            //Assert.IsTrue(response.TryGetContentValue<Person>(out person));
            //Assert.AreEqual("John Doe", person.Name);
        }
    }
}
