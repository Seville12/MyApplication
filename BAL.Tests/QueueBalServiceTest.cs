using BAL.Models;
using BAL.Services.Implementation;
using DAL.Models;
using DAL.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Tests
{
    [TestFixture]
    public class QueueBalServiceTest
    {
        Mock<IQueueDalService> queueDalService;
        QueueBalService queueService;
        DQueue model;
        BQueue modelBAL;

        [SetUp]
        public void Setup()
        {
            // Arrange
            model = new DQueue { QueueId = 1, User = "AAA", StartDate = DateTime.Parse("19.04.2017 12:03:00"), UsingTimeId = 1, MicrowaveId = 1 };
            modelBAL = new BQueue { QueueId = 1, User = "AAA", StartDate = DateTime.Parse("19.04.2017 12:03:00"), UsingTimeId = 1, MicrowaveId = 1 };

            queueDalService = new Mock<IQueueDalService>();

            queueService = new QueueBalService(queueDalService.Object);
        }

        private List<DQueue> GetTestQueue()
        {
            var queues = new List<DQueue>
            {
                new DQueue { QueueId = 1, User = "AAA", StartDate = DateTime.Parse("19.04.2017 12:03:00"), UsingTimeId = 1, MicrowaveId = 1 },
                new DQueue { QueueId = 2, User = "BBB", StartDate = DateTime.Parse("20.04.2017 12:03:00"), UsingTimeId = 2, MicrowaveId = 1 },
                new DQueue { QueueId = 3, User = "CCC", StartDate = DateTime.Parse("21.04.2017 12:03:00"), UsingTimeId = 3, MicrowaveId = 1 },
            };
            return queues;
        }

        [Test]
        public async Task GetQueueBALModel()
        {
            // Arrange
            queueDalService.Setup(m => m.GetQueue("User")).ReturnsAsync(GetTestQueue());

            QueueBalService _queueService = new QueueBalService(queueDalService.Object);

            // Act
            var result = await _queueService.GetQueue("User");

            // Assert
            Assert.AreEqual(GetTestQueue().Count, result.Count);
            Assert.That(result, Is.TypeOf<List<BQueue>>());
        }
    }
}
