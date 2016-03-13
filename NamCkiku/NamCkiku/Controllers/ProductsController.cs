using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamCkiku.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category(int id)
        {
            return View();
        }
        /// <summary>
        /// Hàm Chi Tiết Sản Phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ViewDetailProduct(int id)
        {
            var model = new ProductDAO().ViewDetailProduct(id); //Lấy ra sản phẩm muốn lấy theo ID
            ViewBag.Category = new ProductCategoryDAO().ViewDetailProductCategory(model.ID); //Lấy Ra Loại Sản Phẩm Theo ID
            return View(model);
        }
	}
}