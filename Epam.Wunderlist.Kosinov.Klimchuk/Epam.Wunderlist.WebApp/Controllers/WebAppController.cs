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

        public ActionResult RedirectIndex()
        {
            return RedirectToAction("Index");
        }
    }
}