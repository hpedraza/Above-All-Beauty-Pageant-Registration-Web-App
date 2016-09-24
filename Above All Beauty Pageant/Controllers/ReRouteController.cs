using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Above_All_Beauty_Pageant.Controllers
{
    public class ReRouteController : Controller
    {
        // GET: ReRoute
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}