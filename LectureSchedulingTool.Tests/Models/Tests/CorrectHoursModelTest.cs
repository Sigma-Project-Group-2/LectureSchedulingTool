using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LectureSchedulingTool.Models.CustomAttributes;

namespace LectureSchedulingTool.Tests.Models.Tests
{
    [TestClass]
    public class CorrectHoursModelTest
    {
        [TestMethod]
        public void CorrectHoursTest_InvalidDataNull_ShouldIsFalse()
        {
            //arrange
            object val =null;
            CorrectHours c = new CorrectHours();
            //act
            bool result = c.IsValid(val);
            //assert
            Assert.IsFalse(result);
        }
    }
}
