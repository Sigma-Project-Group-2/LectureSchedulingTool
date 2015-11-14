using System;
using System.Linq;
using System.Web.Mvc;
using LectureSchedulingTool.Models;

namespace LectureSchedulingTool.Controllers
{
    public class SchedulingController : Controller
    {
        //База данных
        private SchedulingContext DB = new SchedulingContext();

        //Контроллер факультета
        public ActionResult Faculty(char action = '0', int row = -1, int id_faculty = -1)
        {
            ViewBag.row = -1;
            ViewBag.action = '0';

            switch (action)
            {
                //Добавление нового элемента
                case 'a':
                    ViewBag.action = 'a';
                    break;
                //Сохранение нового элемента
                case 's':
                    string name = Request.Form["name"];
                    string abbreviation = Request.Form["abbreviation"];
                    if (name.Length != 0 && abbreviation.Length != 0)
                    {
                        Faculty faculty = new Faculty(name, abbreviation);
                        DB.Faculty.Add(faculty);
                        DB.SaveChanges();
                    }
                    break;
                //Редактирование существующего элемента
                case 'e':
                    ViewBag.action = 'e';
                    ViewBag.row = row;
                    break;
                //Обновление существующего элемента
                case 'u':
                    name = Request.Form["name"];
                    abbreviation = Request.Form["abbreviation"];
                    if (name.Length != 0 && abbreviation.Length != 0)
                    {
                        DB.Faculty.Find(id_faculty).name = name;
                        DB.Faculty.Find(id_faculty).abbreviation = abbreviation;
                        DB.SaveChanges();
                    }
                    break;
                //Удаление существующего элемента
                case 'r':
                    DB.Faculty.Remove(DB.Faculty.Find(id_faculty));
                    DB.SaveChanges();
                    break;
            }

            //Передача списка факульетов в представление
            ViewBag.faculties = DB.Faculty.ToList();

            return View();
        }

        //Контроллер кафедры
        public ActionResult Department(char action = '0', int row = -1, int id_department = -1)
        {
            ViewBag.row = -1;
            ViewBag.action = '0';

            switch (action)
            {
                //Добавление нового элемента
                case 'a':
                    ViewBag.action = 'a';
                    break;
                //Сохранение нового элемента
                case 's':
                    string name = Request.Form["name"];
                    string abbreviation = Request.Form["abbreviation"];
                    int is_producing = Convert.ToInt32(Request.Form["is_producing"]);
                    int id_faculty = Convert.ToInt32(Request.Form["id_faculty"]);
                    if (name.Length != 0 && abbreviation.Length != 0)
                    {
                        Department department = new Department(name, abbreviation, is_producing, id_faculty);
                        DB.Department.Add(department);
                        DB.SaveChanges();
                    }
                    break;
                //Редактирование существующего элемента
                case 'e':
                    ViewBag.action = 'e';
                    ViewBag.row = row;
                    break;
                //Обновление существующего элемента
                case 'u':
                    name = Request.Form["name"];
                    abbreviation = Request.Form["abbreviation"];
                    is_producing = Convert.ToInt32(Request.Form["is_producing"]);
                    id_faculty = Convert.ToInt32(Request.Form["id_faculty"]);
                    if (name.Length != 0 && abbreviation.Length != 0)
                    {
                        DB.Department.Find(id_department).name = name;
                        DB.Department.Find(id_department).abbreviation=  abbreviation;
                        DB.Department.Find(id_department).is_producing = is_producing;
                        DB.Department.Find(id_department).id_faculty = id_faculty;
                        DB.SaveChanges();
                    }
                    break;
                //Удаление существующего элемента
                case 'r':
                    DB.Department.Remove(DB.Department.Find(id_department));
                    DB.SaveChanges();
                    break;
            }

            //Передача списков факультетов и кафедр в представление
            ViewBag.faculties = DB.Faculty.ToList();
            ViewBag.departments = DB.Department.ToList();

            return View();
        }

        //Контроллер группы
        public ActionResult Students_group(char action = '0', int row = -1, int id_students_group = -1)
        {
            ViewBag.row = -1;
            ViewBag.action = '0';

            switch (action)
            {
                //Добавление нового элемента
                case 'a':
                    ViewBag.action = 'a';
                    break;
                //Сохранение нового элемента
                case 's':
                    string name = Request.Form["name"];
                    int people_amount = Convert.ToInt32(Request.Form["people_amount"]);
                    int id_department = Convert.ToInt32(Request.Form["id_department"]);
                    if (name.Length != 0)
                    {
                        Students_group group = new Students_group(name, people_amount, id_department);
                        DB.Students_group.Add(group);
                        DB.SaveChanges();
                    }
                    break;
                //Редактирование существующего элемента
                case 'e':
                    ViewBag.action = 'e';
                    ViewBag.row = row;
                    break;
                //Обновление существующего элемента
                case 'u':
                    name = Request.Form["name"];
                    people_amount = Convert.ToInt32(Request.Form["people_amount"]);
                    id_department = Convert.ToInt32(Request.Form["id_department"]);
                    if (name.Length != 0)
                    {
                        DB.Students_group.Find(id_students_group).name = name;
                        DB.Students_group.Find(id_students_group).people_amount = people_amount;
                        DB.Students_group.Find(id_students_group).id_department = id_department;
                        DB.SaveChanges();
                    }
                    break;
                //Удаление существующего элемента
                case 'r':
                    DB.Students_group.Remove(DB.Students_group.Find(id_students_group));
                    DB.SaveChanges();
                    break;
            }

            //Передача списков факультетов и кафедр в представление
            ViewBag.faculties = DB.Faculty.ToList();
            ViewBag.departments = DB.Department.ToList();
            ViewBag.students_groups = DB.Students_group.ToList();

            return View();
        }

        //Контроллер преподавателя
        public ActionResult Teacher(char action = '0', int row = -1, int id_teacher = -1)
        {
            ViewBag.row = -1;
            ViewBag.action = '0';

            switch (action)
            {
                //Добавление нового элемента
                case 'a':
                    ViewBag.action = 'a';
                    break;
                //Сохранение нового элемента
                case 's':
                    string surname = Request.Form["surname"];
                    string name = Request.Form["name"];
                    string patronymic = Request.Form["patronymic"];
                    int max_hours = Convert.ToInt32(Request.Form["max_hours"]);
                    string working_position = Request.Form["working_position"];
                    string regalia = Request.Form["regalia"];
                    if (surname.Length != 0 && name.Length != 0 && patronymic.Length != 0 && working_position.Length != 0)
                    {
                        Teacher teacher = new Teacher(surname, name, patronymic, max_hours, working_position, regalia);
                        DB.Teacher.Add(teacher);
                        DB.SaveChanges();
                    }
                    break;
                //Редактирование существующего элемента
                case 'e':
                    ViewBag.action = 'e';
                    ViewBag.row = row;
                    break;
                //Обновление существующего элемента
                case 'u':
                    surname = Request.Form["surname"];
                    name = Request.Form["name"];
                    patronymic = Request.Form["patronymic"];
                    max_hours = Convert.ToInt32(Request.Form["max_hours"]);
                    working_position = Request.Form["working_position"];
                    regalia = Request.Form["regalia"];
                    if (surname.Length != 0 && name.Length != 0 && patronymic.Length != 0 && working_position.Length != 0)
                    {
                        DB.Teacher.Find(id_teacher).surname = surname;
                        DB.Teacher.Find(id_teacher).name = name;
                        DB.Teacher.Find(id_teacher).patronymic = patronymic;
                        DB.Teacher.Find(id_teacher).max_hours = max_hours;
                        DB.Teacher.Find(id_teacher).working_position = working_position;
                        DB.Teacher.Find(id_teacher).regalia = regalia;
                        DB.SaveChanges();
                    }
                    break;
                //Удаление существующего элемента
                case 'r':
                    DB.Teacher.Remove(DB.Teacher.Find(id_teacher));
                    DB.SaveChanges();
                    break;
            }

            //Передача списков факультетов и кафедр в представление
            ViewBag.faculties = DB.Faculty.ToList();
            ViewBag.departments = DB.Department.ToList();
            ViewBag.teachers = DB.Teacher.ToList();

            return View();
        }

        //Контроллер преподавателя
        public ActionResult Subject(char action = '0', int row = -1, int id_subject = -1)
        {
            ViewBag.row = -1;
            ViewBag.action = '0';

            switch (action)
            {
                //Добавление нового элемента
                case 'a':
                    ViewBag.action = 'a';
                    break;
                //Сохранение нового элемента
                case 's':
                    string name = Request.Form["name"];
                    string type = Request.Form["type"];
                    int id_department = Convert.ToInt32(Request.Form["id_department"]);
                    if (name.Length != 0 && name.Length != 0 && type.Length != 0 )
                    {
                        Subject subject = new Subject(name, type, id_department);
                        DB.Subject.Add(subject);
                        DB.SaveChanges();
                    }
                    break;
                //Редактирование существующего элемента
                case 'e':
                    ViewBag.action = 'e';
                    ViewBag.row = row;
                    break;
                //Обновление существующего элемента
                case 'u':
                    name = Request.Form["name"];
                    type = Request.Form["type"];
                    id_department = Convert.ToInt32(Request.Form["id_department"]);
                    if (name.Length != 0 && name.Length != 0 && type.Length != 0)
                    {
                        DB.Teacher.Find(id_subject).name = name;
                        DB.Teacher.Find(id_subject).type = type;
                        DB.Teacher.Find(id_subject).id_department = id_department;
                        DB.SaveChanges();
                    }
                    break;
                //Удаление существующего элемента
                case 'r':
                    DB.Subject.Remove(DB.Subject.Find(id_subject));
                    DB.SaveChanges();
                    break;
            }

            //Передача списков факультетов и кафедр в представление
            ViewBag.faculties = DB.Faculty.ToList();
            ViewBag.departments = DB.Department.ToList();
            ViewBag.subjects = DB.Subject.ToList();

            return View();
        }

        //Контроллер аудиторий
        public ActionResult Classroom(char action = '0', int row = -1, int id_classroom = -1)
        {
            ViewBag.row = -1;
            ViewBag.action = '0';

            switch (action)
            {
                //Добавление нового элемента
                case 'a':
                    ViewBag.action = 'a';
                    break;
                //Сохранение нового элемента
                case 's':
                    string number = Request.Form["number"];
                    int people_capacity = Convert.ToInt32(Request.Form["peolple_capacity"]);
                    int id_department = Convert.ToInt32(Request.Form["id_department"]);
                    if (number.Length != 0)
                    {
                        Classroom classroom = new Classroom(number, people_capacity, id_department);
                        DB.Classroom.Add(classroom);
                        DB.SaveChanges();
                    }
                    break;
                //Редактирование существующего элемента
                case 'e':
                    ViewBag.action = 'e';
                    ViewBag.row = row;
                    break;
                //Обновление существующего элемента
                case 'u':
                    number = Request.Form["number"];
                    people_capacity = Convert.ToInt32(Request.Form["peolple_capacity"]);
                    id_department = Convert.ToInt32(Request.Form["id_department"]);
                    if (number.Length != 0)
                    {
                        DB.Classroom.Find(id_classroom).number = Request.Form["number"];
                        DB.Classroom.Find(id_classroom).people_capacity = Convert.ToInt32(Request.Form["peolple_capacity"]);
                        DB.Classroom.Find(id_classroom).id_department = Convert.ToInt32(Request.Form["id_department"]);
                        DB.SaveChanges();
                    }
                    break;
                //Удаление существующего элемента
                case 'r':
                    DB.Classroom.Remove(DB.Classroom.Find(id_classroom));
                    DB.SaveChanges();
                    break;
            }

            //Передача списков аудиторий и кафедр в представление
            ViewBag.faculties = DB.Faculty.ToList();
            ViewBag.departments = DB.Department.ToList();
            ViewBag.classrooms = DB.Classroom.ToList();

            return View();
        }
    }
}