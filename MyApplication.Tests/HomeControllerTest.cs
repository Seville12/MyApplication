using Microsoft.AspNetCore.Mvc;
using MyApplication.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApplication.Tests
{
    [TestFixture]
    public class HomeControllerTest
    {
        private readonly HomeController _controller;

        public HomeControllerTest()
        {
            _controller = new HomeController();
        }

        [Test]
        public void IndexViewResultNotNull()
        {
            // Arrange

            //Act
            var result = _controller.Index();
            // Assert
            Assert.NotNull(result as ViewResult);
        }

        [Test]
        public void IndexViewEqualIndexCshtml()
        {
            // Arrange

            //Act
            var result = _controller.Index();
            //Assert
            Assert.AreEqual("Index", (result as ViewResult).ViewName);
        }

        [Test]
        public void IndexViewResultIsViewResultObject()
        {
            // Arrange

            // Act
            var result = _controller.Index();

            // Assert
            Assert.That(result, Is.TypeOf<ViewResult>());
        }
    }
}
