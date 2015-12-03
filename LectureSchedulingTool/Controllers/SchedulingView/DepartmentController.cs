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
                        if (DB.Department.Count(d => d.name == model.name || d.abbreviation == model.abbreviation) > 0)
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
                        if (DB.Department.Count(d => (d.name == model.name || d.abbreviation == model.abbreviation) && d.id_department != model.id_department) > 0)
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
                    model = DB.Department.Find(id_department);
                    if (DB.Department.Count(d => d.name == model.name || d.abbreviation == model.abbreviation) > 0)
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
                IQueryable<Department> Idepartments;

                int elements_on_page = Int32.Parse(ConfigurationManager.AppSettings["ElementsOnPage"]);
                if (DB.Department.Count() <= elements_on_page)
                {
                    ViewBag.pages = 1;
                    Idepartments = DB.Department.Take(DB.Department.Count());
                }
                else
                {
                    int pages = (DB.Department.Count() / elements_on_page) + 1;

                    ViewBag.elements_on_page = elements_on_page;
                    ViewBag.page = page;
                    ViewBag.pages = pages;

                    if (page == 1)
                        Idepartments = DB.Department.Take(elements_on_page);
                    else
                    {
                        if (page == pages)
                            Idepartments = DB.Department.OrderBy(d => d.id_department).Skip(elements_on_page * (page - 1));
                        else
                            Idepartments = DB.Department.OrderBy(d => d.id_department).Skip(elements_on_page * (page - 1)).Take(elements_on_page);
                    }
                }

                if (action == 'a' || action == 'e')
                    ViewBag.faculties = DB.Faculty.ToList();
                else
                    ViewBag.faculties = GetOnlyNeedsFaculties(Idepartments).ToList();

                ViewBag.departments = Idepartments.ToList();
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