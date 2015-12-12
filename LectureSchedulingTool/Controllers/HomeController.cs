using LectureSchedulingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LectureSchedulingTool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            SchedulingAlgorithm sa = new SchedulingAlgorithm();
            sa.Generate();

            return View();
        }
    }
}