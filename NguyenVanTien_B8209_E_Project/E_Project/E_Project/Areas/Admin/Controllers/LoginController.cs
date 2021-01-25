using E_Project.Areas.Admin.Model;
using E_Project.Areas.Admin.Utils;
using ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Project.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login","Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (model.account == null)
            {
                model.account = "";
            }
            if (model.password == null)
            {
                model.password = "";
            }
            var checkLogin = new AccountDBModel().Login(model.account, model.password);
            if (checkLogin != 0 && ModelState.IsValid)
            {
                var result = new AccountDBModel().getAccount(model.account, model.password);
                SessionHelper.SetSession(new InfoSession() { id = result.N_ID , account = result.S_ACCOUNT, password = result.S_PASSWORD, fullName = result.S_FULLNAME, address = result.S_ADDRESS, birthDay = result.D_BIRTHDAY });
                return RedirectToAction("List", "Department");
            } else
            {
                ModelState.AddModelError("", "Login failed, please try again !");
            }
            return View(model);
        }
    }
}