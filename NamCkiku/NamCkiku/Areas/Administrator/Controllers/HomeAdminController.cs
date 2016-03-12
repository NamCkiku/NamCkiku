using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamCkiku.Areas.Administrator.Controllers
{
    public class HomeAdminController : BaseController
    {
        //
        // GET: /Administrator/HomeAdmin/
        public ActionResult Index()
        {
            return View();
        }
	}
}