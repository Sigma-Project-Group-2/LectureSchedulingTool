using LectureSchedulingTool.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace LectureSchedulingTool.Controllers
{
    public partial class SchedulingController : Controller
    {
        [Authorize]
        public ActionResult Department(Department model, int page = 1, char action = '0', int row = -1, int id_department = -1)
        {
            switch (action)
            {
                case 'a':
                    ModelState.Clear();

                    ViewBag.action = action;
                    ViewBag.row = row;

                    model = new Department();
                    break;

                case 's':
                    if (ModelState.IsValid)
                    {
                        if (DB.Faculty.ToList().Exists(f => f.name == model.name || f.abbreviation == model.abbreviation))
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
                                DB.Department.Add(model);
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
                        ViewBag.action = 'e';
                        ViewBag.row = row;
                    }
                    break;

                case 'e':
                    ModelState.Clear();

                    ViewBag.action = action;
                    ViewBag.row = row;

                    model = DB.Department.Find(id_department);
                    break;

                case 'u':
                    if (ModelState.IsValid)
                    {
                        if (DB.Department.ToList().Exists(d => (d.name == model.name || d.abbreviation == model.abbreviation) && d.id_department != model.id_department))
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
                                DB.Department.Find(id_department).name = model.name;
                                DB.Department.Find(id_department).abbreviation = model.abbreviation;
                                DB.Department.Find(id_department).id_faculty = model.id_faculty;
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
                    if (DB.Department.ToList().Exists(d => d.id_department == id_department))
                    {
                        try
                        {
                            DB.Department.Remove(DB.Department.Find(id_department));
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
                List<Department> departments = DB.Department.ToList();

                int elements_on_page = Int32.Parse(ConfigurationManager.AppSettings["ElementsOnPage"]);
                if (departments.Count <= elements_on_page)
                    ViewBag.pages = 1;
                else
                {
                    int pages = (departments.Count / elements_on_page) + 1;

                    ViewBag.elements_on_page = elements_on_page;
                    ViewBag.page = page;
                    ViewBag.pages = pages;

                    if (page == 1)
                        departments.RemoveRange(elements_on_page, departments.Count - elements_on_page);
                    else
                    {
                        if (page == pages)
                            departments.RemoveRange(0, elements_on_page * (page - 1));
                        else
                        {
                            departments.RemoveRange(0, elements_on_page * (page - 1));
                            departments.RemoveRange(elements_on_page, departments.Count - elements_on_page);
                        }
                    }
                }

                ViewBag.faculties = DB.Faculty.ToList();
                ViewBag.departments = departments;
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