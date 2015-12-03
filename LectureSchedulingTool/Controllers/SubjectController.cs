using LectureSchedulingTool.Models;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace LectureSchedulingTool.Controllers
{
    public partial class SchedulingController : Controller
    {
        public ActionResult Subject(char action = '0', int row = -1, int id_subject = -1)
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
                    string name = Request.Form["name"];
                    string type = Request.Form["type"];
                    int id_department = Convert.ToInt32(Request.Form["id_department"]);
                    if (name.Length != 0 && type.Length != 0 && id_department > 0)
                    {
                        try
                        {
                            Subject subject = new Subject(name, type, id_department);
                            DB.Subject.Add(subject);
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
                    name = Request.Form["name"];
                    type = Request.Form["type"];
                    id_department = Convert.ToInt32(Request.Form["id_department"]);
                    if (name.Length != 0 && type.Length != 0 && id_department > 0)
                    {
                        try
                        {
                            DB.Subject.Find(id_subject).name = name;
                            DB.Subject.Find(id_subject).type = type;
                            DB.Subject.Find(id_subject).id_department = id_department;
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
                        DB.Subject.Remove(DB.Subject.Find(id_subject));
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
                ViewBag.subjects = DB.Subject.ToList();
            }
            catch (Exception ex)
            {
                ViewBag.errors = ex.Message;
            }

            return View();
        }
    }
}