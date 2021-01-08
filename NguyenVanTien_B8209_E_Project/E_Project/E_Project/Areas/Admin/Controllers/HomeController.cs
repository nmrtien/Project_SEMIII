using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Project.Areas.Admin.Model;
using E_Project.Areas.Admin.Utils;
using ModelEntity;

namespace E_Project.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home

        public ActionResult Index()
        {
            InfoSession model = new InfoSession();

            model = SessionHelper.GetInfoSession();
            Session["infoSession"] = model;
            var accountModel = new AccountModel();
            var listEmployee = accountModel.getListEmployee();
            return View(listEmployee);
        }

        
        public ActionResult InActiveEmployee(string s_id)
        {
            
            var accountModel = new AccountModel();
            accountModel.inActiveAccount(s_id);
            return RedirectToAction("Index","Home");
        }
    }
}