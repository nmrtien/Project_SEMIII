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
    public class PlanController : Controller
    {
        public ActionResult List()
        {

            var modelDB = new PlanDBModel();
            var list = modelDB.getListPlan();
            return View(list);
        }

        public ActionResult UpdateStatusPlan(int n_id, string s_status)
        {
            var modelDB = new PlanDBModel();

            s_status = s_status.Equals("Active") ? "InActive" : "Active";
            modelDB.updateStatusPlan(n_id, s_status);
            return RedirectToAction("List", "Plan");
        }

        // GET: Admin/Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Store/Create
        public ActionResult Create()
        {
            var model = new PlanModel();
            return View(model);
        }

        // POST: Admin/Store/Create
        [HttpPost]
        public ActionResult Create(PlanModel model)
        {
            try
            {

                var modelDB = new PlanDBModel();
                TB_PLAN plan = new TB_PLAN();
                plan.S_NAME = model.name;
                plan.S_TYPE = model.type;
                plan.S_DETAIL = model.detail;
                plan.S_DESCRIPTION = model.description;
                modelDB.createPlan(plan);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Store/Edit/5
        public ActionResult Edit(int n_id)
        {
            var modelDB = new PlanDBModel();
            var model = new PlanModel();
            var result = modelDB.getPlanById(n_id);
            model.id = result.N_ID;
            model.name = result.S_NAME;
            model.type = result.S_TYPE;
            model.detail = result.S_DETAIL;
            model.description = result.S_DESCRIPTION;
            model.status = result.S_STATUS;
            model.createdDate = result.D_CREATED;
            return View(model);
        }

        // POST: Admin/Store/Edit/5
        [HttpPost]

        public ActionResult Edit(PlanModel model)
        {
            try
            {


                var modelDB = new PlanDBModel();
                TB_PLAN plan = new TB_PLAN();
                plan.N_ID = model.id;
                plan.S_NAME = model.name;
                plan.S_DETAIL = model.detail;
                plan.S_TYPE = model.type;
                plan.S_DESCRIPTION = model.description;
                modelDB.updatePlanById(plan);

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