﻿using System;
using System.Linq;
using System.Web.Mvc;
using LectureSchedulingTool.Models;

namespace LectureSchedulingTool.Controllers
{
    [Authorize]
    public partial class SchedulingController : Controller
    {
        private static SchedulingContext DB = new SchedulingContext();
        public string CurrentLangCode { get; protected set; }
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            //проверяем если ли в коллекции параметр lang и если есть, получаем его.
            if (requestContext.RouteData.Values["lang"] != null && requestContext.RouteData.Values["lang"] as string != "null")
            {
                CurrentLangCode = requestContext.RouteData.Values["lang"] as string;
            }
            //а если его нет, то используем язык по умолчанию
            else
                CurrentLangCode = "ru";

            //сохраняем значение языка во ViewBag, для того, чтобы легко получать к нему доступ из вьюшки
            ViewBag.CurLang = CurrentLangCode;

            string cultureName = (string)requestContext.RouteData.Values["lang"];
            Localizator.Initialize(cultureName);

            base.Initialize(requestContext);
        }

        public ActionResult GetDepartments(int id_faculty)
        {
            using (var DB = new SchedulingContext())
            {
                ViewBag.departments = DB.Department.Where(d => d.id_faculty == id_faculty).ToList();

                return PartialView();
            }
        }

        public ActionResult GetTeachers(int id_department)
        {
            using (var DB = new SchedulingContext())
            {
                ViewBag.teachers = DB.Teacher.Where(t => t.id_department == id_department).ToList();

                return PartialView();
            }
        }

        public ActionResult GetSubjects(int id_department)
        {
            using (var DB = new SchedulingContext())
            {
                ViewBag.subjects = DB.Subject.Where(s => s.id_department == id_department).ToList();

                return PartialView();
            }
        }

        public IQueryable<SVM.Faculty> GetOnlyNeedsFaculties(IQueryable<SVM.Department> departments)
        {
            return (from f in DB.Faculty join d in departments on f.id_faculty equals d.id_faculty select f);
        }
        public IQueryable<SVM.Department> GetOnlyNeedsDepartments(IQueryable<SVM.Students_group> students_groups)
        {
            return (from d in DB.Department join sg in students_groups on d.id_department equals sg.id_department select d);
        }
        public IQueryable<SVM.Department> GetOnlyNeedsDepartments(IQueryable<SVM.Teacher> teachers)
        {
            return (from d in DB.Department join t in teachers on d.id_department equals t.id_department select d);
        }
        public IQueryable<SVM.Department> GetOnlyNeedsDepartments(IQueryable<SVM.Subject> subjects)
        {
            return (from d in DB.Department join s in subjects on d.id_department equals s.id_department select d);
        }
        public IQueryable<SVM.Department> GetOnlyNeedsDepartments(IQueryable<SVM.Classroom> classrooms)
        {
            return (from d in DB.Department join c in classrooms on d.id_department equals c.id_department select d);
        }
        public IQueryable<SVM.Students_group> GetOnlyNeedsStudentsGroups(IQueryable<SVM.Students_group_load> students_group_load)
        {
            return (from sg in DB.Students_group join sgl in students_group_load on sg.id_students_group equals sgl.id_students_group select sg);
        }
        public IQueryable<SVM.Teacher> GetOnlyNeedsTeachers(IQueryable<SVM.Teacher_load> teacher_load)
        {
            return (from t in DB.Teacher join tl in teacher_load on t.id_teacher equals tl.id_teacher select t);
        }
        public IQueryable<SVM.Subject> GetOnlyNeedsSubjects(IQueryable<SVM.Students_group_load> students_group_load)
        {
            return (from s in DB.Subject join sgl in students_group_load on s.id_subject equals sgl.id_subject select s);
        }
        public IQueryable<SVM.Subject> GetOnlyNeedsSubjects(IQueryable<SVM.Teacher_load> teacher_load)
        {
            return (from s in DB.Subject join tl in teacher_load on s.id_subject equals tl.id_subject select s);
        }

        public IQueryable<SVM.Faculty> GetSafeFaculties()
        {
            return DB.Faculty;
        }
        public IQueryable<SVM.Department> GetSafeDepartmentsForSGLoads()
        {
            return DB.Department;
        }
        public IQueryable<SVM.Department> GetSafeDepartmentsForTLoads()
        {
            return DB.Department;
        }
    }
}