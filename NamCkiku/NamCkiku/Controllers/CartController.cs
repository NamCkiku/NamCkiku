using Models.DAO;
using Models.EF;
using NamCkiku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace NamCkiku.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        private string CartSession = "CartSession";
        /// <summary>
        /// Hiển Thị Giỏ Hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult Cart()
        {
            var cart = Session[CartSession];//Gọi Session
            var list = new List<CartItem>();//List CartItem
            if (cart != null)
            {
                list = (List<CartItem>)cart;//Gán Session vào List CartItem
            }
            return View(list);
        }
        /// <summary>
        /// Thêm Giỏ Hàng
        /// </summary>
        /// <param name="ProductID">ID</param>
        /// <param name="Quantity">Số Lượng</param>
        /// <returns></returns>
        public ActionResult AddCart(int ProductID, int Quantity)
        {
            var product = new ProductDAO().ViewDetailProduct(ProductID);//Lấy ra Product Theo ID
            var cart = Session[CartSession];//Khởi Tạo biến Session
            if (cart != null)//Nếu Chưa có Product nào
            {
                var list = (List<CartItem>)cart;//Gán Session vào List CartItem
                if (list.Exists(x => x.Product.ID == ProductID))//Nếu có chưa ProductID
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == ProductID)
                        {
                            item.Quantity += Quantity;//Số Lượng Cộng Thêm
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart Item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = Quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart Item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = Quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Cart");
        }
        [HttpPost]
        public ActionResult UpdateCart(string dataUpdate)
        {
            var product = new JavaScriptSerializer().Deserialize<List<CartItem>>(dataUpdate);
            var cart = (List<CartItem>)Session[CartSession];
            foreach (var item in cart)
            {
                var itemCart = product.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (itemCart != null)
                {
                    item.Quantity = itemCart.Quantity;
                }
            }
            return View();
        }

        public ActionResult RemoveAll()
        {
            Session[CartSession] = null;
            return View();
        }
        [HttpPost]
        public ActionResult RemoveAt(int id)
        {
            var cart = (List<CartItem>)Session[CartSession];
            cart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = cart;
            return View();
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];//Gọi Session
            var list = new List<CartItem>();//List CartItem
            if (cart != null)
            {
                list = (List<CartItem>)cart;//Gán Session vào List CartItem
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string shipName, string Address, string Phone, string email)
        {
            var order = new Order();
            order.CreatedDate = DateTime.Now;
            order.ShipName = shipName;
            order.ShipAddress = Address;
            order.ShipMobile = Phone;
            order.ShipEmail = email;
            try
            {
                var id = new OrderDAO().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new OrderDetailDAO();
                foreach (var item in cart)
                {
                    var orderDetail = new OderDetail();
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Finish");
        }
        public ActionResult Finish()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
    }
}