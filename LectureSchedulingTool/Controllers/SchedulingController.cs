using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LectureSchedulingTool.Models;

namespace LectureSchedulingTool.Controllers
{
    public class SchedulingController : Controller
    {
        private SchedulingContext DB = new SchedulingContext();

        public ActionResult Faculty(char action = '0', int row = -1, int id_faculty = -1)
        {
            ViewBag.row = -1;
            ViewBag.action = '0';

            switch (action)
            {
                //add
                case 'a':
                    ViewBag.action = 'a';
                    break;
                //save
                case 's':
                    string name = Request.Form["name"];
                    string abbreviation = Request.Form["abbreviation"];
                    Faculty faculty = new Faculty(name, abbreviation);
                    DB.Faculty.Add(faculty);
                    DB.SaveChanges();
                    break;
                //edit
                case 'e':
                    ViewBag.action = 'e';
                    ViewBag.row = row;
                    break;
                //update
                case 'u':
                    DB.Faculty.Find(id_faculty).name = Request.Form["name"];
                    DB.Faculty.Find(id_faculty).abbreviation = Request.Form["abbreviation"];
                    DB.SaveChanges();
                    break;
                //remove                    
                case 'r':
                    DB.Faculty.Remove(DB.Faculty.Find(id_faculty));
                    DB.SaveChanges();
                    break;
            }

            ViewBag.faculties = DB.Faculty.ToList();

            return View();
        }

        public ActionResult Department(char action = '0', int row = -1, int id_department = -1)
        {
            ViewBag.row = -1;
            ViewBag.action = '0';

            switch (action)
            {
                //add
                case 'a':
                    ViewBag.action = 'a';
                    break;
                //save
                case 's':
                    string name = Request.Form["name"];
                    string abbreviation = Request.Form["abbreviation"];
                    int is_producing = Convert.ToInt32(Request.Form["is_producing"]);
                    int id_faculty = Convert.ToInt32(Request.Form["id_faculty"]);
                    Department department = new Department(name, abbreviation, is_producing, id_faculty);
                    DB.Department.Add(department);
                    DB.SaveChanges();
                    break;
                //edit
                case 'e':
                    ViewBag.action = 'e';
                    ViewBag.row = row;
                    break;
                //update
                case 'u':
                    DB.Department.Find(id_department).name = Request.Form["name"];
                    DB.Department.Find(id_department).abbreviation = Request.Form["abbreviation"];
                    DB.Department.Find(id_department).is_producing = Convert.ToInt32(Request.Form["is_producing"]);
                    DB.Department.Find(id_department).id_faculty = Convert.ToInt32(Request.Form["id_faculty"]);
                    DB.SaveChanges();
                    break;
                //remove                    
                case 'r':
                    DB.Department.Remove(DB.Department.Find(id_department));
                    DB.SaveChanges();
                    break;
            }

            ViewBag.faculties = DB.Faculty.ToList();
            ViewBag.departments = DB.Department.ToList();
            
            return View();
        }
    }
}