﻿using LectureSchedulingTool.Models;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace LectureSchedulingTool.Controllers
{
    public partial class SchedulingController : Controller
    {
        [Authorize]
        public ActionResult Students_group(Students_group model, int page = 1, char action = '0', int row = -1, int id_students_group = -1)
        {
            switch (action)
            {
                case 'a':
                    ModelState.Clear();

                    ViewBag.action = action;
                    ViewBag.row = row;

                    model = new Students_group();
                    break;

                case 's':
                    if (ModelState.IsValid)
                    {

                        if (DB.Students_group.Count(sg => sg.name == model.name) > 0)
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
                                DB.Students_group.Add(model);
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

                    model = DB.Students_group.Find(id_students_group);
                    break;

                case 'u':
                    if (ModelState.IsValid)
                    {
                        if (DB.Students_group.Count(sg => sg.name == model.name && sg.id_students_group != model.id_students_group) > 0)
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
                                DB.Students_group.Find(id_students_group).name = model.name;
                                DB.Students_group.Find(id_students_group).people_amount = model.people_amount;
                                DB.Students_group.Find(id_students_group).id_department = model.id_department;
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
                    model = DB.Students_group.Find(id_students_group);
                    if (DB.Students_group.Count(sg => sg.name == model.name) > 0)
                    {
                        try
                        {
                            DB.Students_group.Remove(DB.Students_group.Find(id_students_group));
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
                IQueryable<Students_group> Istudents_groups;

                int elements_on_page = Int32.Parse(ConfigurationManager.AppSettings["ElementsOnPage"]);
                if (DB.Students_group.Count() <= elements_on_page)
                {
                    ViewBag.pages = 1;
                    Istudents_groups = DB.Students_group.Take(DB.Students_group.Count());
                }
                else
                {
                    int pages = (DB.Students_group.Count() / elements_on_page) + 1;

                    ViewBag.elements_on_page = elements_on_page;
                    ViewBag.page = page;
                    ViewBag.pages = pages;

                    if (page == 1)
                        Istudents_groups = DB.Students_group.Take(elements_on_page);
                    else
                    {
                        if (page == pages)
                            Istudents_groups = DB.Students_group.OrderBy(sg => sg.id_students_group).Skip(elements_on_page * (page - 1));
                        else
                            Istudents_groups = DB.Students_group.OrderBy(sg => sg.id_students_group).Skip(elements_on_page * (page - 1)).Take(elements_on_page);
                    }
                }

                ViewBag.students_groups = Istudents_groups.ToList();
                if (action == 'a' || action == 'e')
                {
                    ViewBag.departments = DB.Department.ToList();
                    ViewBag.faculties = GetSafeFaculties().ToList();
                }
                else
                {
                    var departments = GetOnlyNeedsDepartments(Istudents_groups);
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