
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
using Epam.Wunderlist.DomainModel;

namespace Epam.Wunderlist.WebApp.Controllers
{
    [RoutePrefix("api")]
    public class ItemApiController : ApiController
    {
        private readonly IToDoListService _listService;
        private readonly IToDoItemService _itemService;

        public ItemApiController(IToDoListService listService, IToDoItemService itemService)
        {
            _listService = listService;
            _itemService = itemService;
        }
        #region Get

        [Route("users/{id:int}/lists")]
        public HttpResponseMessage GetLists(int id)
        {
            return GetResponseBuilder().WithMethod(() => _listService.GetByUser(id))
                .WithCondition(() => CurrentUserId == id);
        }

        [Route("lists/{id:int}")]
        public HttpResponseMessage GetList(int id)
        {
            var list = _listService.Get(id);
            return GetResponseBuilder().WithMethod(() => list)
               .WithCondition(() => list.UsersId.Contains(CurrentUserId));
        }

        [Route("lists/{id:int}/items")]
        public HttpResponseMessage GetItems(int id)
        {
            var list = _listService.Get(id);
            return GetResponseBuilder().WithMethod(() => _itemService.GetByList(id))
                  .WithCondition(() => list.UsersId.Contains(CurrentUserId));
        }

        [Route("items/{id:int}")]
        public HttpResponseMessage GetItem(int id)
        {
            var item = _itemService.Get(id);
            return GetResponseBuilder().WithMethod(() => item);
            // .WithCondition(() => item.UsersId.Contains(CurrentUserId));
        }

        #endregion
        #region Post

        [Route("lists/")]
        public HttpResponseMessage PostList(ToDoList list)
        {
            var responseBuilder = CreatePostResponseBuilder<ToDoList>();
            return responseBuilder.WithEntity(list);
        }
        [Route("lists/{id:int}/items/")]
        public HttpResponseMessage PostItem(int id, ToDoItem item)
        {
            var responseBuilder = CreatePostResponseBuilder<ToDoItem>();
            return responseBuilder.WithEntity(item)
                .WithCondition(() => _listService.Get(id).UsersId.Contains(CurrentUserId));
        }

        #endregion


        private int CurrentUserId
        {
            get
            {
                return Int32.Parse(((ClaimsIdentity)User.Identity).Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            }
        }

        private HttpGetResponseBuilder CreateGetResponseBuilder()
        {
            return new HttpGetResponseBuilder(User.Identity, Request);
        }
        private HttpPostResponseBuilder<TEntity> CreatePostResponseBuilder<TEntity>()
        {
            return new HttpPostResponseBuilder<TEntity>(User.Identity, Request,); //TODO NINJECT SERVICE
        }

    }
}
