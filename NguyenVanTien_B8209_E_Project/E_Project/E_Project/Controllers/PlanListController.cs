using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Project.Models;
using ModelEntity;
using E_Project.Areas.Admin.Model;
using E_Project.Areas.Admin.Utils;
using ModelEntity.Frameworks;


namespace E_Project.Controllers
{
    public class PlanListController : Controller
    {
        // GET: Plan
        public ActionResult Index()
        {
            InfoSession modelSession = new InfoSession();

            modelSession = SessionHelper.GetInfoSession();
            Session["infoSession"] = modelSession;
            var productModelDB = new ProductDBModel();
            var planModelDB = new PlanDBModel();
            IndexModel model = new IndexModel();
            model.Products = productModelDB.getListProduct();
            model.Plans = planModelDB.getListPlan();
            return View(model);
        }
    }
}