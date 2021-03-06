﻿using System.Linq;
using System.Web.Mvc;
using LectureSchedulingTool.Models.CustomAttributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureSchedulingTool.Models
{
    public class SVM
    {
        private static SchedulingContext DB = new SchedulingContext();

        //Модель факультета
        public class Faculty
        {
            [Key]
            public int id_faculty { get; set; }

            [Required]
            [StringLength(100)]
            public string name { get; set; }

            [Required]
            [StringLength(10)]
            public string abbreviation { get; set; }

            public Faculty()
            {
                name = "";
                abbreviation = "";
            }
            public Faculty(string name, string abbreviation)
            {
                this.name = name;
                this.abbreviation = abbreviation;
            }

            public override string ToString()
            {
                return abbreviation + " (" + name + ")";
            }
        }

        //Модель кафедры
        public class Department
        {
            [Key]
            public int id_department { get; set; }

            [Required]
            [StringLength(100)]
            public string name { get; set; }

            [Required]
            [StringLength(10)]
            public string abbreviation { get; set; }

            [Required]
            public int id_faculty { get; set; }

            public Faculty GetFaculty()
            {
                try
                {
                    return DB.Faculty.Find(this.id_faculty);
                }
                catch
                {
                    return null;
                }
            }

            public Department()
            {
                name = "";
                abbreviation = "";
            }
            public Department(string name, string abbreviation, int id_faculty)
            {
                this.name = name;
                this.abbreviation = abbreviation;
                this.id_faculty = id_faculty;
            }

            public override string ToString()
            {
                return abbreviation + " (" + name + ")";
            }
        }

        //Модель студенческой группы
        public class Students_group
        {
            [Key]
            public int id_students_group { get; set; }

            [Required]
            [StringLength(20)]
            public string name { get; set; }

            [Required]
            [Range(1, 10000)]
            public int people_amount { get; set; }

            [Required]
            public int id_department { get; set; }

            [NotMapped]
            public int id_faculty
            {
                get
                {
                    try
                    {
                        return GetFaculty().id_faculty;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }

            public Faculty GetFaculty()
            {
                try
                {
                    return GetDepartment().GetFaculty();
                }
                catch
                {
                    return null;
                }
            }
            public Department GetDepartment()
            {
                try
                {
                    return DB.Department.Find(this.id_department);
                }
                catch
                {
                    return null;
                }
            }

            public Students_group()
            {
                name = "";
            }
            public Students_group(string name, int people_amount, int id_department)
            {
                this.name = name;
                this.people_amount = people_amount;
                this.id_department = id_department;
            }

            public override string ToString()
            {
                return name;
            }
        }

        //Модель преподавателя
        public class Teacher
        {
            [Key]
            public int id_teacher { get; set; }

            [Required]
            [StringLength(20)]
            public string surname { get; set; }

            [Required]
            [StringLength(20)]
            public string name { get; set; }

            [Required]
            [StringLength(20)]
            public string patronymic { get; set; }

            [Required]
            [StringLength(30)]
            public string working_position { get; set; }

            [StringLength(20)]
            public string regalia { get; set; }

            [Required]
            public int id_department { get; set; }

            [NotMapped]
            public int id_faculty
            {
                get
                {
                    try
                    {
                        return GetFaculty().id_faculty;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }

            public Faculty GetFaculty()
            {
                try
                {
                    return GetDepartment().GetFaculty();
                }
                catch
                {
                    return null;
                }
            }
            public Department GetDepartment()
            {
                try
                {
                    return DB.Department.Find(this.id_department);
                }
                catch
                {
                    return null;
                }
            }

            public Teacher()
            {
                surname = "";
                name = "";
                patronymic = "";
                working_position = "";
                regalia = "";
            }
            public Teacher(string surname, string name, string patronymic, string working_position, string regalia, int id_department)
            {
                this.surname = surname;
                this.name = name;
                this.patronymic = patronymic;
                this.working_position = working_position;
                this.regalia = regalia;
                this.id_department = id_department;
            }

            public override string ToString()
            {
                return surname + " " + name + (patronymic.Length > 0 ? " " + patronymic : "");
            }
        }

        //Модель предмета
        public class Subject
        {
            [Key]
            public int id_subject { get; set; }

            [Required]
            [StringLength(50)]
            public string name { get; set; }

            [Required]
            [StringLength(20)]
            public string type { get; set; }

            [Required]
            public int id_department { get; set; }

            [NotMapped]
            public int id_faculty
            {
                get
                {
                    try
                    {
                        return GetFaculty().id_faculty;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }

            public Faculty GetFaculty()
            {
                try
                {
                    return GetDepartment().GetFaculty();
                }
                catch
                {
                    return null;
                }
            }
            public Department GetDepartment()
            {
                try
                {
                    return DB.Department.Find(this.id_department);
                }
                catch
                {
                    return null;
                }
            }

            public Subject()
            {
                name = "";
                type = "";
            }
            public Subject(string name, string type, int id_department)
            {
                this.name = name;
                this.type = type;
                this.id_department = id_department;
            }

            public override string ToString()
            {
                return name + " (" + type + ")";
            }
        }

        //Модель аудитории
        public class Classroom
        {
            [Key]
            public int id_classroom { get; set; }

            [Required]
            [StringLength(20)]
            public string number { get; set; }

            [Required]
            [Range(1, 10000)]
            public int people_capacity { get; set; }

            [Required]
            public int id_department { get; set; }

            [NotMapped]
            public int id_faculty
            {
                get
                {
                    try
                    {
                        return GetFaculty().id_faculty;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }

            public Faculty GetFaculty()
            {
                try
                {
                    return GetDepartment().GetFaculty();
                }
                catch
                {
                    return null;
                }
            }
            public Department GetDepartment()
            {
                try
                {
                    return DB.Department.Find(this.id_department);
                }
                catch
                {
                    return null;
                }
            }

            public Classroom()
            {
                number = "";
            }
            public Classroom(string number, int people_capacity, int id_department)
            {
                this.number = number;
                this.people_capacity = people_capacity;
                this.id_department = id_department;
            }

            public override string ToString()
            {
                return number;
            }
        }

        //Модель загрузки группы
        public class Students_group_load
        {
            [Key]
            public int id_students_group_load { get; set; }

            [Required]
            //[CorrectHours]
            [Range(1, 10000)]
            public int hours { get; set; }

            [Required]
            public int id_students_group { get; set; }

            [Required]
            public int id_subject { get; set; }

            [NotMapped]
            public int id_faculty
            {
                get
                {
                    try
                    {
                        return GetFaculty().id_faculty;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }
            [NotMapped]
            public int id_department
            {
                get
                {
                    try
                    {
                        return GetStudentsGroup().id_department;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }

            public Faculty GetFaculty()
            {
                try
                {
                    return GetDepartment().GetFaculty();
                }
                catch
                {
                    return null;
                }
            }
            public Department GetDepartment()
            {
                try
                {
                    return GetStudentsGroup().GetDepartment();
                }
                catch
                {
                    return null;
                }
            }
            public Students_group GetStudentsGroup()
            {
                try
                {
                    return DB.Students_group.Find(this.id_students_group);
                }
                catch
                {
                    return null;
                }
            }
            public Subject GetSubject()
            {
                try
                {
                    return DB.Subject.Find(this.id_subject);
                }
                catch
                {
                    return null;
                }
            }

            public Students_group_load()
            {

            }
            public Students_group_load(int hours, int id_students_group, int id_subject)
            {
                this.hours = hours;
                this.id_students_group = id_students_group;
                this.id_subject = id_subject;
            }
        }

        //Модель загрузки
        public class Teacher_load
        {
            [Key]
            public int id_teacher_load { get; set; }

            [Required]
            public int id_teacher { get; set; }

            [Required]
            public int id_subject { get; set; }

            [NotMapped]
            public int id_faculty
            {
                get
                {
                    try
                    {
                        return GetFaculty().id_faculty;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }
            [NotMapped]
            public int id_department
            {
                get
                {
                    try
                    {
                        return GetTeacher().id_department;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }

            public Faculty GetFaculty()
            {
                try
                {
                    return GetDepartment().GetFaculty();
                }
                catch
                {
                    return null;
                }
            }
            public Department GetDepartment()
            {
                try
                {
                    return GetTeacher().GetDepartment();
                }
                catch
                {
                    return null;
                }
            }
            public Teacher GetTeacher()
            {
                try
                {
                    return DB.Teacher.Find(this.id_teacher);
                }
                catch
                {
                    return null;
                }
            }
            public Subject GetSubject()
            {
                try
                {
                    return DB.Subject.Find(this.id_subject);
                }
                catch
                {
                    return null;
                }
            }

            public Teacher_load()
            {

            }
            public Teacher_load(int id_subject, int id_teacher)
            {
                this.id_subject = id_subject;
                this.id_teacher = id_teacher;
            }
        }

        //Модель занятия
        public class Lesson
        {
            [Key]
            public int id_lesson { get; set; }

            [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "Required")]
            public int week_count { get; set; }

            [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "Required")]
            public int lesson_count { get; set; }

            [Required]
            public int id_classroom { get; set; }

            [Required]
            public int id_students_group_load { get; set; }

            [Required]
            public int id_teacher_load { get; set; }

            [NotMapped]
            public int id_faculty
            {
                get
                {
                    try
                    {
                        return GetFaculty().id_faculty;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }
            [NotMapped]
            public int id_department
            {
                get
                {
                    try
                    {
                        return GetStudentsGroup().id_department;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }

            [NotMapped]
            public int id_students_group
            {
                get
                {
                    try
                    {
                        return GetStudentsGroupLoad().id_students_group;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }
            [NotMapped]
            public int id_teacher
            {
                get
                {
                    try
                    {
                        return GetTeacherLoad().id_teacher;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }
            [NotMapped]
            public int id_subject
            {
                get
                {
                    try
                    {
                        return GetStudentsGroupLoad().id_subject;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }

            public Faculty GetFaculty()
            {
                try
                {
                    return GetDepartment().GetFaculty();
                }
                catch
                {
                    return null;
                }
            }
            public Department GetDepartment()
            {
                try
                {
                    return GetStudentsGroup().GetDepartment();
                }
                catch
                {
                    return null;
                }
            }
            public Students_group GetStudentsGroup()
            {
                try
                {
                    return GetStudentsGroupLoad().GetStudentsGroup();
                }
                catch
                {
                    return null;
                }
            }
            public Teacher GetTeacher()
            {
                try
                {
                    return GetTeacherLoad().GetTeacher();
                }
                catch
                {
                    return null;
                }
            }
            public Subject GetSubject()
            {
                try
                {
                    return GetStudentsGroupLoad().GetSubject();
                }
                catch
                {
                    return null;
                }
            }
            public Classroom GetClassroom()
            {
                try
                {
                    return DB.Classroom.Find(this.id_classroom);
                }
                catch
                {
                    return null;
                }
            }
            public Students_group_load GetStudentsGroupLoad()
            {
                try
                {
                    return DB.Students_group_load.Find(this.id_students_group_load);
                }
                catch
                {
                    return null;
                }
            }
            public Teacher_load GetTeacherLoad()
            {
                try
                {
                    return DB.Teacher_load.Find(this.id_teacher_load);
                }
                catch
                {
                    return null;
                }
            }

            public Lesson()
            {

            }
            public Lesson(int id_students_group_load)
            {
                this.id_students_group_load = id_students_group_load;
            }
            public Lesson(int week_count, int lesson_count, int id_classroom, int id_students_group_load, int id_teacher_load)
            {
                this.week_count = week_count;
                this.lesson_count = lesson_count;
                this.id_classroom = id_classroom;
                this.id_students_group_load = id_students_group_load;
                this.id_teacher_load = id_teacher_load;
            }
        }
    }
}