using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.Wunderlist.WebApp.Controllers
{
    public class WebAppController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}