using Common;
using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamCkiku.Areas.Administrator.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /Administrator/User/
        public ActionResult ViewUser()
        {
            var dao = new UserDAO();
            var result = dao.ViewUser();
            return View(result);
        }
        //public JsonResult ViewAll()
        //{
        //    var dao = new UserDAO();
        //    var result = dao.ViewUser();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        [HttpGet]
        public ActionResult _CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.CreatedDate == null)
                {
                    user.CreatedDate = DateTime.Now;
                }
                var dao = new UserDAO();
                var ecryptMd5 = Encryptor.MD5Hash(user.Password);
                user.Password = ecryptMd5;
                int id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm Thành Công", "success");
                    return RedirectToAction("ViewUser", "User");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm Không Thành Công");
            }
            return RedirectToAction("ViewUser");
        }
        [HttpGet]
        public ActionResult _UpdateUser(int id)
        {
            var user = new UserDAO().ViewDetail(id);
            return PartialView("_UpdateUser", user);
        }

        [HttpPost]
        public ActionResult UpdateUser(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var ecryptMd5 = Encryptor.MD5Hash(user.Password);
                    user.Password = ecryptMd5;
                }
                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("SửaThành Công", "success");
                    return RedirectToAction("ViewUser", "User");
                }
            }
            else
            {
                ModelState.AddModelError("", "Cập Nhập Không Thành Công");
            }
            return RedirectToAction("ViewUser");
        }
        [HttpGet]
        public ActionResult _DeleteUser(int id)
        {
            var user = new UserDAO().ViewDetail(id);
            return PartialView("_DeleteUser", user);
        }
        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            var user = new UserDAO().Delete(id);
            return RedirectToAction("ViewUser", user);
        }
    }
}