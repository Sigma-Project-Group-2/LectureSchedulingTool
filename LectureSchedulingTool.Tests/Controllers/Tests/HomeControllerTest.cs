using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LectureSchedulingTool.Controllers;
using LectureSchedulingTool.Models;
using Moq;
namespace LectureSchedulingTool.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            
            var mock = new Mock<SchedulingAlgorithm>();
            mock.Setup(x => x.Generate());
            HomeController controller = new HomeController(mock.Object);
            // Act
            ViewResult result = controller.Contact() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
