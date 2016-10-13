using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KnockKnock.Web;
using KnockKnock.Web.Controllers;

namespace KnockKnock.Web.Tests.Controllers
{
    [TestClass]
    public class RedPillControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            RedPillController controller = new RedPillController();

            // Act
            IEnumerable<string> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            RedPillController controller = new RedPillController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            RedPillController controller = new RedPillController();

            // Act
            controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            RedPillController controller = new RedPillController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            RedPillController controller = new RedPillController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
