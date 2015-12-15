using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LectureSchedulingTool.Controllers;
using LectureSchedulingTool.Models;
using Moq;

namespace LectureSchedulingTool.Tests.Controllers.Tests
{
    [TestClass]
    public class ManageControllerTest
    {
        [TestMethod]
        public void ChangePasswordTest_ShouldIsNotNull()
        {
            //arrange
            ManageController controller = new ManageController();
            //act
            ViewResult result = controller.ChangePassword() as ViewResult;
            //assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void SecretCodeTest_ActionA_ShouldIsNotNull()//is not correct. Needs for edit
        {
            //arrange
            var mock = new Mock<ManageController>();
            mock.SetupSet(x => x.SecretCode('a'));
            ManageController controller = new ManageController(mock.Object);
            //act
            ViewResult result = controller.SecretCode() as ViewResult;
            //assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void SecretCodeTest_ActionR_ShouldIsNotNull()
        {
            //arrange
            var mock = new Mock<ManageController>();
            mock.SetupSet(x => x.SecretCode('r'));
            ManageController controller = new ManageController(mock.Object);
            //act
            ViewResult result = controller.SecretCode() as ViewResult;
            //assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void IndexTest_ShouldIsNotNull()
        {
            //arrange
            var mock = new Mock<IndexViewModel>();
          //  mock.Setup(x => x.HaveDataInTables);
            ManageController controller = new ManageController(mock.Object);
            //act
            ViewResult result = controller.Index(mock.Object) as ViewResult;
            //assert
            Assert.IsNotNull(result);
        }
    }
}
