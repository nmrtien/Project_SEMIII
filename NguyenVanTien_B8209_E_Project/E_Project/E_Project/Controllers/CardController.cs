using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEntity;
using E_Project.Areas.Admin.Utils;
using E_Project.Areas.Admin.Model;
using ModelEntity.Frameworks;
using E_Project.Models;

namespace E_Project.Controllers
{
    public class CardController : Controller
    {
        // GET: Card
        public ActionResult Index()
        {

            InfoSession modelSession = new InfoSession();

            modelSession = SessionHelper.GetInfoSession();
            if (modelSession == null)
            {
                return RedirectToAction("Login","User");
            } else
            {
                Session["infoSession"] = modelSession;

                var orderDBModel = new OrderDBModel();
                /*OrderModel orderModel = new OrderModel();*/
                var models = orderDBModel.getOrdersByCustomerId(modelSession.id);
                CardModel model = new CardModel();
                model.orders = models;
                model.total = 0;
                foreach (TB_ORDER order in models)
                {
                    if (order.S_STATUS.Equals("InActive") && order.PRICE != null)
                    {
                        model.total = (double)(model.total + (order.PRICE * order.N_TOTAL));
                    }
                }
                return View(model);
            }
            

        }

        public ActionResult Active()
        {
            var modelDB = new OrderDBModel();

            InfoSession modelSession = new InfoSession();

            modelSession = SessionHelper.GetInfoSession();
            Session["infoSession"] = modelSession;
            modelDB.activeOrderByCustomerId(modelSession.id);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            var modelDB = new OrderDBModel();
            modelDB.deleteOrderById(id);
            return RedirectToAction("Index");
        }
    }
}