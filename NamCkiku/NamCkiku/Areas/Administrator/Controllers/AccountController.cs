using Common;
using Models.DAO;
using NamCkiku.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamCkiku.Areas.Administrator.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Administrator/Account/
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Trang Đăng Nhập
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(AccountModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));  //Mã hóa MD5
                if (result == 1) //Nếu tên tài khoản đúng
                {
                    var user = dao.GetByID(model.UserName); //gị giá trị của tên tài khoản
                    var userSession = new UserLogin(); //Gán Vài Session
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(Common.CommonConstants.User_Session, userSession); //Thêm vào Session
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else if (result == 0) //Nếu tên tài khoản bằng 0
                {
                    ModelState.AddModelError("", "Tài Khoản Không Tồn Tại");
                }
                else if (result == -1) //Nếu Trạng Thái bằng False
                {
                    ModelState.AddModelError("", "Tài Khoản Đang Bị Khóa");
                }
                else if (result == -2) //Nếu Tài Khoản Sai
                {
                    ModelState.AddModelError("", "Mật Khẩu Không Đúng");
                }
                else  //nẾU tÀI khoản Không đúng
                {
                    ModelState.AddModelError("", "Đăng Nhập Không Thành Công");
                }
            }
            return View("Login");
        }
    }
}