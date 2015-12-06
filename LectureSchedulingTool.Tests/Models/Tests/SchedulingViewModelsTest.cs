using System.Web.Mvc;
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
            object result = new SVM.Faculty(name, abbr);
            //assert
            Assert.IsInstanceOfType(result, typeof(SVM.Faculty));
        }
        [TestMethod]
        public void FacultyTest_ValidDataEmptyConstructor_ShouldInstanceOfType()
        {
            //arrange

            //act
            var result = new SVM.Faculty();
            //assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void FacultyTest_InvalidDataNullIdFaculty_AreNotEqual()
        {
            //arrange
            SVM.Faculty faculty = new SVM.Faculty();
            //act
            var result = faculty.id_faculty;        
            //assert
            Assert.AreNotEqual(null, result);
        }
        [TestMethod]
        public void FacultyTest_InvalidDataLongAbbr_ShouldNotEqual()
        {
            //arrange
            string name = "444444444444444444444444444444";
            string abbr = "123456789100";
            bool flag = true;
            //act
            var result = new SVM.Faculty(name, abbr);
            if (result.abbreviation.Length > 10) flag = false;
            //assert
            Assert.IsFalse(flag);
        }
        [TestMethod]
        public void FacultyTest_InvalidDataLongName_ShouldNotEqual()
        {
            //arrange
            string name = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa2";
            string abbr = "aaa";
            bool flag = true;
            //act
            var result = new SVM.Faculty(name, abbr);
            if (result.name.Length > 100) flag = false;
            //assert
            Assert.IsFalse(flag);
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
            //act
            object result = new SVM.Department(name, abbreviation,id_fac);
            //assert
            Assert.IsInstanceOfType(result, typeof(SVM.Department));
        }
        [TestMethod]
        public void DepartmentTest_ValidData_ShouldIsNotNull()
        {
            //arrange

            //act
            var result = new SVM.Department();
            //assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void DepartmentTest_InvalidDataLongAbbr_ShouldIsFalse()
        {
            //arrange
            string name = "aaaa";
            string abbr = "123456789100";
            bool flag=false;
            //act
            var result = new SVM.Department(name, abbr, 1) {id_department=1};
            if (result.abbreviation.Length <= 10) flag = true;
            //assert
            Assert.IsFalse(flag);
        }
        [TestMethod]
        public void DepartmentTest_InvalidDataLongName_ShouldIsFalse()
        {
            //arrange
            string name = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa2";
            string abbr = "aaa";
            bool flag = true;
            //act
            var result = new SVM.Department(name, abbr, 1) { id_department = 1 };
            if (result.name.Length > 100) flag = false;
            //assert
            Assert.IsFalse(flag);
        }
        [TestMethod]
        public void DepartmentTest_InvalidDataNullIdFaculty_ShouldAreNotEqual()
        {
            //arrange
            SVM.Department dept = new SVM.Department();
            //act
            var result = dept.id_faculty;
            //assert
            Assert.AreNotEqual(null, result);
        }
        [TestMethod]
        public void DepartmentTest_InvalidDataNullIdDepartment_ShouldAreNotEqual()
        {
            //arrange
            SVM.Department dept = new SVM.Department();
            //act
            var result = dept.id_department;
            //assert
            Assert.AreNotEqual(null, result);
        }
        #endregion

        #region Student_group tests

        [TestMethod]
        public void Student_groupTest_ValidData_ShouldIsInstanceOfType()
        {
            //arrange
            string name = "IF-33g";
            int count = 25;
            int dept = 1;
            //act
            var result = new SVM.Students_group(name, count, dept);
            //assert
            Assert.IsInstanceOfType(result, typeof(SVM.Students_group));
        }

        [TestMethod]
        public void Student_groupTest_ValidData_ShouldIsNotNull()
        {
            //arrange
            //act
            object result = new SVM.Students_group();
            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Student_groupTest_EmptyData_GetDept_ShouldIsNull()
        {
            //arrange
            //act
            var result = new SVM.Students_group();
            //assert
            Assert.IsNull(result.GetDepartment());
        }
        [TestMethod]
        public void Student_groupTest_EmptyData_GetFaculty_ShouldIsNull()
        {
            //arrange
            //act
            var result = new SVM.Students_group();
            //assert
            Assert.IsNull(result.GetFaculty());
        }
        #endregion

        #region TeacherTests

        [TestMethod]
        public void TeacherTest_ValidData_ShouldIsInstanceOfType()
        {
            //arrange
            string fam = "Ivanov";
            string name = "Ivan";
            string patr = "aaa";
            string workPos = "aa";
            string regalia = "aaa";
            int dept = 1;
            //act
            object result = new SVM.Teacher(fam, name, patr, workPos, regalia, dept);
            //assert
            Assert.IsInstanceOfType(result, typeof(SVM.Teacher));
        }
        [TestMethod]
        public void TeacherTest_EmptyData_ShouldIsNotNull()
        {
            //arrange
            //act
            object result = new SVM.Teacher();
            //assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TeacherTest_InvalidDataLongSurn_ShouldIsFalse()
        {
            //arrange
            string fam = "aaaaaaaaaaaaaaaaaaaaaaa";
            string name = "Ivan";
            string patr = "aaa";
            string workPos = "aa";
            string regalia = "aaa";
            int dept = 1;
            bool flag = true;
            //act
            var result = new SVM.Teacher(fam, name, patr, workPos, regalia, dept);
            if (result.surname.Length > 20) flag = false;
            //assert
            Assert.IsFalse(flag);
        }
        [TestMethod]
        public void TeacherTest_InvalidDataLongName_ShouldIsFalse()
        {
            //arrange
            string fam = "aaaaaaaaaa";
            string name = "aaaaaaaaaaaaaaaaaaaaaa";
            string patr = "aaa";
            string workPos = "aa";
            string regalia = "aaa";
            int dept = 1;
            bool flag = true;
            //act
            var result = new SVM.Teacher(fam, name, patr, workPos, regalia, dept);
            if (result.name.Length > 20) flag = false;
            //assert
            Assert.IsFalse(flag);
        }
        [TestMethod]
        public void TeacherTest_InvalidDataLongPatr_ShouldIsFalse()
        {
            //arrange
            string fam = "aaaaaaaaaa";
            string name = "aaaaaaa";
            string patr = "aaaaaaaaaaaaaaaaaaaaaa";
            string workPos = "aa";
            string regalia = "aaa";
            int dept = 1;
            bool flag = true;
            //act
            var result = new SVM.Teacher(fam, name, patr, workPos, regalia, dept);
            if (result.patronymic.Length > 20) flag = false;
            //assert
            Assert.IsFalse(flag);
        }
        [TestMethod]
        public void TeacherTest_InvalidDataLongWorkingPos_ShouldIsFalse()
        {
            //arrange
            string fam = "aaaaaaaaaa";
            string name = "aaaaaaaaaa";
            string patr = "aaa";
            string workPos = "aaaaaaaaaaaaaaaaaaaaaaaa";
            string regalia = "aaa";
            int dept = 1;
            bool flag = true;
            //act
            var result = new SVM.Teacher(fam, name, patr, workPos, regalia, dept);
            if (result.working_position.Length > 20) flag = false;
            //assert
            Assert.IsFalse(flag);
        }
        [TestMethod]
        public void TeacherTest_InvalidDataLongRegalia_ShouldIsFalse()
        {
            //arrange
            string fam = "aaaaaaaaaa";
            string name = "aaaaaaaaaa";
            string patr = "aaa";
            string workPos = "aaaaaaaa";
            string regalia = "aaaaaaaaaaaaaaaaaaaaaaaaa";
            int dept = 1;
            bool flag = true;
            //act
            var result = new SVM.Teacher(fam, name, patr, workPos, regalia, dept);
            if (result.regalia.Length > 20) flag = false;
            //assert
            Assert.IsFalse(flag);
        }
        [TestMethod]
        public void TeacherTest_InvalidDataNullIdFaculty_ShouldAreNotEqual()
        {
            //arrange
            SVM.Teacher tec = new SVM.Teacher();
            //act
            var result = tec.id_faculty;
            //assert
            Assert.AreNotEqual(null, result);
        }
        [TestMethod]
        public void TeacherTest_InvalidDataNullIdDept_ShouldAreNotEqual()
        {
            //arrange
            SVM.Teacher tec = new SVM.Teacher();
            //act
            var result = tec.id_department;
            //assert
            Assert.AreNotEqual(null, result);
        }
        #endregion
    }
}
