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
    public class DepartmentController : Controller
    {
        public ActionResult List()
        {
            InfoSession modelSession = new InfoSession();

            modelSession = SessionHelper.GetInfoSession();
            Session["infoSession"] = modelSession;
            var model = new DepartmentDBModel();
            var list = model.getListDepartment();
            return View(list);
        }

        public ActionResult UpdateStatusDepartment(int n_id, string s_status)
        {
            var model = new DepartmentDBModel();

            s_status = s_status.Equals("Active") ? "InActive" : "Active";
            model.updateStatusDepartment(n_id, s_status);
            return RedirectToAction("List", "Department");
        }

        // GET: Admin/Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Store/Create
        public ActionResult Create()
        {
            var model = new DepartmentModel();
            return View(model);
        }

        // POST: Admin/Store/Create
        [HttpPost]
        public ActionResult Create(DepartmentModel departmentModel)
        {
            try
            {

                var model = new DepartmentDBModel();
                TB_DEPARTMENT department = new TB_DEPARTMENT();
                department.S_NAME = departmentModel.departmentName;
                department.S_CONTACT = departmentModel.contact;
                model.createDepartment(department);

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
            var model = new DepartmentDBModel();
            var departmentModel = new DepartmentModel();
            var store = model.getDepartmentById(n_id);
            departmentModel.id = store.N_ID;
            departmentModel.departmentName = store.S_NAME;
            departmentModel.contact = store.S_CONTACT;
            departmentModel.status = store.S_STATUS;
            return View(departmentModel);
        }

        // POST: Admin/Store/Edit/5
        [HttpPost]

        public ActionResult Edit(DepartmentModel departmentModel)
        {
            try
            {


                var model = new DepartmentDBModel();
                TB_DEPARTMENT department = new TB_DEPARTMENT();
                department.N_ID = departmentModel.id;
                department.S_NAME = departmentModel.departmentName;
                department.S_CONTACT = departmentModel.contact;
                model.updateDepartmentById(department);

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