using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LectureSchedulingTool.Controllers;
using LectureSchedulingTool.Models;
using Moq;

namespace LectureSchedulingTool.Tests.Controllers.Tests
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void RegisterTest_ShouldIsNotNull()
        {
            //arrange
            AccountController controller = new AccountController();
            //act
            ViewResult result = controller.Register() as ViewResult;
            //assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void LoginTest_ShouldIsNotNull()
        {
            //arrange
            AccountController controller = new AccountController();
            //act
            ViewResult result = controller.Login("") as ViewResult;
            //assert
            Assert.IsNotNull(result);
        }
    }
}
