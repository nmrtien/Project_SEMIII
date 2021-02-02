using E_Project.Areas.Admin.Model;
using E_Project.Areas.Admin.Utils;
using ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEntity.Frameworks;

namespace E_Project.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
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
            var checkLogin = new CustomerDBModel().Login(model.account, model.password);
            if (checkLogin != 0 && ModelState.IsValid)
            {
                var result = new CustomerDBModel().getCustomer(model.account, model.password);
                SessionHelper.SetSession(new InfoSession() { id = result.N_ID, account = result.S_ACCOUNT, password = result.S_PASSWORD, fullName = result.S_NAME, address = result.S_ADDRESS });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Login failed, please try again !");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            var customerModel = new CustomerModel();
            return View(customerModel);
        }

        [HttpPost]
        public ActionResult Register(CustomerModel model)
        {
            try
            {
                    var modelDB = new CustomerDBModel();
                    TB_CUSTOMER customer = new TB_CUSTOMER();
                    customer.S_ACCOUNT = model.account;
                    customer.S_PASSWORD = model.password;
                    customer.S_NAME = model.customerName;
                    customer.S_PHONE = model.phone;
                    customer.S_ADDRESS = model.address;
                    customer.S_DESCRIPTION = model.description;
                    modelDB.registerCustomer(customer);

                    return RedirectToAction("Login");
                
            }
            catch
            {
                return View();
            }
        }
    }
}