using u21437221_HW06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u21437221_HW06.Controllers
{
    public class ProductsController : Controller
    {
        private BikeStoresDB db = new BikeStoresDB();
        // GET: Products
        public ActionResult ProductsResultsView()
        {
            return View(db.products.ToList());
        }

        public JsonResult List()
        {
            return Json(db.products.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(product product)
        {
            db.products.Add(product);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(product product)
        {
            var data = db.products.FirstOrDefault(x => x.product_id == product.product_id);
            if (data != null)
            {
                data.product_name = product.product_name;
                data.model_year = product.model_year;
                data.list_price = product.list_price;
                data.brand = product.brand;
                data.category = product.category;
                db.SaveChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int ID)
        {
            var data = db.products.FirstOrDefault(x => x.product_id == ID);
            db.products.Remove(data);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}