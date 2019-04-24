using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/Admin");
        }

        public ActionResult Info()
        {
            ViewBag.Title = "Home Page";

            ViewBag.ServerInfo = ServerInfo.GetHtml().ToHtmlString();

            return View("Info");
        }
    }
}
