using System;
using System.Linq;
using System.Web.Mvc;
using LectureSchedulingTool.Models;

namespace LectureSchedulingTool.Controllers
{
    [Authorize]
    public partial class SchedulingController : Controller
    {
        //База данных
        private SchedulingContext DB = new SchedulingContext();
                
        public ActionResult GetDepartments(int id_faculty)
        {
            ViewBag.departments = DB.Department.Where(d => d.id_faculty == id_faculty).ToList();

            return PartialView();
        }

        public IQueryable<Faculty> GetOnlyNeedsFaculties(IQueryable<Department> departments)
        {
            return (from f in DB.Faculty join d in departments on f.id_faculty equals d.id_faculty select f);
        }
        public IQueryable<Department> GetOnlyNeedsDepartments(IQueryable<Students_group> students_groups)
        {
            return (from d in DB.Department join sg in students_groups on d.id_department equals sg.id_department select d);
        }
        public IQueryable<Department> GetOnlyNeedsDepartments(IQueryable<Teacher> teachers)
        {
            return (from d in DB.Department join t in teachers on d.id_department equals t.id_department select d);
        }
        public IQueryable<Department> GetOnlyNeedsDepartments(IQueryable<Subject> subjects)
        {
            return (from d in DB.Department join s in subjects on d.id_department equals s.id_department select d);
        }
        public IQueryable<Department> GetOnlyNeedsDepartments(IQueryable<Classroom> classrooms)
        {
            return (from d in DB.Department join c in classrooms on d.id_department equals c.id_department select d);
        }
        public IQueryable<Students_group> GetOnlyNeedsStudentsGroups(IQueryable<Students_group_load> students_group_load)
        {
            return (from sg in DB.Students_group join sgl in students_group_load on sg.id_students_group equals sgl.id_students_group select sg);
        }
        public IQueryable<Teacher> GetOnlyNeedsTeachers(IQueryable<Teacher_load> teacher_load)
        {
            return (from t in DB.Teacher join tl in teacher_load on t.id_teacher equals tl.id_teacher select t);
        }
        public IQueryable<Subject> GetOnlyNeedsSubjects(IQueryable<Students_group_load> students_group_load)
        {
            return (from s in DB.Subject join sgl in students_group_load on s.id_subject equals sgl.id_subject select s);
        }
        public IQueryable<Subject> GetOnlyNeedsSubjects(IQueryable<Teacher_load> teacher_load)
        {
            return (from s in DB.Subject join tl in teacher_load on s.id_subject equals tl.id_subject select s);
        }

        public IQueryable<Faculty> GetSafeFaculties()
        {
            return (from f in DB.Faculty join d in DB.Department on f.id_faculty equals d.id_faculty select f);
        }
        public IQueryable<Department> GetSafeDepartmentsForSGLoads()
        {
            return (from d in DB.Department join sg in DB.Students_group on d.id_department equals sg.id_department select d);
        }
        public IQueryable<Department> GetSafeDepartmentsForTLoads()
        {
            return (from d in DB.Department join t in DB.Teacher on d.id_department equals t.id_department select d);
        }
    }
}