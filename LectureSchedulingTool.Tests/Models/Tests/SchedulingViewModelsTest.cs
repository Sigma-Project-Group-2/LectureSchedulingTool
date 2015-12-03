using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LectureSchedulingTool.Models;
namespace LectureSchedulingTool.Tests.Models.Tests
{
    [TestClass]
    public class SchedulingViewModelsTest
    {

        #region FacultyTests

        [TestMethod]
        public void FacultyTest_ValidData_ShouldIsInstanceOfType()
        {
            //arrange
            string name = "Sociology";
            string abbr = "S";
            //act
            object result = new Faculty(name, abbr);
            //assert
            Assert.IsInstanceOfType(result, typeof(Faculty));
        }
        [TestMethod]
        public void FacultyTest_ValidDataEmptyConstructor_ShouldInstanceOfType()
        {
            //arrange

            //act
            var result = new Faculty();
            //assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void FacultyTest_InvalidDataLessIdFaculty_ShouldNotEqualErrMsg()
        {
            //arrange
            Faculty faculty = new Faculty();
            //act
            var result = faculty.id_faculty;
            //assert
            Assert.AreNotEqual(-1, result);
        }
        [TestMethod]
        public void FacultyTest_InvalidDataLongAbbr_ShouldNotEqual()
        {
            //arrange
            string name = "444444444444444444444444444444";
            string abbr = "12345678910";
            //act
            Faculty result = new Faculty(name, abbr);
            //assert
            Assert.AreNotEqual(10, result.abbreviation);
        }
        [TestMethod]
        public void FacultyTest_InvalidDataLongName_ShouldNotEqual()
        {
            //arrange
            string name = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa2";
            string abbr = "aaa";
            //act
            Faculty result = new Faculty(name, abbr);
            //assert
            Assert.AreNotEqual(100, result.name.Length);
        }
        #endregion

        #region DepartmentTests

        [TestMethod]
        public void DepartmentTest_ValidData_ShouldIsInstanceOfType()
        {
            //arrange
            string name = "Informatic";
            string abbreviation = "I";
            int id_fac = 1;
            int producing = 1;
            //act
            object result = new Department(name, abbreviation,producing,id_fac);
            //assert
            Assert.IsInstanceOfType(result, typeof(Department));
        }
        [TestMethod]
        public void DepartmentTest_ValidData_ShouldIsNotNull()
        {
            //arrange

            //act
            var result = new Department();
            //assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void DepartmentTest_InvalidDataLongAbbr_ShouldAreNotEqual()
        {
            //arrange
            string name = "aaaa";
            string abbr = "123456789100";
            //act
            Department result = new Department(name, abbr, 1, 1) {id_department=1};
            //assert
            Assert.AreNotEqual(10, result.abbreviation.Length);
        }
        [TestMethod]
        public void DepartmentTest_InvalidDataLongName_ShouldAreNotEqual()
        {
            //arrange
            string name = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa2";
            string abbr = "aaa";
            //act
            Department result = new Department(name, abbr, 1, 1) { id_department = 1 };
            //assert
            Assert.AreNotEqual(100, result.name.Length);
        }
        [TestMethod]
        public void DepartmentTest_InvalidDataLessIdFaculty_ShouldAreNotEqual()
        {
            //arrange
            Department dept = new Department();
            //act
            var result = dept.id_faculty;
            //assert
            Assert.AreNotEqual(-1, result);
        }
        [TestMethod]
        public void DepartmentTest_InvalidDataLessIdDepartment_ShouldAreNotEqual()
        {
            //arrange
            Department dept = new Department();
            //act
            var result = dept.id_department;
            //assert
            Assert.AreNotEqual(-1, result);
        }
        [TestMethod]
        public void DepartmentTest_InvalidDataIdProducing_ShouldAreNotEqual()
        {
            //arrange
            Department dept = new Department();
            //act
            var result = dept.is_producing;
            //assert
            Assert.AreNotEqual(-1, result);
        }
        #endregion
    }
}
