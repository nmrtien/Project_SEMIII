using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using E_Project.Areas.Admin.Model;
using E_Project.Areas.Admin.Utils;
using ModelEntity;
using ModelEntity.Frameworks;

namespace E_Project.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Home

        public ActionResult List(string type)
        {
            InfoSession model = new InfoSession();

            model = SessionHelper.GetInfoSession();
            Session["infoSession"] = model;
            var accountModel = new AccountDBModel();
            if (type == null)
            {
                var listManager = accountModel.getListManager();
                return View(listManager);
            } else
            {
                if (type.Equals("employee"))
                {
                    var listEmployee = accountModel.getListEmployee();
                    return View(listEmployee);
                }
                else
                {
                    var listManager = accountModel.getListManager();
                    return View(listManager);
                }
            }
            
        }
        public ActionResult UpdateStatusAccount(int n_id, string s_status)
        {
            
            var accountModel = new AccountDBModel();
            s_status = s_status.Equals("Active") ? "InActive" : "Active";
            accountModel.updateStatusAccount(n_id, s_status);
            return RedirectToAction("List","Account");
        }

        // GET: Admin/Store/Create
        public ActionResult Create()
        {
            var accountDBModel = new AccountDBModel();
            var accountModel = new AccountModel();
            List<TB_STORE> storeList = accountDBModel.getAllStore();
            List<TB_DEPARTMENT> departmentList = accountDBModel.getAllDepartment();
            accountModel.storeList = new List<DropDownModel>();
            accountModel.departmentList = new List<DropDownModel>();
            accountModel.accountTypeList = new List<DropDownModel>();
            accountModel.accountTypeList.Add(new DropDownModel(0, "employee"));
            accountModel.accountTypeList.Add(new DropDownModel(1, "manager"));

            storeList.ForEach(store => accountModel.storeList.Add(new DropDownModel(store.N_ID, store.S_NAME)));
            departmentList.ForEach(department => accountModel.departmentList.Add(new DropDownModel(department.N_ID, department.S_NAME)));
            return View(accountModel);
        }

        // POST: Admin/Store/Create
        [HttpPost]
        public ActionResult Create(AccountModel accountModel)
        {
            try
            {

                var accountDBModel = new AccountDBModel();
                TB_ACCOUNT account = new TB_ACCOUNT();
                account.S_ACCOUNT = accountModel.account;
                account.S_PASSWORD = accountModel.password;
                account.S_FULLNAME = accountModel.fullName;
                account.S_PHONE = accountModel.phone;
                account.S_ADDRESS = accountModel.address;
                account.S_TECHNICAL = accountModel.technical;
                account.D_BIRTHDAY = accountModel.birthDay;
                account.S_TYPE = accountModel.type == 0 ? "employee" : "manager";
                account.N_STORE_ID = accountModel.storeId;
                account.N_DEPARTMENT_ID = accountModel.departmentId;
                accountDBModel.createAccount(account);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}