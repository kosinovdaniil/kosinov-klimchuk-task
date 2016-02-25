﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.DomainModel;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using System.Web;

namespace Epam.Wunderlist.Services.Services
{
    public class SignInService : ISignInService
    {
        public void IdentitySignin(User user, bool isPersistent = false)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = isPersistent,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            }, identity);
        }

        public void IdentitySignout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie,
                                          DefaultAuthenticationTypes.ExternalCookie);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContextExtensions.GetOwinContext(HttpContext.Current).Authentication;
            }
        }
    }
}