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
        public ActionResult Subject(SVM.Subject model, int page = 1, char action = '0', int row = -1, int id_subject = -1)
        {
            switch (action)
            {
                case 'a':
                    ModelState.Clear();

                    ViewBag.action = action;
                    ViewBag.row = row;

                    model = new SVM.Subject();
                    break;

                case 's':
                    if (ModelState.IsValid)
                    {
                        if (DB.Subject.Count(s => s.name == model.name && s.type == model.type) > 0)
                        {
                            ViewBag.action = 'a';
                            ViewBag.row = row;

                            ModelState.AddModelError("-2", Localizator.Localizate("Subject_duplicate_name_and_type_error", CurrentLangCode));
                        }
                        else
                        {
                            ViewBag.action = '0';
                            ViewBag.row = -1;

                            try
                            {
                                DB.Subject.Add(model);
                                DB.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                ModelState.AddModelError("-3", Localizator.Localizate("Subject_add_error", CurrentLangCode));
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

                    model = DB.Subject.Find(id_subject);
                    break;

                case 'u':
                    if (ModelState.IsValid)
                    {
                        if (DB.Subject.Count(s => s.name == model.name && s.type == model.type && s.id_subject != model.id_subject) > 0)
                        {
                            ViewBag.action = 'e';
                            ViewBag.row = row;

                            ModelState.AddModelError("-2", Localizator.Localizate("Subject_duplicate_name_and_type_error", CurrentLangCode));
                        }
                        else
                        {
                            ViewBag.action = '0';
                            ViewBag.row = -1;

                            try
                            {
                                DB.Subject.Find(id_subject).name = model.name;
                                DB.Subject.Find(id_subject).type = model.type;
                                DB.Subject.Find(id_subject).id_department = model.id_department;
                                DB.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                ModelState.AddModelError("-3", Localizator.Localizate("Subject_edit_error", CurrentLangCode));
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
                    model = DB.Subject.Find(id_subject);
                    if (DB.Subject.Count(s => s.name == model.name && s.type == model.type) > 0)
                    {
                        try
                        {
                            DB.Subject.Remove(DB.Subject.Find(id_subject));
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("-4", Localizator.Localizate("Subject_delete_error", CurrentLangCode));
                            if (HttpContext.IsDebuggingEnabled)
                                ModelState.AddModelError("-4", ex.GetBaseException().Message);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("-5", Localizator.Localizate("Subject_existance_error", CurrentLangCode));
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
                IQueryable<SVM.Subject> Isubjects;

                int elements_on_page = Int32.Parse(ConfigurationManager.AppSettings["ElementsOnPage"]);
                if (DB.Subject.Count() <= elements_on_page)
                {
                    ViewBag.pages = 1;
                    Isubjects = DB.Subject;
                }
                else
                {
                    int pages = (DB.Subject.Count() / elements_on_page) + 1;

                    ViewBag.elements_on_page = elements_on_page;
                    ViewBag.page = page;
                    ViewBag.pages = pages;

                    if (page == 1)
                        Isubjects = DB.Subject.Take(elements_on_page);
                    else
                    {
                        if (page == pages)
                            Isubjects = DB.Subject.OrderBy(s => s.id_subject).Skip(elements_on_page * (page - 1));
                        else
                            Isubjects = DB.Subject.OrderBy(s => s.id_subject).Skip(elements_on_page * (page - 1)).Take(elements_on_page);
                    }
                }

                ViewBag.subjects = Isubjects.ToList();
                ViewBag.departments = DB.Department.ToList();
                ViewBag.faculties = GetSafeFaculties().ToList();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("-1", Localizator.Localizate("Subject_view_error", CurrentLangCode));
                if (HttpContext.IsDebuggingEnabled)
                    ModelState.AddModelError("-1", ex.GetBaseException().Message);
            }

            return View(model);
        }
    }
}