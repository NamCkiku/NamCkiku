using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamCkiku.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        [ChildActionOnly]
        public ActionResult _MainMenu()
        {
            var model = new MenuDAO().ViewMenuByGroupID(1);
            return PartialView(model);
        }
	}
}