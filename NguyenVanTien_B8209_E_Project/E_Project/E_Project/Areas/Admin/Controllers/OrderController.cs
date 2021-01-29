using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Project.Areas.Admin.Model;
using E_Project.Areas.Admin.Utils;
using ModelEntity;
using ModelEntity.Frameworks;

namespace E_Project.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult List()
        {

            var modelDB = new OrderDBModel();
            var list = modelDB.getListOrder();
            return View(list);
        }

        public ActionResult UpdateStatusOrder(string name, DateTime date, string s_status)
        {
            var modelDB = new OrderDBModel();

            s_status = s_status.Equals("Active") ? "InActive" : "Active";
            modelDB.updateStatusOrder(name, date, s_status);
            return RedirectToAction("List", "Product");
        }

        public ActionResult DetailOrder(string name, DateTime date)
        {
            var modelDB = new OrderDBModel();

            modelDB.getDetailOrder(name, date);
            return RedirectToAction("List", "Product");
        }
    }
}