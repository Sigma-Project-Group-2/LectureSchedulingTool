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

            //Передача списков в представление
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
                    if (name.Length != 0 && abbreviation.Length != 0 && (is_producing == 0 || is_producing == 1) && id_faculty > 0)
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
                    if (name.Length != 0 && abbreviation.Length != 0 && (is_producing == 0 || is_producing == 1) && id_faculty > 0)
                    {
                        DB.Department.Find(id_department).name = name;
                        DB.Department.Find(id_department).abbreviation = abbreviation;
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

            //Передача списков в представление
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
                    if (name.Length != 0 && people_amount > 0 && id_department > 0)
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
                    if (name.Length != 0 && people_amount > 0 && id_department > 0)
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

            //Передача списков в представление
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
                    if (surname.Length != 0 && name.Length != 0 && patronymic.Length != 0 && max_hours > 0 && working_position.Length != 0)
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
                    if (surname.Length != 0 && name.Length != 0 && patronymic.Length != 0 && max_hours > 0 && working_position.Length != 0)
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

            //Передача списков в представление
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
                    if (name.Length != 0 && type.Length != 0 && id_department > 0)
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
                    if (name.Length != 0 && type.Length != 0 && id_department > 0)
                    {
                        DB.Subject.Find(id_subject).name = name;
                        DB.Subject.Find(id_subject).type = type;
                        DB.Subject.Find(id_subject).id_department = id_department;
                        DB.SaveChanges();
                    }
                    break;
                //Удаление существующего элемента
                case 'r':
                    DB.Subject.Remove(DB.Subject.Find(id_subject));
                    DB.SaveChanges();
                    break;
            }

            //Передача списков в представление
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
                    int people_capacity = Convert.ToInt32(Request.Form["people_capacity"]);
                    int id_department = Convert.ToInt32(Request.Form["id_department"]);
                    if (number.Length != 0 && people_capacity > 0 && id_department > 0)
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
                    people_capacity = Convert.ToInt32(Request.Form["people_capacity"]);
                    id_department = Convert.ToInt32(Request.Form["id_department"]);
                    if (number.Length != 0 && people_capacity > 0 && id_department > 0)
                    {
                        DB.Classroom.Find(id_classroom).number = number;
                        DB.Classroom.Find(id_classroom).people_capacity = people_capacity;
                        DB.Classroom.Find(id_classroom).id_department = id_department;
                        DB.SaveChanges();
                    }
                    break;
                //Удаление существующего элемента
                case 'r':
                    DB.Classroom.Remove(DB.Classroom.Find(id_classroom));
                    DB.SaveChanges();
                    break;
            }

            //Передача списков в представление
            ViewBag.faculties = DB.Faculty.ToList();
            ViewBag.departments = DB.Department.ToList();
            ViewBag.classrooms = DB.Classroom.ToList();

            return View();
        }

        //Контроллер загрузки групп
        public ActionResult Students_group_load(char action = '0', int row = -1, int id_students_group_load = -1)
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
                    int hours = Convert.ToInt32(Request.Form["hours"]);
                    int id_students_group = Convert.ToInt32(Request.Form["id_students_group"]);
                    int id_subject = Convert.ToInt32(Request.Form["id_subject"]);
                    if (hours > 0 && id_students_group > 0 && id_subject > 0)
                    {
                        Students_group_load students_group_load = new Students_group_load(hours, id_students_group, id_subject);
                        DB.Students_group_load.Add(students_group_load);
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
                    hours = Convert.ToInt32(Request.Form["hours"]);
                    id_students_group = Convert.ToInt32(Request.Form["id_students_group"]);
                    id_subject = Convert.ToInt32(Request.Form["id_subject"]);
                    if (hours > 0 && id_students_group > 0 && id_subject > 0)
                    {
                        DB.Students_group_load.Find(id_students_group_load).hours = hours;
                        DB.Students_group_load.Find(id_students_group_load).id_students_group = id_students_group;
                        DB.Students_group_load.Find(id_students_group_load).id_subject = id_subject;
                        DB.SaveChanges();
                    }
                    break;
                //Удаление существующего элемента
                case 'r':
                    DB.Students_group_load.Remove(DB.Students_group_load.Find(id_students_group_load));
                    DB.SaveChanges();
                    break;
            }

            //Передача списков в представление
            ViewBag.faculties = DB.Faculty.ToList();
            ViewBag.departments = DB.Department.ToList();
            ViewBag.students_groups = DB.Students_group.ToList();
            ViewBag.students_group_loads = DB.Students_group.ToList();

            return View();
        }

        //Контроллер загрузки преподавателей
        public ActionResult Teacher_load(char action = '0', int row = -1, int id_teacher_load = -1)
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
                    int id_subject = Convert.ToInt32(Request.Form["id_subject"]);
                    int id_teacher = Convert.ToInt32(Request.Form["id_teacher"]);
                    if (id_subject > 0 && id_teacher > 0)
                    {
                        Teacher_load teacher_load = new Teacher_load(id_subject, id_teacher);
                        DB.Teacher_load.Add(teacher_load);
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
                    id_subject = Convert.ToInt32(Request.Form["id_subject"]);
                    id_teacher = Convert.ToInt32(Request.Form["id_teacher"]);
                    if (id_subject > 0 && id_teacher > 0)
                    {
                        DB.Teacher_load.Find(id_teacher_load).id_subject = id_subject;
                        DB.Teacher_load.Find(id_teacher_load).id_teacher = id_teacher;
                        DB.SaveChanges();
                    }
                    break;
                //Удаление существующего элемента
                case 'r':
                    DB.Teacher_load.Remove(DB.Teacher_load.Find(id_teacher_load));
                    DB.SaveChanges();
                    break;
            }

            //Передача списков в представление
            ViewBag.faculties = DB.Faculty.ToList();
            ViewBag.departments = DB.Department.ToList();
            ViewBag.teachers = DB.Teacher.ToList();
            ViewBag.subjects = DB.Subject.ToList();
            ViewBag.teacher_loads = DB.Teacher_load.ToList();

            return View();
        }

        //Контроллер аудиторий
        public ActionResult Lesson(char action = '0', int row = -1, int id_lesson = -1)
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
                    int week_count = Convert.ToInt32(Request.Form["week_count"]);
                    int lesson_count = Convert.ToInt32(Request.Form["lesson_count"]);
                    int id_classroom = Convert.ToInt32(Request.Form["id_classroom"]);
                    int id_students_group_load = Convert.ToInt32(Request.Form["id_students_group_load"]);
                    int id_teacher_load = Convert.ToInt32(Request.Form["id_teacher_load"]);
                    if (week_count > 0 && lesson_count > 0 && id_classroom > 0 && id_students_group_load > 0 && id_teacher_load > 0)
                    {
                        Lesson lesson = new Lesson(week_count, lesson_count, id_classroom, id_students_group_load, id_teacher_load);
                        DB.Lesson.Add(lesson);
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
                    week_count = Convert.ToInt32(Request.Form["week_count"]);
                    lesson_count = Convert.ToInt32(Request.Form["lesson_count"]);
                    id_classroom = Convert.ToInt32(Request.Form["id_classroom"]);
                    id_students_group_load = Convert.ToInt32(Request.Form["id_students_group_load"]);
                    id_teacher_load = Convert.ToInt32(Request.Form["id_teacher_load"]);
                    if (week_count > 0 && lesson_count > 0 && id_classroom > 0 && id_students_group_load > 0 && id_teacher_load > 0)

                    {
                        DB.Lesson.Find(id_lesson).week_count = week_count;
                        DB.Lesson.Find(id_lesson).lesson_count = lesson_count;
                        DB.Lesson.Find(id_lesson).id_classroom = id_classroom;
                        DB.Lesson.Find(id_lesson).id_students_group_load = id_students_group_load;
                        DB.Lesson.Find(id_lesson).id_teacher_load = id_teacher_load;
                        DB.SaveChanges();
                    }
                    break;
                //Удаление существующего элемента
                case 'r':
                    DB.Lesson.Remove(DB.Lesson.Find(id_lesson));
                    DB.SaveChanges();
                    break;
            }

            //Передача списков в представление
            ViewBag.faculties = DB.Faculty.ToList();
            ViewBag.departments = DB.Department.ToList();
            ViewBag.students_groups = DB.Students_group.ToList();
            ViewBag.teachers = DB.Teacher.ToList();
            ViewBag.subjects = DB.Subject.ToList();
            ViewBag.classrooms = DB.Classroom.ToList();
            ViewBag.students_group_loads = DB.Students_group_load.ToList();
            ViewBag.teacher_loads = DB.Teacher_load.ToList();
            ViewBag.lessons = DB.Lesson.ToList();
            return View();
        }

        public ActionResult GetItems(int id)
        {
            return PartialView(DB.Department.Where(d => d.id_faculty == id).ToList());
        }
    }
}