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
        public ActionResult Students_group_load(SVM.Students_group_load model, int page = 1, char action = '0', int row = -1, int id_students_group_load = -1)
        {
            switch (action)
            {
                case 'a':
                    ModelState.Clear();

                    ViewBag.action = action;
                    ViewBag.row = row;

                    model = new SVM.Students_group_load();
                    break;

                case 's':
                    if (ModelState.IsValid)
                    {
                        if (DB.Students_group_load.Count(sgl => sgl.id_students_group == model.id_students_group && sgl.id_subject == model.id_subject) > 0)
                        {
                            ViewBag.action = 'a';
                            ViewBag.row = row;

                            ModelState.AddModelError("-2", Localizator.Localizate("Scheduling_Error1", CurrentLangCode));
                        }
                        else
                        {
                            ViewBag.action = '0';
                            ViewBag.row = -1;

                            try
                            {
                                DB.Students_group_load.Add(model);
                                DB.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                ModelState.AddModelError("-3", Localizator.Localizate("Scheduling_Error2", CurrentLangCode));
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

                    model = DB.Students_group_load.Find(id_students_group_load);
                    break;

                case 'u':
                    if (ModelState.IsValid)
                    {
                        if (DB.Students_group_load.Count(sgl => sgl.id_students_group == model.id_students_group && sgl.id_subject == model.id_subject && sgl.id_students_group_load != model.id_students_group_load) > 0)
                        {
                            ViewBag.action = 'e';
                            ViewBag.row = row;

                            ModelState.AddModelError("-2", Localizator.Localizate("Scheduling_Error3", CurrentLangCode));
                        }
                        else
                        {
                            ViewBag.action = '0';
                            ViewBag.row = -1;

                            try
                            {
                                DB.Students_group_load.Find(id_students_group_load).hours = model.hours;
                                DB.Students_group_load.Find(id_students_group_load).id_students_group = model.id_students_group;
                                DB.Students_group_load.Find(id_students_group_load).id_subject = model.id_subject;
                                DB.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                ModelState.AddModelError("-3", Localizator.Localizate("Scheduling_Error4", CurrentLangCode));
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
                    model = DB.Students_group_load.Find(id_students_group_load);
                    if (DB.Students_group_load.Count(sgl => sgl.id_students_group == model.id_students_group && sgl.id_subject == model.id_subject) > 0)
                    {
                        try
                        {
                            DB.Students_group_load.Remove(DB.Students_group_load.Find(id_students_group_load));
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("-4", Localizator.Localizate("Scheduling_Error5", CurrentLangCode));
                            if (HttpContext.IsDebuggingEnabled)
                                ModelState.AddModelError("-4", ex.GetBaseException().Message);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("-5", Localizator.Localizate("Scheduling_Error6", CurrentLangCode));
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
                IQueryable<SVM.Students_group_load> Istudents_group_loads;

                int elements_on_page = Int32.Parse(ConfigurationManager.AppSettings["ElementsOnPage"]);
                if (DB.Students_group_load.Count() <= elements_on_page)
                {
                    ViewBag.pages = 1;
                    Istudents_group_loads = DB.Students_group_load;
                }
                else
                {
                    int pages = (DB.Students_group_load.Count() / elements_on_page) + 1;

                    ViewBag.elements_on_page = elements_on_page;
                    ViewBag.page = page;
                    ViewBag.pages = pages;

                    if (page == 1)
                        Istudents_group_loads = DB.Students_group_load.Take(elements_on_page);
                    else
                    {
                        if (page == pages)
                            Istudents_group_loads = DB.Students_group_load.OrderBy(t => t.id_students_group_load).Skip(elements_on_page * (page - 1));
                        else
                            Istudents_group_loads = DB.Students_group_load.OrderBy(t => t.id_students_group_load).Skip(elements_on_page * (page - 1)).Take(elements_on_page);
                    }
                }

                ViewBag.students_group_loads = Istudents_group_loads.ToList();
                if (action == 'a' || action == 'e')
                {
                    ViewBag.students_groups = DB.Students_group.ToList();
                    ViewBag.subjects = DB.Subject.ToList();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("-1", Localizator.Localizate("Scheduling_Error7", CurrentLangCode));
                if (HttpContext.IsDebuggingEnabled)
                    ModelState.AddModelError("-1", ex.GetBaseException().Message);
            }

            return View(model);
        }
    }
}