using LectureSchedulingTool.Models;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace LectureSchedulingTool.Controllers
{
    public partial class SchedulingController : Controller
    {
        [Authorize]
        public ActionResult Teacher(Teacher model, int page = 1, char action = '0', int row = -1, int id_teacher = -1)
        {
            switch (action)
            {
                case 'a':
                    ModelState.Clear();

                    ViewBag.action = action;
                    ViewBag.row = row;

                    model = new Teacher();
                    break;

                case 's':
                    if (ModelState.IsValid)
                    {
                        if (DB.Teacher.Count(t => t.surname == model.surname && t.name == model.name && t.patronymic == model.patronymic) > 0)
                        {
                            ViewBag.action = 'a';
                            ViewBag.row = row;

                            ModelState.AddModelError("-2", "Введеные данные не уникальны! Пожалуйста, проверьте правильность ввода и попробуйте еще раз.");
                        }
                        else
                        {
                            ViewBag.action = '0';
                            ViewBag.row = -1;

                            try
                            {
                                DB.Teacher.Add(model);
                                DB.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                ModelState.AddModelError("-3", "Невозможно добавить данные! Пожалуйста, проверьте правильность ввода и попробуйте еще раз.");
                                if (HttpContext.IsDebuggingEnabled)
                                    ModelState.AddModelError("-3", ex.GetBaseException().Message);
                            }
                        }
                    }
                    else
                    {
                        ViewBag.action = 'a';
                        ViewBag.row = row;
                    }
                    break;

                case 'e':
                    ModelState.Clear();

                    ViewBag.action = action;
                    ViewBag.row = row;

                    model = DB.Teacher.Find(id_teacher);
                    break;

                case 'u':
                    if (ModelState.IsValid)
                    {
                        if (DB.Teacher.Count(t => t.surname == model.surname && t.name == model.name && t.patronymic == model.patronymic && t.id_teacher != model.id_teacher) > 0)
                        {
                            ViewBag.action = 'e';
                            ViewBag.row = row;

                            ModelState.AddModelError("-2", "Введеные данные не уникальны! Пожалуйста, проверьте правильность ввода и попробуйте еще раз.");
                        }
                        else
                        {
                            ViewBag.action = '0';
                            ViewBag.row = -1;

                            try
                            {
                                DB.Teacher.Find(id_teacher).surname = model.surname;
                                DB.Teacher.Find(id_teacher).name = model.name;
                                DB.Teacher.Find(id_teacher).patronymic = model.patronymic;
                                DB.Teacher.Find(id_teacher).working_position = model.working_position;
                                DB.Teacher.Find(id_teacher).regalia = model.regalia;
                                DB.Teacher.Find(id_teacher).id_department = model.id_department;
                                DB.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                ModelState.AddModelError("-3", "Невозможно обновить данные! Пожалуйста, проверьте правильность ввода и попробуйте еще раз.");
                                if (HttpContext.IsDebuggingEnabled)
                                    ModelState.AddModelError("-3", ex.GetBaseException().Message);
                            }
                        }
                    }
                    else
                    {
                        ViewBag.action = 'e';
                        ViewBag.row = row;
                    }
                    break;

                case 'r':
                    ModelState.Clear();
                    model = DB.Teacher.Find(id_teacher);
                    if (DB.Teacher.Count(t => t.surname == model.surname && t.name == model.name && t.patronymic == model.patronymic) > 0)
                    {
                        try
                        {
                            DB.Teacher.Remove(DB.Teacher.Find(id_teacher));
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("-4", "Невозможно удалить данные! Возможно, есть зависимые данные. Пожалуйста, проверьте правильность ввода и попробуйте еще раз.");
                            if (HttpContext.IsDebuggingEnabled)
                                ModelState.AddModelError("-4", ex.GetBaseException().Message);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("-5", "Невозможно удалить данные! Пожалуйста, проверьте правильность ввода и попробуйте еще раз.");
                    }
                    break;

                default:
                    ModelState.Clear();

                    ViewBag.action = '0';
                    ViewBag.row = -1;
                    break;
            }

            try
            {
                IQueryable<Teacher> Iteachers;

                int elements_on_page = Int32.Parse(ConfigurationManager.AppSettings["ElementsOnPage"]);
                if (DB.Teacher.Count() <= elements_on_page)
                {
                    ViewBag.pages = 1;
                    Iteachers = DB.Teacher.Take(DB.Teacher.Count());
                }
                else
                {
                    int pages = (DB.Teacher.Count() / elements_on_page) + 1;

                    ViewBag.elements_on_page = elements_on_page;
                    ViewBag.page = page;
                    ViewBag.pages = pages;

                    if (page == 1)
                        Iteachers = DB.Teacher.Take(elements_on_page);
                    else
                    {
                        if (page == pages)
                            Iteachers = DB.Teacher.OrderBy(t => t.id_teacher).Skip(elements_on_page * (page - 1));
                        else
                            Iteachers = DB.Teacher.OrderBy(t => t.id_teacher).Skip(elements_on_page * (page - 1)).Take(elements_on_page);
                    }
                }

                ViewBag.teachers = Iteachers.ToList();
                if (action == 'a' || action == 'e')
                {
                    ViewBag.departments = DB.Department.ToList();
                    ViewBag.faculties = GetSafeFaculties().ToList();
                }
                else
                {
                    var departments = GetOnlyNeedsDepartments(Iteachers);
                    ViewBag.departments = departments.ToList();
                    ViewBag.faculties = GetOnlyNeedsFaculties(departments).ToList();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("-1", "Невозможно загрузить данные! Пожалуйста, попробуйте еще раз или обратитесь к администратору системы.");
                if (HttpContext.IsDebuggingEnabled)
                    ModelState.AddModelError("-1", ex.GetBaseException().Message);
            }

            return View(model);
        }
    }
}