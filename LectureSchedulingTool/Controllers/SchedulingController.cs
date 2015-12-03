using System;
using System.Linq;
using System.Web.Mvc;
using LectureSchedulingTool.Models;

namespace LectureSchedulingTool.Controllers
{
    [Authorize]
    public partial class SchedulingController : Controller
    {
        //База данных
        private SchedulingContext DB = new SchedulingContext();
        
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
        
        public ActionResult GetDepartments(int id_faculty)
        {
            ViewBag.departments = DB.Department.Where(d => d.id_faculty == id_faculty).ToList();

            return PartialView();
        }

        public IQueryable<Faculty> GetOnlyNeedsFaculties(IQueryable<Department> departments)
        {
            return (from f in DB.Faculty join d in departments on f.id_faculty equals d.id_faculty select f);
        }
        public IQueryable<Department> GetOnlyNeedsDepartments(IQueryable<Students_group> students_groups)
        {
            return (from d in DB.Department join sg in students_groups on d.id_department equals sg.id_department select d);
        }
        public IQueryable<Department> GetOnlyNeedsDepartments(IQueryable<Teacher> teachers)
        {
            return (from d in DB.Department join t in teachers on d.id_department equals t.id_department select d);
        }
        public IQueryable<Department> GetOnlyNeedsDepartments(IQueryable<Subject> subjects)
        {
            return (from d in DB.Department join s in subjects on d.id_department equals s.id_department select d);
        }
        public IQueryable<Department> GetOnlyNeedsDepartments(IQueryable<Classroom> classrooms)
        {
            return (from d in DB.Department join c in classrooms on d.id_department equals c.id_department select d);
        }

        public IQueryable<Faculty> GetSafeFaculties()
        {
            return (from f in DB.Faculty join d in DB.Department on f.id_faculty equals d.id_faculty select f);
        }
        public IQueryable<Department> GetSafeDepartmentsForSGLoads()
        {
            return (from d in DB.Department join sg in DB.Students_group on d.id_department equals sg.id_department select d);
        }
        public IQueryable<Department> GetSafeDepartmentsForTLoads()
        {
            return (from d in DB.Department join t in DB.Teacher on d.id_department equals t.id_department select d);
        }
    }
}