using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersimosMVC.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dasboard
        public ActionResult Index()
        {
            return View();
        }
    }
}