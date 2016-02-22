using BLL.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wunderlist.Infrastructure.Mappers;
using Wunderlist.ViewModels;
using BLL.Interface.Entities;

namespace Wunderlist.Controllers
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
            var users = _userService.GetAll().Select(x => x.ToUserViewModel()).ToList();
            //return View();
            return View(users);
        }
    }
}
