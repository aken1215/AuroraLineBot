using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuroraLineAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return File(Server.MapPath("~/dist/") + "index.html", "text/html");
        }
    }
}
