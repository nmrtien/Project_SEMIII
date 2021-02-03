using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Project.Areas.Admin.Model;
using E_Project.Areas.Admin.Utils;
using ModelEntity;
using ModelEntity.Frameworks;

namespace E_Project.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            var storeModel = new StoreDBModel();
            var storeList = storeModel.getListStore();
            return View(storeList);
        }
    }
}