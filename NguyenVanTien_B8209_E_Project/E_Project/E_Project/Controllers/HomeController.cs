using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Project.Models;
using ModelEntity;
using ModelEntity.Frameworks;

namespace E_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var productModelDB = new ProductDBModel();
            var planModelDB = new PlanDBModel();
            IndexModel model = new IndexModel();
            model.Products = productModelDB.getListProductTop6();
            model.Plans = planModelDB.getListPlanTop3();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}