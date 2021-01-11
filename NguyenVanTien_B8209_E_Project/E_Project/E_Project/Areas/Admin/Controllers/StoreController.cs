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
    public class StoreController : Controller
    {
        // GET: Admin/Store
        public ActionResult List()
        {
            var storeModel = new StoreDBModel();
            var storeList = storeModel.getListStore();
            return View(storeList);
        }

        public ActionResult UpdateStatusStore(string s_id, string s_status)
        {
            var storeDBModel = new StoreDBModel();
            
            s_status = s_status.Equals("Active") ? "InActive" : "Active";
            storeDBModel.updateStatusStore(s_id, s_status);
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
            var accountModel = new AccountDBModel();
            List<TB_ACCOUNT> accountList = accountModel.getDropDownEmployee();
            storeModel.listAccount = new List<AccountModel>();
            //storeModel.listAccount.Add(new AccountModel(0, "SELECT AN MANAGER"));
            accountList.ForEach(account => storeModel.listAccount.Add(new AccountModel(account.S_ID, account.S_FULLNAME)));
            return View(storeModel);
        }

        // POST: Admin/Store/Create
        [HttpPost]
        public ActionResult Create(StoreModel storeModel)
        {
            try
            {
                int employeeID = Request.Form["ddlAccount"] == null ? 0 : Int32.Parse(Request.Form["ddlAccount"]);

                var storeDBModel = new StoreDBModel();
                TB_STORE store = new TB_STORE();
                store.S_NAME = storeModel.storeName;
                store.S_CONTACT = storeModel.contact;
                store.S_ADDRESS = storeModel.address;
                store.S_EMPLOYEE_ID = employeeID;
                storeDBModel.createStore(store);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Store/Edit/5
        public ActionResult Edit(int s_id)
        {
            var storeDBModel = new StoreDBModel();
            var storeModel = new StoreModel();
            var accountModel = new AccountDBModel();
            List<TB_ACCOUNT> accountList = accountModel.getDropDownEmployee();
            storeModel.listAccount = new List<AccountModel>();
            storeModel.listAccount.Add(new AccountModel(0, "SELECT ANOTHER MANAGER"));
            accountList.ForEach(account => storeModel.listAccount.Add(new AccountModel(account.S_ID, account.S_FULLNAME)));
            var store = storeDBModel.getStoreById(s_id);
            storeModel.id = store.S_ID;
            storeModel.storeName = store.S_NAME;
            storeModel.contact = store.S_CONTACT;
            storeModel.address = store.S_ADDRESS;
            storeModel.status = store.S_STATUS;
            storeModel.employeeId = store.S_EMPLOYEE_ID;
            return View(storeModel);
        }

        // POST: Admin/Store/Edit/5
        [HttpPost]
        
        public ActionResult Edit(StoreModel storeModel)
        {
            try
            {
                
                    int employeeID = Request.Form["ddlAccount"] == null ? 0 : Int32.Parse(Request.Form["ddlAccount"]);
                    var storeDBModel = new StoreDBModel();
                    TB_STORE store = new TB_STORE();
                store.S_ID = storeModel.id;
                store.S_NAME = storeModel.storeName;
                store.S_ADDRESS = storeModel.address;
                store.S_CONTACT = storeModel.contact;
                store.S_EMPLOYEE_ID = employeeID;
                storeDBModel.updateStoreById(store);
                    
                    return RedirectToAction("List");
                    
               
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
