using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamCkiku.Areas.Administrator.Controllers
{
    public class ProductController : BaseController
    {
        public void SelectViewBag(long? selectedID = null)
        {
            var dao = new ProductCategoryDAO();
            ViewBag.CategoryID = new SelectList(dao.ListProductCategory(), "ID", "Name", selectedID);
        }
        public ActionResult ViewProduct()
        {
            var dao = new ProductDAO();
            var result = dao.ViewProduct();
            return View(result);
        }
        [HttpGet]
        public ActionResult _CreateProduct()
        {
            SelectViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.CreatedDate == null)
                {
                    product.CreatedDate = DateTime.Now;
                }
                var dao = new ProductDAO();
                int id = dao.Insert(product);
                if (id > 0)
                {
                    SetAlert("Thêm Thành Công", "success");
                    return RedirectToAction("ViewProduct", "Product");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm Không Thành Công");
            }
            return RedirectToAction("ViewProduct");
        }
        [HttpGet]
        public ActionResult _EditProduct(int id)
        {
            SelectViewBag();
            var product = new ProductDAO().GetByID(id);
            return PartialView("_EditProduct", product);
        }
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
                var result = dao.Update(product);
                if (result)
                {
                    SetAlert("SửaThành Công", "success");
                    return RedirectToAction("ViewProduct", "Product");
                }
            }
            else
            {
                ModelState.AddModelError("", "Cập Nhập Không Thành Công");
            }
            return RedirectToAction("ViewProduct");
        }
        [HttpGet]
        public ActionResult _DeleteProduct(int id)
        {
            SelectViewBag();
            var product = new ProductDAO().GetByID(id);
            return PartialView("_DeleteProduct", product);
        }
        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            var product = new ProductDAO().Delete(id);
            return RedirectToAction("ViewProduct", product);
        }
    }
}