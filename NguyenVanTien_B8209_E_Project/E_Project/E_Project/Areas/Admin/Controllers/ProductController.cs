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
    public class ProductController : Controller
    {
        public ActionResult List()
        {

            var modelDB = new ProductDBModel();
            var list = modelDB.getListProduct();
            return View(list);
        }

        public ActionResult UpdateStatusProduct(int n_id, string s_status)
        {
            var modelDB = new ProductDBModel();

            s_status = s_status.Equals("Active") ? "InActive" : "Active";
            modelDB.updateStatusProduct(n_id, s_status);
            return RedirectToAction("List", "Product");
        }

        // GET: Admin/Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Store/Create
        public ActionResult Create()
        {
            var model = new ProductModel();
            return View(model);
        }

        // POST: Admin/Store/Create
        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            try
            {

                var modelDB = new ProductDBModel();
                TB_PRODUCT product = new TB_PRODUCT();
                product.S_NAME = model.productName;
                product.N_PRICE = model.price;
                product.S_TYPE = model.type;
                product.S_DETAIL = model.detail;
                product.S_DESCRIPTION = model.description;
                modelDB.createProduct(product);

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
            var modelDB = new ProductDBModel();
            var model = new ProductModel();
            var result = modelDB.getProductById(n_id);
            model.id = result.N_ID;
            model.productName = result.S_NAME;
            model.price = result.N_PRICE;
            model.type = result.S_TYPE;
            model.detail = result.S_DETAIL;
            model.description = result.S_DESCRIPTION;
            model.status = result.S_STATUS;
            model.createdDate = result.D_CREATED;
            return View(model);
        }

        // POST: Admin/Store/Edit/5
        [HttpPost]

        public ActionResult Edit(ProductModel model)
        {
            try
            {


                var modelDB = new ProductDBModel();
                TB_PRODUCT product = new TB_PRODUCT();
                product.N_ID = model.id;
                product.S_NAME = model.productName;
                product.N_PRICE = model.price;
                product.S_TYPE = model.type;
                product.S_DETAIL = model.detail;
                product.S_DESCRIPTION = model.description;
                modelDB.updateProductById(product);

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