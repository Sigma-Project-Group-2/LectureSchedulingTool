﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using LectureSchedulingTool.Models;
using System.Configuration;
using System.Collections.Generic;

namespace LectureSchedulingTool.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private SecretCodeContext DB = new SecretCodeContext();

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

        public ManageController()
        {
        }
        public ManageController(object o) { }
        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index(IndexViewModel model)
        {
            

            if (ModelState.IsValid)
            {
                ConfigurationManager.AppSettings["WeeksCount"] = model.WeeksCount.ToString();
                ConfigurationManager.AppSettings["WeeksAmount"] = model.WeeksAmount.ToString();
                ConfigurationManager.AppSettings["LessonsCount"] = model.LessonsCount.ToString();
                ConfigurationManager.AppSettings["LessonsAmount"] = model.LessonsAmount.ToString();
                ConfigurationManager.AppSettings["ElementsOnPage"] = model.ElementsOnPage.ToString();
            }

            return View(model);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult SecretCode(char action = '0', int id_secret_code = -1)
        {
            switch (action)
            {
                case 'a':
                    Secret_code secret_code = new Secret_code();
                    secret_code.GenerateCode();

                    try
                    {
                        while (DB.Secret_code.Count(sc => sc.secret_code == secret_code.secret_code) > 0)
                            secret_code.GenerateCode();

                        DB.Secret_code.Add(secret_code);
                        DB.SaveChanges();
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("-1", Localizator.Localizate("Error_creating_secret_code", CurrentLangCode)); //Ошибка при добавлении секретного кода
                    }
                    break;

                case 'r':
                    try
                    {
                        if (DB.Secret_code.Count(sc => sc.id_secret_code == id_secret_code) > 0)
                        {
                            DB.Secret_code.Remove(DB.Secret_code.Find(id_secret_code));
                            DB.SaveChanges();
                        }
                        else
                        {
                            ModelState.AddModelError("-2", Localizator.Localizate("Error_remove_secret_code", CurrentLangCode));
                        }                        
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("-2", Localizator.Localizate("Error_remove_secret_code", CurrentLangCode));
                    }
                    break;
            }

            ViewBag.secret_codes = DB.Secret_code.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        #endregion
    }
}