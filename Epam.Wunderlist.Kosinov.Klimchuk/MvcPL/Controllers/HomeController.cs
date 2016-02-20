using BLL.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;
using BLL.Interface.Entities;

namespace MvcPL.Controllers
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
            return View(_userService.GetAll().Select(x=>x.ToUserViewModel()));
        }
    }
}
