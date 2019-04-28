using Microsoft.AspNetCore.Mvc;
using MyApplication.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApplication.Tests
{
    [TestFixture]
    public class ErrorControllerTest
    {
        private readonly ErrorController _controller;
        public ErrorControllerTest()
        {
            _controller = new ErrorController();
        }

        [Test]
        public void ErrorRedirect()
        {
            //Arrange

            //Act
            var result = _controller.Error(404);
            //Assert
            Assert.That(result, Is.TypeOf<ViewResult>());
        }
    }
}
