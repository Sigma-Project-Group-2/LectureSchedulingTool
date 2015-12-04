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
        public ActionResult Teacher_load(SVM.Teacher_load model, int page = 1, char action = '0', int row = -1, int id_teacher_load = -1)
        {
            switch (action)
            {
                case 'a':
                    ModelState.Clear();

                    ViewBag.action = action;
                    ViewBag.row = row;

                    model = new SVM.Teacher_load();
                    break;

                case 's':
                    if (ModelState.IsValid)
                    {
                        if (DB.Teacher_load.Count(tl => tl.id_teacher == model.id_teacher && tl.id_subject == model.id_subject) > 0)
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
                                DB.Teacher_load.Add(model);
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

                    model = DB.Teacher_load.Find(id_teacher_load);
                    break;

                case 'u':
                    if (ModelState.IsValid)
                    {
                        if (DB.Teacher_load.Count(tl => tl.id_teacher == model.id_teacher && tl.id_subject == model.id_subject && tl.id_teacher_load != model.id_teacher_load) > 0)
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
                                DB.Teacher_load.Find(id_teacher_load).id_teacher = model.id_teacher;
                                DB.Teacher_load.Find(id_teacher_load).id_subject = model.id_subject;
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
                    model = DB.Teacher_load.Find(id_teacher_load);
                    if (DB.Teacher_load.Count(tl => tl.id_teacher == model.id_teacher && tl.id_subject == model.id_subject) > 0)
                    {
                        try
                        {
                            DB.Teacher_load.Remove(DB.Teacher_load.Find(id_teacher_load));
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
                IQueryable<SVM.Teacher_load> Iteacher_loads;

                int elements_on_page = Int32.Parse(ConfigurationManager.AppSettings["ElementsOnPage"]);
                if (DB.Teacher_load.Count() <= elements_on_page)
                {
                    ViewBag.pages = 1;
                    Iteacher_loads = DB.Teacher_load;
                }
                else
                {
                    int pages = (DB.Teacher_load.Count() / elements_on_page) + 1;

                    ViewBag.elements_on_page = elements_on_page;
                    ViewBag.page = page;
                    ViewBag.pages = pages;

                    if (page == 1)
                        Iteacher_loads = DB.Teacher_load.Take(elements_on_page);
                    else
                    {
                        if (page == pages)
                            Iteacher_loads = DB.Teacher_load.OrderBy(t => t.id_teacher_load).Skip(elements_on_page * (page - 1));
                        else
                            Iteacher_loads = DB.Teacher_load.OrderBy(t => t.id_teacher_load).Skip(elements_on_page * (page - 1)).Take(elements_on_page);
                    }
                }

                ViewBag.teacher_loads = Iteacher_loads.ToList();
                if (action == 'a' || action == 'e')
                {
                    ViewBag.teachers = DB.Teacher.ToList();
                    ViewBag.subjects = DB.Subject.ToList();
                    ViewBag.departments = GetSafeDepartmentsForTLoads().ToList();
                    ViewBag.faculties = GetSafeFaculties().ToList();
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