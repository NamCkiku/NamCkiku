using Models.DAO;
using NamCkiku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamCkiku.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        /// <summary>
        /// Hàm Lấy Ra Product mới nhất,hot
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var productDao = new ProductDAO();
            ViewBag.NewProduct = productDao.ListNewProduct(7);//Hiển Thị theo ViewBag
            ViewBag.Feature = productDao.ListFeatureProduct(7);
            return View();
        }
        public ActionResult Detail()
        {
            return View();
        }
        public PartialViewResult _HeaderCart()
        {
            var cart = Session[Common.CommonConstants.CartSession];//Gọi Session
            var list = new List<CartItem>();//List CartItem
            if (cart != null)
            {
                list = (List<CartItem>)cart;//Gán Session vào List CartItem
            }
            return PartialView(list);
        }
	}
}