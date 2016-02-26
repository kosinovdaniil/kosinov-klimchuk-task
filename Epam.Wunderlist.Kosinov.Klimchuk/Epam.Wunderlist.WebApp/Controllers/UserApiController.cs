using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Script.Serialization;
using Epam.Wunderlist.WebApp.ViewModels;
using Epam.Wunderlist.Services.Interfaces;

namespace Epam.Wunderlist.WebApp.Controllers
{
    [RoutePrefix("api")]
    public class UserApiController : ApiController
    {
        private readonly IUserService _userService;

        public UserApiController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("users")]
        public HttpResponseMessage Get()
        {
            return GetResponseBuilder().WithMethod(() => _userService.GetAll());
        }

        [Route("users/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            return GetResponseBuilder().WithMethod(() => _userService.Get(id));
        }

        [Route("users/")]
        public HttpResponseMessage Get(string email)
        {
            return GetResponseBuilder().WithMethod(() => _userService.Get(email));
        }

        private int CurrentUserId
        {
            get
            {
                return Int32.Parse(((ClaimsIdentity)User.Identity).Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            }
        }    

        private HttpGetResponseBuilder GetResponseBuilder()
        {
            return new HttpGetResponseBuilder(User.Identity, Request);
        }

    }
}
