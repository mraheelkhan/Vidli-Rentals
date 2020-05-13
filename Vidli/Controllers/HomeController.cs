using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Vidli.Controllers
{
    [AllowAnonymous] // to allow not logged in users to whole controller functions
    public class HomeController : Controller
    {
        [OutputCache(Duration = 0,  VaryByParam = "genre", NoStore = true)]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous] // to allow not logged in users to a single function.
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}