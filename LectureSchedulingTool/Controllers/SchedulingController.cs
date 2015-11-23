using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using LectureSchedulingTool.Models;

namespace LectureSchedulingTool.Controllers
{
    [Authorize]
    public partial class SchedulingController : Controller
    {
        //База данных
        private SchedulingContext DB = new SchedulingContext();

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
                        try
                        {
                            Students_group students_group = new Students_group(name, people_amount, id_department);
                            DB.Students_group.Add(students_group);
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ViewBag.errors = ex.Message;
                        }
                    }
                    else
                        ViewBag.errors = "Некорретные данные. Проверьте правильность данных и повторите еще раз!";
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
                        try
                        {
                            DB.Students_group.Find(id_students_group).name = name;
                            DB.Students_group.Find(id_students_group).people_amount = people_amount;
                            DB.Students_group.Find(id_students_group).id_department = id_department;
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ViewBag.errors = ex.Message;
                        }
                    }
                    else
                        ViewBag.errors = "Некорретные данные. Проверьте правильность данных и повторите еще раз!";
                    break;
                //Удаление существующего элемента
                case 'r':
                    try
                    {
                        DB.Students_group.Remove(DB.Students_group.Find(id_students_group));
                        DB.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.errors = ex.Message;
                    }
                    break;
            }

            //Передача списков в представление
            try
            {
                ViewBag.faculties = DB.Faculty.ToList();
                ViewBag.departments = DB.Department.ToList();
                ViewBag.students_groups = DB.Students_group.ToList();
            }
            catch (Exception ex)
            {
                ViewBag.errors = ex.Message;
            }

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
                    int id_department = Convert.ToInt32(Request.Form["id_department"]);
                    if (surname.Length != 0 && name.Length != 0 && patronymic.Length != 0 && max_hours > 0 && working_position.Length != 0)
                    {
                        try
                        {
                            Teacher teacher = new Teacher(surname, name, patronymic, max_hours, working_position, regalia, id_department);
                            DB.Teacher.Add(teacher);
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ViewBag.errors = ex.Message;
                        }
                    }
                    else
                        ViewBag.errors = "Некорретные данные. Проверьте правильность данных и повторите еще раз!";
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
                        try
                        {
                            DB.Teacher.Find(id_teacher).surname = surname;
                            DB.Teacher.Find(id_teacher).name = name;
                            DB.Teacher.Find(id_teacher).patronymic = patronymic;
                            DB.Teacher.Find(id_teacher).max_hours = max_hours;
                            DB.Teacher.Find(id_teacher).working_position = working_position;
                            DB.Teacher.Find(id_teacher).regalia = regalia;
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ViewBag.errors = ex.Message;
                        }
                    }
                    else
                        ViewBag.errors = "Некорретные данные. Проверьте правильность данных и повторите еще раз!";
                    break;
                //Удаление существующего элемента
                case 'r':
                    try
                    {
                        DB.Teacher.Remove(DB.Teacher.Find(id_teacher));
                        DB.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.errors = ex.Message;
                    }
                    break;
            }

            //Передача списков в представление
            try
            {
                ViewBag.faculties = DB.Faculty.ToList();
                ViewBag.departments = DB.Department.ToList();
                ViewBag.teachers = DB.Teacher.ToList();
            }
            catch (Exception ex)
            {
                ViewBag.errors = ex.Message;
            }

            return View();
        }

        //Контроллер предмета
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
                        try
                        {
                            Subject subject = new Subject(name, type, id_department);
                            DB.Subject.Add(subject);
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ViewBag.errors = ex.Message;
                        }
                    }
                    else
                        ViewBag.errors = "Некорретные данные. Проверьте правильность данных и повторите еще раз!";
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
                        try
                        {
                            DB.Subject.Find(id_subject).name = name;
                            DB.Subject.Find(id_subject).type = type;
                            DB.Subject.Find(id_subject).id_department = id_department;
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ViewBag.errors = ex.Message;
                        }
                    }
                    else
                        ViewBag.errors = "Некорретные данные. Проверьте правильность данных и повторите еще раз!";
                    break;
                //Удаление существующего элемента
                case 'r':
                    try
                    {
                        DB.Subject.Remove(DB.Subject.Find(id_subject));
                        DB.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.errors = ex.Message;
                    }
                    break;
            }

            //Передача списков в представление
            try
            {
                ViewBag.faculties = DB.Faculty.ToList();
                ViewBag.departments = DB.Department.ToList();
                ViewBag.subjects = DB.Subject.ToList();
            }
            catch (Exception ex)
            {
                ViewBag.errors = ex.Message;
            }

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
                        try
                        {
                            Classroom classroom = new Classroom(number, people_capacity, id_department);
                            DB.Classroom.Add(classroom);
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ViewBag.errors = ex.Message;
                        }
                    }
                    else
                        ViewBag.errors = "Некорретные данные. Проверьте правильность данных и повторите еще раз!";
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
                        try
                        {
                            DB.Classroom.Find(id_classroom).number = number;
                            DB.Classroom.Find(id_classroom).people_capacity = people_capacity;
                            DB.Classroom.Find(id_classroom).id_department = id_department;
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ViewBag.errors = ex.Message;
                        }
                    }
                    else
                        ViewBag.errors = "Некорретные данные. Проверьте правильность данных и повторите еще раз!";
                    break;
                //Удаление существующего элемента
                case 'r':
                    try
                    {
                        DB.Classroom.Remove(DB.Classroom.Find(id_classroom));
                        DB.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.errors = ex.Message;
                    }
                    break;
            }

            //Передача списков в представление
            try
            {
                ViewBag.faculties = DB.Faculty.ToList();
                ViewBag.departments = DB.Department.ToList();
                ViewBag.classrooms = DB.Classroom.ToList();
            }
            catch (Exception ex)
            {
                ViewBag.errors = ex.Message;
            }

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
                        try
                        {
                            Students_group_load students_group_load = new Students_group_load(hours, id_students_group, id_subject);
                            DB.Students_group_load.Add(students_group_load);
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ViewBag.errors = ex.Message;
                        }
                    }
                    else
                        ViewBag.errors = "Некорретные данные. Проверьте правильность данных и повторите еще раз!";
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
                        try
                        {
                            DB.Students_group_load.Find(id_students_group_load).hours = hours;
                            DB.Students_group_load.Find(id_students_group_load).id_students_group = id_students_group;
                            DB.Students_group_load.Find(id_students_group_load).id_subject = id_subject;
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ViewBag.errors = ex.Message;
                        }
                    }
                    else
                        ViewBag.errors = "Некорретные данные. Проверьте правильность данных и повторите еще раз!";
                    break;
                //Удаление существующего элемента
                case 'r':
                    try
                    {
                        DB.Students_group_load.Remove(DB.Students_group_load.Find(id_students_group_load));
                        DB.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.errors = ex.Message;
                    }
                    break;
            }

            //Передача списков в представление
            try
            {
                ViewBag.faculties = DB.Faculty.ToList();
                ViewBag.departments = DB.Department.ToList();
                ViewBag.students_groups = DB.Students_group.ToList();
                ViewBag.subjects = DB.Subject.ToList();
                ViewBag.students_group_loads = DB.Students_group_load.ToList();
            }
            catch (Exception ex)
            {
                ViewBag.errors = ex.Message;
            }

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
                        try
                        {
                            Teacher_load teacher_load = new Teacher_load(id_subject, id_teacher);
                            DB.Teacher_load.Add(teacher_load);
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ViewBag.errors = ex.Message;
                        }
                    }
                    else
                        ViewBag.errors = "Некорретные данные. Проверьте правильность данных и повторите еще раз!";
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
                        try
                        {
                            DB.Teacher_load.Find(id_teacher_load).id_subject = id_subject;
                            DB.Teacher_load.Find(id_teacher_load).id_teacher = id_teacher;
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ViewBag.errors = ex.Message;
                        }
                    }
                    else
                        ViewBag.errors = "Некорретные данные. Проверьте правильность данных и повторите еще раз!";
                    break;
                //Удаление существующего элемента
                case 'r':
                    try
                    {
                        DB.Teacher_load.Remove(DB.Teacher_load.Find(id_teacher_load));
                        DB.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.errors = ex.Message;
                    }
                    break;
            }

            //Передача списков в представление
            try
            {
                ViewBag.faculties = DB.Faculty.ToList();
                ViewBag.departments = DB.Department.ToList();
                ViewBag.teachers = DB.Teacher.ToList();
                ViewBag.subjects = DB.Subject.ToList();
                ViewBag.teacher_loads = DB.Teacher_load.ToList();
            }
            catch (Exception ex)
            {
                ViewBag.errors = ex.Message;
            }

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
                        try
                        {
                            Lesson lesson = new Lesson(week_count, lesson_count, id_classroom, id_students_group_load, id_teacher_load);
                            DB.Lesson.Add(lesson);
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ViewBag.errors = ex.Message;
                        }
                    }
                    else
                        ViewBag.errors = "Некорретные данные. Проверьте правильность данных и повторите еще раз!";
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
                        try
                        {
                            DB.Lesson.Find(id_lesson).week_count = week_count;
                            DB.Lesson.Find(id_lesson).lesson_count = lesson_count;
                            DB.Lesson.Find(id_lesson).id_classroom = id_classroom;
                            DB.Lesson.Find(id_lesson).id_students_group_load = id_students_group_load;
                            DB.Lesson.Find(id_lesson).id_teacher_load = id_teacher_load;
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ViewBag.errors = ex.Message;
                        }
                    }
                    else
                        ViewBag.errors = "Некорретные данные. Проверьте правильность данных и повторите еще раз!";
                    break;
                //Удаление существующего элемента
                case 'r':
                    try
                    {
                        DB.Lesson.Remove(DB.Lesson.Find(id_lesson));
                        DB.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.errors = ex.Message;
                    }
                    break;
            }

            //Передача списков в представление
            try
            {
                ViewBag.faculties = DB.Faculty.ToList();
                ViewBag.departments = DB.Department.ToList();
                ViewBag.students_groups = DB.Students_group.ToList();
                ViewBag.teachers = DB.Teacher.ToList();
                ViewBag.subjects = DB.Subject.ToList();
                ViewBag.classrooms = DB.Classroom.ToList();
                ViewBag.students_group_loads = DB.Students_group_load.ToList();
                ViewBag.teacher_loads = DB.Teacher_load.ToList();
                ViewBag.lessons = DB.Lesson.ToList();
            }
            catch (Exception ex)
            {
                ViewBag.errors = ex.Message;
            }
            return View();
        }

        //Получение кафедр
        public ActionResult GetDepartments(int id_faculty)
        {
            List<Department> departments = DB.Department.Where(d => d.id_faculty == id_faculty).ToList();

            ViewBag.departments = departments;

            return PartialView();
        }

        public List<Faculty> GetSafeFaculies()
        {
            List<Faculty> faculties = DB.Faculty.ToList();
            List<Department> departments = DB.Department.ToList();

            List<Faculty> save_facultie = new List<Models.Faculty>();
            for (int i = 0; i < departments.Count; i++)
            {
                if (!save_facultie.Exists(f => f.id_faculty == departments[i].id_faculty))
                    save_facultie.Add(faculties.Find(f => f.id_faculty == departments[i].id_faculty));
            }

            return save_facultie;
        }
    }
}