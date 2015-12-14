using LectureSchedulingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LectureSchedulingTool.Controllers
{
    public class HomeController : Controller
    {
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