using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KnockKnock.Web;
using KnockKnock.Web.Controllers;

namespace KnockKnock.Web.Tests.Controllers
{
    [TestClass]
    public class RedPillControllerTest
    {
        [TestMethod]
        public void GetToken()
        {
            // Arrange
            RedPillController controller = new RedPillController();

            // Act
            string result = controller.GetToken();

            // Assert
            result.Should().NotBeEmpty();
        }

        [TestMethod]
        public void GetFibonacci()
        {
            // Arrange
            RedPillController controller = new RedPillController();

            // Act
            long result = controller.GetFibonacci(5);

            // Assert
            result.ShouldBeEquivalentTo(120);
        }

        [TestMethod]
        public void ReverseWords()
        {
            // Arrange
            RedPillController controller = new RedPillController();

            // Act
            string result = controller.ReverseWords("Knock Knock Readify");

            // Assert
            result.ShouldBeEquivalentTo("kconK kconK yfidaeR");
        }

        [TestMethod]
        public void GetTriangleType()
        {
            // Arrange
            RedPillController controller = new RedPillController();

            // Act
            string scalene = controller.GetTriangleType(3, 4, 5);
            string isosceles = controller.GetTriangleType(5, 3, 3);
            string equilateral = controller.GetTriangleType(3, 3, 3);
            string invalid = controller.GetTriangleType(5, 3, 8);

            // Assert
            scalene.ShouldBeEquivalentTo("Scalene");
            isosceles.ShouldBeEquivalentTo("Isosceles");
            equilateral.ShouldBeEquivalentTo("Equilateral");
            invalid.ShouldBeEquivalentTo("Invalid");
        }
    }
}
