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
        public void SecretCodeTest_IsNotValidNull_ShouldIsFalse()//is not correct. Needs for edit
        {
            //arrange
            object var = null;
            SecretCodeAttribute attr = new SecretCodeAttribute();
            //act
            bool result = attr.IsValid(var);
            //assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void SecretCodeTest_IsNotValidIncorrectSymb_ShouldIsFalse()
        {
            //arrange
            object var = "jafaratatatatatatatatata";
            SecretCodeAttribute attr = new SecretCodeAttribute();
            //act
            bool result = attr.IsValid(var);
            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SecretCodeTest_IsNotValidIncorrectData_ShouldIsFalse()
        {
            //arrange
            object var = "---";
            SecretCodeAttribute attr = new SecretCodeAttribute();
            //act
            bool result = attr.IsValid(var);
            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SecretCodeTest_IsValidCorrectData_ShouldIsTrue()
        {
            //arrange
            object var = "afrts-bahab-abtga-asery";
            SecretCodeAttribute attr = new SecretCodeAttribute();
            //act
            bool result = attr.IsValid(var);
            //assert
            Assert.IsTrue(result);
        }
    }
}
