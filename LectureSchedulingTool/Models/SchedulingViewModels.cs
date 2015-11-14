using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LectureSchedulingTool.Models
{
    public class Faculty
    {
        [Key]
        public int id_faculty { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string abbreviation { get; set; }

        public Faculty()
        {

        }
        public Faculty(string name, string abbreviation)
        {
            this.name = name;
            this.abbreviation = abbreviation;
        }
    }

    public class Department
    {
        [Key]
        public int id_department { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string abbreviation { get; set; }
        [Required]
        public int is_producing { get; set; }
        [Required]
        public int id_faculty { get; set; }

        public Department()
        {

        }
        public Department(string name, string abbreviation, int is_producing, int id_faculty)
        {
            this.name = name;
            this.abbreviation = abbreviation;
            this.is_producing = is_producing;
            this.id_faculty = id_faculty;
        }
    }

    public class Students_group
    {
        [Key]
        [Required]
        public int id_students_group { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int people_amount { get; set; }
        [Required]
        public int id_department { get; set; }
    }

    public class Teacher
    {
        [Key]
        [Required]
        public int id_teacher { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string patronymic { get; set; }
        [Required]
        public int max_hours { get; set; }
        [Required]
        public string working_position { get; set; }
        public string regalia { get; set; }
        [Required]
        public int id_department { get; set; }
    }

    public class Subject
    {
        [Key]
        [Required]
        public int id_subject { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public int id_deparment { get; set; }
    }

    public class Classroom
    {
        [Key]
        [Required]
        public int id_classroom { get; set; }
        [Required]
        public string number { get; set; }
        [Required]
        public int people_capacity { get; set; }
        [Required]
        public int id_department { get; set; }
    }

    public class Students_group_load
    {
        [Key]
        [Required]
        public int id_students_group_load { get; set; }
        [Required]
        public int hours { get; set; }
        [Required]
        public int id_students_group { get; set; }
        [Required]
        public int id_subject { get; set; }
    }

    public class Teacher_load
    {
        [Key]
        [Required]
        public int id_teacher_load { get; set; }
        [Required]
        public int id_subject { get; set; }
        [Required]
        public int id_teacher { get; set; }
    }

    public class Lesson
    {
        [Key]
        [Required]
        public int id_lesson { get; set; }
        [Required]
        public int week { get; set; }
        [Required]
        public int lesson { get; set; }
        [Required]
        public int id_classroom { get; set; }
        [Required]
        public int id_students_group_load { get; set; }
        [Required]
        public int id_teacher_load { get; set; }
    }
}
