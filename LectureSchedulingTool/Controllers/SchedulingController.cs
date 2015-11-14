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
                    Department department = new Department(name, abbreviation, is_producing, id_faculty);
                    DB.Department.Add(department);
                    DB.SaveChanges();
                    break;
                //Редактирование существующего элемента
                case 'e':
                    ViewBag.action = 'e';
                    ViewBag.row = row;
                    break;
                //Обновление существующего элемента
                case 'u':
                    DB.Department.Find(id_department).name = Request.Form["name"];
                    DB.Department.Find(id_department).abbreviation = Request.Form["abbreviation"];
                    DB.Department.Find(id_department).is_producing = Convert.ToInt32(Request.Form["is_producing"]);
                    DB.Department.Find(id_department).id_faculty = Convert.ToInt32(Request.Form["id_faculty"]);
                    DB.SaveChanges();
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
                    Classroom classroom = new Classroom(number, people_capacity, id_department);
                    DB.Classroom.Add(classroom);
                    DB.SaveChanges();
                    break;
                //Редактирование существующего элемента
                case 'e':
                    ViewBag.action = 'e';
                    ViewBag.row = row;
                    break;
                //Обновление существующего элемента
                case 'u':
                    DB.Classroom.Find(id_classroom).number = Request.Form["number"];
                    DB.Classroom.Find(id_classroom).people_capacity = Convert.ToInt32(Request.Form["peolple_capacity"]);
                    DB.Classroom.Find(id_classroom).id_department = Convert.ToInt32(Request.Form["id_department"]);
                    DB.SaveChanges();
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