using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LectureSchedulingTool.Models;
using LectureSchedulingTool.Controllers;

namespace LectureSchedulingTool.Tests
{
    /// <summary>
    /// Summary description for SecretCodeAttributeTest
    /// </summary>
    [TestClass]
    public class SecretCodeAttributeTest
    {

        #region Test for null data
        [TestMethod]
        public void SecretCodeAttr_InvalidDataNull_ShouldGetErrMsg()
        {
            //arrange
            SecretCodeAttribute attr = new SecretCodeAttribute();
            //act
            bool result = attr.IsValid("");
            //assert
            Assert.IsFalse(result);
        }

        #endregion

        #region Tests for invalid data

        [TestCategory("Invalid data"), TestMethod() ]
        public void SecretCodeAttr_InvalidData23_ShouldSetFalse()
        {
            //arrange
            SecretCodeAttribute attr = new SecretCodeAttribute();
            string code = "45201-fffff-yyyyyy-ffff";
            //act
            bool result = attr.IsValid(code);
            //assert
            Assert.IsFalse(result);
        }

        [TestCategory("Invalid data"), TestMethod()]
        public void SecretCodeAttr_InvalidDataLess_ShouldSetFalse() {
            //arrange
            SecretCodeAttribute attr = new SecretCodeAttribute();
            string code = "FFFFF-77777-FFFFF-FFFF";
            //act
            bool result = attr.IsValid(code);
            //assert
            Assert.IsFalse(result);
        }

        [TestCategory("Invalid data"), TestMethod()]
        public void SecretCodeAttr_InvalidDataBigger_ShouldSetFalse()
        {
            //arrange
            SecretCodeAttribute attr = new SecretCodeAttribute();
            string code = "adser-fgtyf-fhyfhf-bfhff";
            //act
            bool result = attr.IsValid(code);
            //assert
            Assert.IsFalse(result);
        }

        [TestCategory("Invalid data"), TestMethod()]
        public void SecretCodeAttr_InvalidDataDash_ShouldSetFalse()
        {
            //arrange
            SecretCodeAttribute attr = new SecretCodeAttribute();
            string code = "-----------------------";
            //act
            bool result = attr.IsValid(code);
            //assert
            Assert.IsFalse(result);
        }

        [TestCategory("Invalid data"), TestMethod()]
        public void SecretCodeAttr_InvalidDataSymb_ShouldSetFalse()
        {
            //arrange
            SecretCodeAttribute attr = new SecretCodeAttribute();
            string code = "458uhgfredsbhhgfrsaewqq";
            //act
            bool result = attr.IsValid(code);
            //assert
            Assert.IsFalse(result);
        }

        [TestCategory("Invalid data"), TestMethod()]
        public void SecretCodeAttr_InvalidDataSpace_ShouldSetFalse()
        {
            //arrange
            SecretCodeAttribute attr = new SecretCodeAttribute();
            string code = "     -     -     -     ";
            //act
            bool result = attr.IsValid(code);
            //assert
            Assert.IsFalse(result);
        }

        [TestCategory("Invalid data"), TestMethod()]
        public void SecretCodeAttr_InvalidDataSameSymb_ShouldSetFalse()
        {
            //arrange
            SecretCodeAttribute attr = new SecretCodeAttribute();
            string code = "aaaaa-aaaaa-aaaaa-aaaaa";
            //act
            bool result = attr.IsValid(code);
            //assert
            Assert.IsFalse(result);
        }

        #endregion

        #region Test for correct data

        [TestCategory("Invalid data"), TestMethod()]
        public void SecretCodeAttr_ValidData_ShouldSetTrue()
        {
            //arrange
            SecretCodeAttribute attr = new SecretCodeAttribute();
            string code = "452Fs-aSERc-78GFc-ERTcc";
            //act
            bool result = attr.IsValid(code);
            //assert
            Assert.IsTrue(result);
        }

        #endregion
    }
}
