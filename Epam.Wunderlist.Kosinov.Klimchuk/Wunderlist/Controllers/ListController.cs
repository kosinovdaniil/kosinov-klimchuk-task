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
    public class ListController : Controller
    {
        private readonly IUserService _userService;

        public ListController(IUserService userService)
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
