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
        public ActionResult Faculty(Faculty model, int page = 1, char action = '0', int row = -1, int id_faculty = -1)
        {
            switch (action)
            {
                case 'a':
                    ModelState.Clear();

                    ViewBag.action = action;
                    ViewBag.row = row;

                    model = new Faculty();
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
                                DB.Faculty.Add(model);
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

                    model = DB.Faculty.Find(id_faculty);
                    break;

                case 'u':
                    if (ModelState.IsValid)
                    {
                        if (DB.Faculty.ToList().Exists(f => (f.name == model.name || f.abbreviation == model.abbreviation) && f.id_faculty != model.id_faculty))
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
                                DB.Faculty.Find(id_faculty).name = model.name;
                                DB.Faculty.Find(id_faculty).abbreviation = model.abbreviation;
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
                    if (DB.Faculty.ToList().Exists(f => f.id_faculty == id_faculty))
                    {
                        try
                        {
                            DB.Faculty.Remove(DB.Faculty.Find(id_faculty));
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
                List<Faculty> faculies = DB.Faculty.ToList();

                int elements_on_page = Int32.Parse(ConfigurationManager.AppSettings["ElementsOnPage"]);
                if (faculies.Count <= elements_on_page)
                    ViewBag.pages = 1;
                else
                {
                    int pages = (faculies.Count / elements_on_page) + 1;

                    ViewBag.elements_on_page = elements_on_page;
                    ViewBag.page = page;
                    ViewBag.pages = pages;

                    if (page == 1)
                        faculies.RemoveRange(elements_on_page, faculies.Count - elements_on_page);
                    else
                    {
                        if (page == pages)
                            faculies.RemoveRange(0, elements_on_page * (page - 1));
                        else
                        {
                            faculies.RemoveRange(0, elements_on_page * (page - 1));
                            faculies.RemoveRange(elements_on_page, faculies.Count - elements_on_page);
                        }
                    }
                }

                ViewBag.faculties = faculies;
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