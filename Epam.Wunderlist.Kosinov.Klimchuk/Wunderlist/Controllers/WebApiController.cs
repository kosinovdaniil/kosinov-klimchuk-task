using BLL.Interface.Services;
using BLL.Interfacies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Script.Serialization;
using Wunderlist.ViewModels;

namespace Wunderlist.Controllers
{
    [RoutePrefix("api")]
    public class WebApiController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IFileService _fileService;
        private readonly IToDoItemService _itemService;
        private readonly ISubItemService _subItemService;
        private readonly IToDoListService _listService;

        public WebApiController(IUserService userService, IFileService fileService, IToDoItemService itemService, ISubItemService subItemService, IToDoListService listService)
        {
            _userService = userService;
            _fileService = fileService;
            _itemService = itemService;
            _subItemService = subItemService;
            _listService = listService;
        }

        [Route("users")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            if (User.Identity.IsAuthenticated)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Unauthorized");
            response.Content = new StringContent(Serialize(_userService.GetAll()), Encoding.Unicode);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.Unauthorized, "");
            }
            return response;
        }

        [Route("users/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response;
            if (User.Identity.IsAuthenticated)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "");
                response.Content = new StringContent(Serialize(_userService.Get(id)), Encoding.Unicode);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized");
            }
            return response;
        }

        [Route("users")]
        public HttpResponseMessage Get(string email)
        {
            HttpResponseMessage response;
            if (User.Identity.IsAuthenticated)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "");
                response.Content = new StringContent(Serialize(_userService.Get(email)), Encoding.Unicode);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized");
            }
            return response;
        }

        [Route("{id:int}/lists")]
        public HttpResponseMessage GetLists(int id)
        {
            HttpResponseMessage response;
            
            if (User.Identity.IsAuthenticated)
            {
                if (CurrentUserId == id)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, "");
                    response.Content = new StringContent(Serialize(_listService.GetByUser(id)), Encoding.Unicode);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.Forbidden, "Forbidden");
                }
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized");
            }
            var lists = _listService.GetByUser(id);
            return response;
        }

        [Route("lists/{id:int}")]
        public HttpResponseMessage GetList(int id)
        {
            HttpResponseMessage response;
            var list = _listService.Get(id);

            if (User.Identity.IsAuthenticated)
            {
                if (list.UsersId.Contains(CurrentUserId))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, "");
                    response.Content = new StringContent(Serialize(list), Encoding.Unicode);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.Forbidden, "Forbidden");
                }
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized");
            }
            return response;
        }

        [Route("lists/{id:int}/items")]
        public HttpResponseMessage GetItems(int id)
        {
            HttpResponseMessage response;
            var list = _listService.Get(id);

            if (User.Identity.IsAuthenticated)
            {
                if (list.UsersId.Contains(CurrentUserId))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, "");
                    //response.Content = new StringContent(Serialize(_itemService.GetByList(list.Id), Encoding.Unicode);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.Forbidden, "Forbidden");
                }
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized");
            }
            return response;
        }

        [Route("items/{id:int}")]
        public HttpResponseMessage GetItem(int id)
        {
            HttpResponseMessage response;
            //this looks stupid
            var item = _itemService.Get(id);
            var list = _listService.Get(item.Id);

            if (User.Identity.IsAuthenticated)
            {
                if (list.UsersId.Contains(CurrentUserId))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, "");
                    response.Content = new StringContent(Serialize(item), Encoding.Unicode);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.Forbidden, "Forbidden");
                }
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized");
            }
            return response;
        }

        [Route("items/{id:int}/subitems")]
        public string GetSubItems(int id)
        {
            return Serialize(_subItemService.GetSubItems(id));
        }

        [Route("subitems/{id:int}")]
        public string GetSubItem(int id)
        {
            return Serialize(_subItemService.Get(id));
        }

        [Route("items/{id:int}/files")]
        public string GetFiles(int id)
        {
            return Serialize(_fileService.GetByItem(id));
        }

        [Route("files/{id:int}")]
        public string GetFile(int id)
        {
            return Serialize(_fileService.Get(id));
        }

        private string Serialize(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }

        private int CurrentUserId
        {
            get
            {
                return Int32.Parse(((ClaimsIdentity)User.Identity).Claims
                            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            }
        }
    }
}
