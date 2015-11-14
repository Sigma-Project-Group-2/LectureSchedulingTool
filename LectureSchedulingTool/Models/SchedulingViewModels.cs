﻿using System.ComponentModel.DataAnnotations;

namespace LectureSchedulingTool.Models
{
    //Модель факультета
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

    //Модель кафедры
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

    //Модель студенческой группы
    public class Students_group
    {
        [Key]
        public int id_students_group { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int people_amount { get; set; }
        [Required]
        public int id_department { get; set; }

        public Students_group()
        {

        }
        public Students_group(string name, int people_amount, int id_department)
        {
            this.name = name;
            this.people_amount = people_amount;
            this.id_department = id_department;
        }
    }

    //Модель преподавателя
    public class Teacher
    {
        [Key]
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

        public Teacher()
        {

        }
        public Teacher(string surname, string name, string patronymic, int max_hours, string working_position, string regalia = null)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.max_hours = max_hours;
            this.working_position = working_position;
            this.regalia = regalia;
        }
    }

    //Модель предмета
    public class Subject
    {
        [Key]
        public int id_subject { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public int id_deparment { get; set; }
    }

    //Модель аудитории
    public class Classroom
    {
        [Key]
        public int id_classroom { get; set; }
        [Required]
        public string number { get; set; }
        [Required]
        public int people_capacity { get; set; }
        [Required]
        public int id_department { get; set; }
    }

    //Модель учебного плана группы
    public class Students_group_load
    {
        [Key]
        public int id_students_group_load { get; set; }
        [Required]
        public int hours { get; set; }
        [Required]
        public int id_students_group { get; set; }
        [Required]
        public int id_subject { get; set; }
    }

    //Модель профильности преподавателя
    public class Teacher_load
    {
        [Key]
        public int id_teacher_load { get; set; }
        [Required]
        public int id_subject { get; set; }
        [Required]
        public int id_teacher { get; set; }
    }

    //Модель занятия
    public class Lesson
    {
        [Key]
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
