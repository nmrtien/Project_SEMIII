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
            var accountModel = new AccountDBModel();
            var listEmployee = accountModel.getListEmployee();
            return View(listEmployee);
        }

        
        public ActionResult UpdateStatusEmployee(string s_id, string s_status)
        {
            
            var accountModel = new AccountDBModel();
            s_status = s_status.Equals("Active") ? "InActive" : "Active";
            accountModel.updateStatusAccount(s_id, s_status);
            return RedirectToAction("Index","Home");
        }
    }
}