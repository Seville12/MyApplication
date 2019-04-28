using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyApplication.Controllers;
using MyApplication.Models;
using MyApplication.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Tests
{
    [TestFixture]
    public class QueuesControllerTest
    {
        QueuesController controller;
        QueuesController controllerWithContext;
        Mock<IQueueService> queues;
        Queue model;

        [SetUp]
        public void Setup()
        {
            // Arrange
            model = new Queue { QueueId = 1, User = "AAA", StartDate = DateTime.Parse("19.04.2017 12:03:00"), UsingTimeId = 1, MicrowaveId = 1 };

            queues = new Mock<IQueueService>();

            controller = new QueuesController(queues.Object);

            controllerWithContext = new QueuesController(queues.Object);
            controllerWithContext.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, "User")
                    }, "someAuthTypeName"))
                }
            };
        }

        private List<Queue> GetTestQueue()
        {
            var queues = new List<Queue>
            {
                new Queue { QueueId = 1, User = "AAA", StartDate = DateTime.Parse("19.04.2017 12:03:00"), UsingTimeId = 1, MicrowaveId = 1 },
                new Queue { QueueId = 2, User = "BBB", StartDate = DateTime.Parse("20.04.2017 12:03:00"), UsingTimeId = 2, MicrowaveId = 1 },
                new Queue { QueueId = 3, User = "CCC", StartDate = DateTime.Parse("21.04.2017 12:03:00"), UsingTimeId = 3, MicrowaveId = 1 },
            };
            return queues;
        }

        [Test]
        public async Task IndexViewResulListOfQueue()
        {
            // Arrange
            queues.Setup(m => m.GetQueue("User")).ReturnsAsync(GetTestQueue());

            var contr = new QueuesController(queues.Object);
            contr.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, "User")
                    }, "someAuthTypeName"))
                }
            };

            // Act
            var result = await contr.Index();

            // Assert
            Assert.That(result, Is.TypeOf<ViewResult>());
            Assert.IsAssignableFrom<List<Queue>>((result as ViewResult).Model);
            Assert.AreEqual(GetTestQueue().Count, ((result as ViewResult).Model as List<Queue>).Count);
        }

        [Test]
        public async Task IndexQueueArray()
        {
            // Arrange

            // Act
            var result = await controllerWithContext.Index();

            // Assert
            Assert.That(result, Is.TypeOf<ViewResult>());
            Assert.IsAssignableFrom<Queue[]>((result as ViewResult).Model);
        }
    }
}
