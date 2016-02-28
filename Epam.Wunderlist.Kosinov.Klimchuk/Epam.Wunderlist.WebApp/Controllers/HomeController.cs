using Epam.Wunderlist.Services.Interfaces;
using System.Linq;
using System.Web.Mvc;

namespace Epam.Wunderlist.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var users = _userService.GetAll();
            //return View();
            return View();
        }
    }
}
