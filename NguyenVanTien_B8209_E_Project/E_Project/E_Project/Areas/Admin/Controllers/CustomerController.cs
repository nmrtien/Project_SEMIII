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
                modelDB.updateCustomerById(customer);

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

            var customerModel = new CustomerModel();
 
            return View(customerModel);
        }


        // POST: Admin/Store/Create
        [HttpPost]
        public ActionResult Create(CustomerModel model)
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

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }


        // GET: 
        public ActionResult Detail(int id)
        {
            var modelDB = new CustomerDBModel();
            var customer = modelDB.getCustomerById(id);
            return View(customer);
        }

        // GET: 
        public ActionResult SelectPlan(int id)
        {
            CustomerDetailModel customerDetailModel = new CustomerDetailModel();
            var modelDB = new PlanDBModel();
            var list = modelDB.getListPlan();

            customerDetailModel.Plans = list;
            customerDetailModel.customerId = id;
            return View(customerDetailModel);
        }

        // GET: 
        [HttpGet]
        public ActionResult PlanDetail(int customerId, int planId)
        {
            var planDetail = new PlanDetailModel();
            planDetail.accountId = customerId;
            planDetail.planId = planId;
            return View(planDetail);
        }


        [HttpPost]
        public ActionResult PlanDetail(PlanDetailModel model)
        {
            var id = Request.Params["customerId"].ToString();
            TB_PLAN_DETAIL detail = new TB_PLAN_DETAIL();
            detail.N_AMOUNT = model.amount;
            detail.N_CUSTOMER_ID = int.Parse(id) ;
            detail.N_PLAN_ID = model.planId;
            detail.S_DESCRIPTION = model.description;
            detail.S_DETAIL = model.detail;
            detail.D_EXPRIRE = model.exprireDate;
            var modelDB = new CustomerDBModel();
            var modelDB2 = new PlanDBModel();
            modelDB.createPlanDetail(detail);
            var plan = modelDB2.getPlanById(model.planId);

            Random rnd = new Random();
            int ramdom01 = rnd.Next(10000, 99999);
            int ramdom02 = rnd.Next(10000, 99999);
            TB_CUSTOMER customer = new TB_CUSTOMER();
            customer.N_ID = int.Parse(id);
            customer.S_CODE = plan.S_NAME[0].ToString() + ramdom01.ToString() + ramdom02.ToString();
            modelDB.updateCodeById(customer);
            return RedirectToAction("List");
        }
    }
}