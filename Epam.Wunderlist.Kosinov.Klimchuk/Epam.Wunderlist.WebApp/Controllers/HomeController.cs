using Epam.Wunderlist.Services.Interfaces;
using System.Linq;
using System.Web.Mvc;

namespace Epam.Wunderlist.WebApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
    }
}
