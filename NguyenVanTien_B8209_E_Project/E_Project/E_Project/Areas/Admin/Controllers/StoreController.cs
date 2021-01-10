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
    public class StoreController : Controller
    {
        // GET: Admin/Store
        public ActionResult List()
        {
            var storeModel = new StoreModel();
            var storeList = storeModel.getListStore();
            return View(storeList);
        }

        public ActionResult InActiveStore(string s_id)
        {
            var storeModel = new StoreModel();
            storeModel.inActiveStore(s_id);
            return RedirectToAction("List", "Store");
        }

        // GET: Admin/Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Store/Create
        public ActionResult Create()
        {
            var storeModel = new StoreModel();
            var store = storeModel.getListStore();
            return View(store);
        }

        // POST: Admin/Store/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Store/Edit/5
        public ActionResult Edit(string s_id)
        {
            var storeModel = new StoreModel();
            var store = storeModel.getStoreById(s_id);
            return View(store);
        }

        // POST: Admin/Store/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
