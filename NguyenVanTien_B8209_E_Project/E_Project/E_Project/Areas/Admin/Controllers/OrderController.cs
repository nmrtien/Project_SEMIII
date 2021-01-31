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

        public ActionResult UpdateStatusOrder(int id, string name, DateTime date, string s_status)
        {
            var modelDB = new OrderDBModel();

            s_status = s_status.Equals("Active") ? "InActive" : "Active";
            modelDB.updateStatusOrder(id, s_status);
            return RedirectToAction("DetailOrder", "Order", new { name, date });
        }

        public ActionResult DetailOrder(string name, DateTime date)
        {
            var modelDB = new OrderDBModel();

            var list = modelDB.getDetailOrder(name, date);
            return View(list);
        }

        // GET: Admin/Store/Edit/5
        public ActionResult Edit(int n_id)
        {
            var modelDB = new OrderDBModel();
            var model = new OrderModel();
            var result = modelDB.getOrderById(n_id);
            model.id = result.N_ID;
            model.customerName = result.S_CUSTOMER_NAME;
            model.phone = result.S_PHONE;
            model.address = result.S_ADDRESS;
            model.productName = result.PRODUCT_NAME;
            model.planName = result.PLAN_NAME;
            model.amount = result.N_AMOUNT;
            model.total = result.N_TOTAL;
            model.description = result.S_DESCRIPTION;
            model.status = result.S_STATUS;
            model.createdDate = result.D_CREATED;
            return View(model);
        }

        // POST: Admin/Store/Edit/5
        [HttpPost]

        public ActionResult Edit(OrderModel model)
        {
            try
            {

                var modelDB = new OrderDBModel();
                TB_ORDER order = new TB_ORDER();
                order.N_ID = model.id;
                order.S_CUSTOMER_NAME = model.customerName;
                order.S_PHONE = model.phone;
                order.S_ADDRESS = model.address;
                order.S_DESCRIPTION = model.description;
                modelDB.updateOrderById(order);

                return RedirectToAction("List");


            }
            catch
            {
                return View();
            }
        }
    }
}