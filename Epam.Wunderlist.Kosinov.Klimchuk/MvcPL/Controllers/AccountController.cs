using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;

namespace MvcPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISignInService _signService;

        public AccountController(IUserService userService, ISignInService signService)
        {
            _userService = userService;
            _signService = signService;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Register()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new BllUser()
                {
                    Name = model.Name,
                    Password = model.Password,
                    Email = model.Email
                };

                user = _userService.Create(user);
                if (user != null)
                {
                    _signService.IdentitySignin(user);
                    return RedirectToAction("Index", "Home",null);
                }

                ViewBag.Error = "This user already exists";
                return View("Register");
            }
            ViewBag.Error = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)); ;
            return View("Register");

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LogOn(UserLoginModel model)
        {
            BllUser user = _userService.ValidateUser(model.Email, model.Password);
            if (user != null)
            {
                _signService.IdentitySignin(user, model.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            TempData.Add("Error", "Wrong username or password");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            _signService.IdentitySignout();
            return RedirectToAction("Index", "Home",null);
        }
        [Authorize]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(int id)
        {
            var user = _userService.Get(id);
            return View(user.ToUserViewModel());
        }
        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(UserViewModel user)
        {
            _userService.Update(user.ToBllUser());
            if (!((ClaimsIdentity)User.Identity).Claims
                    .Any(x => x.Type == ClaimTypes.Role &&
                    x.Value == "Admin"))
            {
                _signService.IdentitySignout();
                _signService.IdentitySignin(user.ToBllUser());
            }
            return RedirectToAction("Index", "Home",null);
        }

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            BllUser user = _userService.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user.ToUserViewModel());
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(BllUser user)
        {
            _userService.Delete(user);
            return RedirectToAction("Index", "Home", null);
        }

    }
}