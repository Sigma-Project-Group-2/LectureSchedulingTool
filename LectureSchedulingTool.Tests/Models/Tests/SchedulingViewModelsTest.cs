using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LectureSchedulingTool.Models;

namespace LectureSchedulingTool.Tests.Models.Tests
{
    [TestClass]
    public class SchedulingViewModelsTest
    {
        [TestClass]
        public class Faculty_Model_Test
        {
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
            public void FacultyTest_ValidDataEmptyConstructor_ShouldIsNotNull()
            {
                //arrange

                //act
                var result = new SVM.Faculty();
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void FacultyTest_InvalidDataNullIdFaculty_ShouldIsNotNull()
            {
                //arrange
                SVM.Faculty faculty = new SVM.Faculty();
                //act
                var result = faculty.id_faculty;
                //assert
                Assert.IsNotNull(result);
            }
        }
        [TestClass]
        public class Department_Model_Test
        {
            [TestMethod]
            public void DepartmentTest_ValidData_ShouldIsInstanceOfType()
            {
                //arrange
                string name = "Informatic";
                string abbreviation = "I";
                int id_fac = 1;
                //act
                object result = new SVM.Department(name, abbreviation, id_fac);
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
            public void DepartmentTest_InvalidDataNullIdFaculty_ShouldIsNotNull()
            {
                //arrange
                SVM.Department dept = new SVM.Department();
                //act
                var result = dept.id_faculty;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void DepartmentTest_InvalidDataNullIdDepartment_ShouldIsNotNull()
            {
                //arrange
                SVM.Department dept = new SVM.Department();
                //act
                var result = dept.id_department;
                //assert
                Assert.IsNotNull(result);
            }
        }
        [TestClass]
        public class StudentGroup_Model_Test
        {
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
            public void Student_groupTest_InvalidDataIdFaculty_ShouldIsNotNull()
            {
                //arrange
                SVM.Students_group gr = new SVM.Students_group();
                //act
                var result = gr.id_faculty;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void Student_groupTest_InvalidDataIdDepartment_ShouldIsNotNull()
            {
                //arrange
                SVM.Students_group gr = new SVM.Students_group();
                //act
                var result = gr.id_department;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void Student_groupTest_InvalidDataNullIdGroup_ShouldIsNotNull()
            {
                //arrange
                SVM.Students_group gr = new SVM.Students_group();
                //act
                var result = gr.id_students_group;
                //assert
                Assert.IsNotNull(result);
            }
        }
        [TestClass]
        public class Teacher_Model_Test
        {
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
                Assert.AreEqual(result.GetType(), typeof(SVM.Teacher));
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
            public void TeacherTest_InvalidDataNullIdFaculty_ShouldIsNotNull()
            {
                //arrange
                SVM.Teacher tec = new SVM.Teacher();
                //act
                var result = tec.id_faculty;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void TeacherTest_InvalidDataNullIdDept_ShouldIsNotNull()
            {
                //arrange
                SVM.Teacher tec = new SVM.Teacher();
                //act
                var result = tec.id_department;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void TeacherTest_InvalidDataNullIdTeach_ShouldIsNotNull()
            {
                //arrange
                SVM.Teacher tec = new SVM.Teacher();
                //act
                object result = tec.id_teacher;
                //assert
                Assert.IsNotNull(result);
            }
        }
        [TestClass]
        public class Subject_Model_Test
        {
            [TestMethod]
            public void SubjectTest_ValidData_ShouldIsInstanceOfType()
            {
                //arrange
                string name = "Modeling data";
                string type = "Specialize";
                int dept = 1;
                //act
                object result = new SVM.Subject(name, type, dept);
                //assert
                Assert.IsInstanceOfType(result, typeof(SVM.Subject));
            }
            [TestMethod]
            public void SubjectTest_EmptyData_ShouldIsNotNull()
            {
                //arrange
                //act
                object result = new SVM.Subject();
                //assert
                Assert.IsNotNull(result);
            }

            [TestMethod]
            public void SubjectTest_IsNotNUllIdFaculty_ShouldIsNotNull()
            {
                //arrange
                SVM.Subject sbj = new SVM.Subject();
                //act
                object result = sbj.id_faculty;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void SubjectTest_IsNotNullIDDepartment_ShouldIsNotNull()
            {
                //arrange
                SVM.Subject sbj = new SVM.Subject();
                //act
                var result = sbj.id_department;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void SubjectTest_IsNotNullIdSubj_ShouldIsNotNull()
            {
                //arrange
                SVM.Subject sbj = new SVM.Subject();
                //act
                var result = sbj.id_subject;
                //assert
                Assert.IsNotNull(result);
            }
        }
        [TestClass]
        public class Classroom_Model_Test
        {
            [TestMethod]
            public void ClassroomTest_ValidDataCreate_ShouldIsInstanceOfType()
            {
                //arrange
                string num = "aa1";
                int contain = 10;
                int dept = 1;
                //act
                object result = new SVM.Classroom(num, contain, dept);
                //assert
                Assert.IsInstanceOfType(result, typeof(SVM.Classroom));
            }
            [TestMethod]
            public void ClassroomTest_EmptyData_ShouldIsNotNull()
            {
                //act
                object result = new SVM.Classroom();
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void ClassroomTest_IsNullIdFaculty_ShouldIsNotNull()
            {
                //arrange
                SVM.Classroom clr = new SVM.Classroom();
                //act
                object result = clr.id_faculty;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void ClassroomTest_IsNullIdDepartment_ShouldIsNotNull()
            {
                //arrange
                SVM.Classroom clr = new SVM.Classroom();
                //act
                object result = clr.id_department;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void ClassroomTest_IsNullIdClassroom_ShouldIsNotNull()
            {
                //arrange
                SVM.Classroom clr = new SVM.Classroom();
                //act
                object result = clr.id_classroom;
                //assert
                Assert.IsNotNull(result);
            }
        }
        [TestClass]
        public class StudentGroupLoad_Model_Test
        {
            [TestMethod]
            public void StudentGroupLoadTest_ValidData_ShouldIsInstanceOfType()
            {
                //arrange
                int hours = 1;
                int id = 1;
                int subj = 1;
                //act
                object result = new SVM.Students_group_load(hours, id, subj);
                //assert
                Assert.IsInstanceOfType(result, typeof(SVM.Students_group_load));
            }
            [TestMethod]
            public void StudentGroupLoadTest_ValidDataEmpty_IsNotNull()
            {
                //act
                object result = new SVM.Students_group_load();
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void StudentGroupLoadTest_InvalidDataNullIdFaculty_ShouldIsNotNull()
            {
                //arrange
                SVM.Students_group_load sgrl= new SVM.Students_group_load();
                //act
                var result = sgrl.id_faculty;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void StudentGroupLoadTest_InvalidDataNullIdDept_ShouldIsNotNull()
            {
                //arrange
                SVM.Students_group_load sgrl = new SVM.Students_group_load();
                //act
                var result = sgrl.id_department;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void StudentGroupLoadTest_InvalidDataNullIdStGr_ShouldIsNotNull()
            {
                //arrange
                SVM.Students_group_load sgrl = new SVM.Students_group_load();
                //act
                var result = sgrl.id_students_group;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void StudentGroupLoadTest_InvalidDataNullIdStGrLoad_ShouldIsNotNull()
            {
                //arrange
                SVM.Students_group_load sgrl = new SVM.Students_group_load();
                //act
                var result = sgrl.id_students_group_load;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void StudentGroupLoadTest_InvalidDataNullIdSubj_ShouldIsNotNull()
            {
                //arrange
                SVM.Students_group_load sgrl = new SVM.Students_group_load();
                //act
                var result = sgrl.id_subject;
                //assert
                Assert.IsNotNull(result);
            }
        }
        [TestClass]
        public class TeacherLoad_Model_Test
        {
            [TestMethod]
            public void TeacherLoadTest_ValidData_ShouldIsInstanceOfType()
            {
                //arrange
                int id_t = 1;
                int id_s = 1;
                //act
                object result = new SVM.Teacher_load(id_s, id_t);
                //assert
                Assert.IsInstanceOfType(result,typeof(SVM.Teacher_load));
            }
            [TestMethod]
            public void TeacherLoadTest_EmptyConstructor_ShouldIsNotNull()
            {
                //act
                object result = new SVM.Teacher_load();
                //assert
                Assert.IsNotNull(result); 
            }
            [TestMethod]
            public void TeacherLoadTest_InvalidDataNullIdFaculty_ShouldIsNotNull()
            {
                //arrange
                SVM.Teacher_load tchrl = new SVM.Teacher_load();
                //act
                object result = tchrl.id_faculty;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void TeacherLoadTest_InvalidDataNullIdDept_ShouldIsNotNull()
            {
                //arrange
                SVM.Teacher_load tchrl = new SVM.Teacher_load();
                //act
                object result = tchrl.id_department;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void TeacherLoadTest_InvalidDataNullIdTeacher_ShouldIsNotNull()
            {
                //arrange
                SVM.Teacher_load tchrl = new SVM.Teacher_load();
                //act
                object result = tchrl.id_teacher;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void TeacherLoadTest_InvalidDataNullIdTeacherLoad_ShouldIsNotNull()
            {
                //arrange
                SVM.Teacher_load tchrl = new SVM.Teacher_load();
                //act
                object result = tchrl.id_teacher_load;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void TeacherLoadTest_InvalidDataNullIdSubj_ShouldIsNotNull()
            {
                //arrange
                SVM.Teacher_load tchrl = new SVM.Teacher_load();
                //act
                object result = tchrl.id_subject;
                //assert
                Assert.IsNotNull(result);
            }
        }
        [TestClass]
        public class Lesson_Model_Test
        {
            [TestMethod]
            public void LessonTest_ValidData_ShouldIsInstanceOfType()
            {
                //arrange
                int week = 1;
                int lesson = 5;
                int classroom = 2;
                int groupLoad = 1;
                int teacherLoad = 8;
                //act
                object result = new SVM.Lesson(week, lesson, classroom, groupLoad, teacherLoad);
                //assert
                Assert.IsInstanceOfType(result, typeof(SVM.Lesson));
            }
            [TestMethod]
            public void LessonTest_ValidDataOnlyGroup_ShouldIsInstanceOfType()
            {
                //arrange
                int groupLoad = 1;
                //act
                object result = new SVM.Lesson(groupLoad);
                //assert
                Assert.IsInstanceOfType(result, typeof(SVM.Lesson));
            }
            [TestMethod]
            public void LessonTest_EmptyConstructor_IsNotNull()
            {
                //act
                object result = new SVM.Lesson();
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void LessonTest_InvalidDataNullIdFaculty_ShouldIsNotNull()
            {
                //arrange
                SVM.Lesson lesson = new SVM.Lesson();
                //act
                object result = lesson.id_faculty;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void LessonTest_InvalidDataNullIdDepartment_ShouldIsNotNull()
            {
                //arrange
                SVM.Lesson lesson = new SVM.Lesson();
                //act
                object result = lesson.id_department;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void LessonTest_InvalidDataNullIdClass_ShouldIsNotNull()
            {
                //arrange
                SVM.Lesson lesson = new SVM.Lesson();
                //act
                object result = lesson.id_classroom;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void LessonTest_InvalidDataNullIdLesson_ShouldIsNotNull()
            {
                //arrange
                SVM.Lesson lesson = new SVM.Lesson();
                //act
                object result = lesson.id_lesson;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void LessonTest_InvalidDataNullIdStudGroup_ShouldIsNotNull()
            {
                //arrange
                SVM.Lesson lesson = new SVM.Lesson();
                //act
                object result = lesson.id_students_group;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void LessonTest_InvalidDataNullIdStudGroupLoad_ShouldIsNotNull()
            {
                //arrange
                SVM.Lesson lesson = new SVM.Lesson();
                //act
                object result = lesson.id_students_group_load;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void LessonTest_InvalidDataNullIdSubject_ShouldIsNotNull()
            {
                //arrange
                SVM.Lesson lesson = new SVM.Lesson();
                //act
                object result = lesson.id_subject;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void LessonTest_InvalidDataNullIdTeacher_ShouldIsNotNull()
            {
                //arrange
                SVM.Lesson lesson = new SVM.Lesson();
                //act
                object result = lesson.id_teacher;
                //assert
                Assert.IsNotNull(result);
            }
            [TestMethod]
            public void LessonTest_InvalidDataNullIdTeacherLoad_ShouldIsNotNull()
            {
                //arrange
                SVM.Lesson lesson = new SVM.Lesson();
                //act
                object result = lesson.id_teacher_load;
                //assert
                Assert.IsNotNull(result);
            }
        }
    }
}
