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
    public class CustomerController : Controller
    {
        public ActionResult List()
        {

            var modelDB = new CustomerDBModel();
            var list = modelDB.getListCustomer();
            return View(list);
        }

        public ActionResult UpdateStatusCustomer(int id, string s_status)
        {
            var modelDB = new CustomerDBModel();

            s_status = s_status.Equals("Active") ? "InActive" : "Active";
            modelDB.updateStatusCustomer(id, s_status);
            return RedirectToAction("List");
        }

        // GET: Admin/Store/Edit/5
        public ActionResult Edit(int n_id)
        {
            var modelDB = new CustomerDBModel();
            var model = new CustomerModel();
            var result = modelDB.getCustomerById(n_id);
            model.id = result.N_ID;
            model.customerName = result.S_NAME;
            model.phone = result.S_PHONE;
            model.address = result.S_ADDRESS;
            model.planName = result.PLAN_NAME;
            model.description = result.S_DESCRIPTION;
            model.status = result.S_STATUS;
            model.code = result.S_CODE;
            model.createdDate = result.D_CREATED;
            return View(model);
        }

        // POST: Admin/Store/Edit/5
        [HttpPost]

        public ActionResult Edit(CustomerModel model)
        {
            try
            {

                var modelDB = new CustomerDBModel();
                TB_CUSTOMER customer = new TB_CUSTOMER();
                customer.N_ID = model.id;
                customer.S_NAME = model.customerName;
                customer.S_PHONE = model.phone;
                customer.S_ADDRESS = model.address;
                customer.S_DESCRIPTION = model.description;
                modelDB.updateOrderById(customer);

                return RedirectToAction("List");


            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Store/Create
        public ActionResult Create()
        {
            var modelDB = new CustomerDBModel();
            var customerModel = new CustomerModel();
            List<TB_ACCOUNT> saleList = modelDB.getListSale();
            List<TB_PLAN> planList = modelDB.getListPlan();
            customerModel.saleList = new List<DropDownModel>();
            customerModel.planList = new List<DropDownModel>();
            saleList.ForEach(store => customerModel.saleList.Add(new DropDownModel(store.N_ID, store.S_FULLNAME)));
            planList.ForEach(plan => customerModel.planList.Add(new DropDownModel(plan.N_ID, plan.S_NAME)));
            return View(customerModel);
        }

        // POST: Admin/Store/Create
        [HttpPost]
        public ActionResult Create(CustomerModel model)
        {
            try
            {
                var codeTempl = "";
                foreach (DropDownModel element in model.planList)
                {
                    if(element.id == model.planId)
                    {
                        codeTempl = element.modelName[0].ToString();
                    }
                }
                Random rnd = new Random();
                int ramdom01 = rnd.Next(10000, 99999);
                int ramdom02 = rnd.Next(10000, 99999);
                

                var modelDB = new CustomerDBModel();
                TB_CUSTOMER customer = new TB_CUSTOMER();
                TB_PLAN_DETAIL planDetail = new TB_PLAN_DETAIL();
                planDetail.N_AMOUNT = model.planDetail.amount;
                planDetail.S_DETAIL = model.planDetail.detail;
                planDetail.S_DESCRIPTION = model.planDetail.description;
                planDetail.D_EXPRIRE = model.planDetail.exprireDate;
                planDetail.N_CUSTOMER_ID = model.id;
                planDetail.N_PLAN_ID = model.planId;
                modelDB.createPlanDetail(planDetail);

                customer.S_CODE = codeTempl + ramdom01 + ramdom02;
                customer.S_NAME = model.customerName;
                customer.S_PHONE = model.phone;
                customer.S_ADDRESS = model.address;
                customer.S_DESCRIPTION = model.description;
                customer.N_ACCOUNT_ID = model.saleId;
                modelDB.createCustomer(customer);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}