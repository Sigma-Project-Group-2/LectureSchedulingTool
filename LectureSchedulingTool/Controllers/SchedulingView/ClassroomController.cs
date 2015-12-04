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
        public ActionResult Classroom(Classroom model, int page = 1, char action = '0', int row = -1, int id_classroom = -1)
        {
            switch (action)
            {
                case 'a':
                    ModelState.Clear();

                    ViewBag.action = action;
                    ViewBag.row = row;

                    model = new Classroom();
                    break;

                case 's':
                    if (ModelState.IsValid)
                    {
                        if (DB.Classroom.Count(c => c.number == model.number) > 0)
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
                                DB.Classroom.Add(model);
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

                    model = DB.Classroom.Find(id_classroom);
                    break;

                case 'u':
                    if (ModelState.IsValid)
                    {
                        if (DB.Classroom.Count(c => c.number == model.number && c.id_classroom != model.id_classroom) > 0)
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
                                DB.Classroom.Find(id_classroom).number = model.number;
                                DB.Classroom.Find(id_classroom).people_capacity = model.people_capacity;
                                DB.Classroom.Find(id_classroom).id_department = model.id_department;
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
                    model = DB.Classroom.Find(id_classroom);
                    if (DB.Classroom.Count(c => c.number == model.number) > 0)
                    {
                        try
                        {
                            DB.Classroom.Remove(DB.Classroom.Find(id_classroom));
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
                IQueryable<Classroom> Iclassrooms;

                int elements_on_page = Int32.Parse(ConfigurationManager.AppSettings["ElementsOnPage"]);
                if (DB.Classroom.Count() <= elements_on_page)
                {
                    ViewBag.pages = 1;
                    Iclassrooms = DB.Classroom.Take(DB.Classroom.Count());
                }
                else
                {
                    int pages = (DB.Classroom.Count() / elements_on_page) + 1;

                    ViewBag.elements_on_page = elements_on_page;
                    ViewBag.page = page;
                    ViewBag.pages = pages;

                    if (page == 1)
                        Iclassrooms = DB.Classroom.Take(elements_on_page);
                    else
                    {
                        if (page == pages)
                            Iclassrooms = DB.Classroom.OrderBy(c => c.id_classroom).Skip(elements_on_page * (page - 1));
                        else
                            Iclassrooms = DB.Classroom.OrderBy(c => c.id_classroom).Skip(elements_on_page * (page - 1)).Take(elements_on_page);
                    }
                }

                ViewBag.classrooms = Iclassrooms.ToList();
                if (action == 'a' || action == 'e')
                {
                    ViewBag.departments = DB.Department.ToList();
                    ViewBag.faculties = GetSafeFaculties().ToList();
                }
                else
                {
                    var departments = GetOnlyNeedsDepartments(Iclassrooms);
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