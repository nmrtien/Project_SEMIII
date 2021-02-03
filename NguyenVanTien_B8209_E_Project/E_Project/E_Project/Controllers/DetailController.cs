using E_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEntity;
using ModelEntity.Frameworks;
using E_Project.Areas.Admin.Utils;

namespace E_Project.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        public ActionResult Index(int id, string type)
        {
            if (id < 1)
            {
                return RedirectToAction("Index","Home");
            } else
            {
                InfoSession modelSession = new InfoSession();

                modelSession = SessionHelper.GetInfoSession();
                Session["infoSession"] = modelSession;
                DetailModel detailModel = new DetailModel();
                if (type.Equals("PLAN"))
                {
                    var planDBModel = new PlanDBModel();
                    var model = planDBModel.getPlanById(id);
                    detailModel.id = model.N_ID;
                    detailModel.name = model.S_NAME;
                    detailModel.type = type;
                    detailModel.detail = model.S_DETAIL;
                    detailModel.description = model.S_DESCRIPTION;
                    detailModel.total = 1;
                }
                else
                {
                    var productDBModel = new ProductDBModel();
                    var model = productDBModel.getProductById(id);
                    detailModel.id = model.N_ID;
                    detailModel.name = model.S_NAME;
                    detailModel.type = type;
                    detailModel.detail = model.S_DETAIL;
                    detailModel.description = model.S_DESCRIPTION;
                    detailModel.price = model.N_PRICE;
                    detailModel.total = 1;
                }
                return View(detailModel);
            }
            
        }

        public ActionResult Create(int id, string type, double price, int total)
        {
            InfoSession modelSession = new InfoSession();

            modelSession = SessionHelper.GetInfoSession();
            if (modelSession == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                
                var orderDBModel = new OrderDBModel();
                TB_ORDER order = new TB_ORDER();
                order.N_AMOUNT = price * total;
                order.N_TOTAL = total;
                order.S_TYPE = type;
                order.S_CUSTOMER_NAME = modelSession.fullName;
                order.S_PHONE = modelSession.phone;
                order.S_ADDRESS = modelSession.address;
                order.N_CUSTOMER_ID = modelSession.id;
                orderDBModel.createOrder(order, id);
                return RedirectToAction("Index","Card");
            }

        }
    }
}