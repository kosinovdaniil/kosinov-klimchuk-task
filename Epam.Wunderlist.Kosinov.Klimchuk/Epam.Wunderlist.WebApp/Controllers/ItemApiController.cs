
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.DomainModel;
using System.Net;

namespace Epam.Wunderlist.WebApp.Controllers
{
    [RoutePrefix("WebApp/api")]
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
            return CreateGetResponseBuilder().WithMethod(() => _listService.GetByUser(id))
                .WithCondition(() => CurrentUserId == id);
        }

        [Route("lists/{id:int}")]
        public HttpResponseMessage GetList(int id)
        {
            var list = _listService.Get(id);
            return CreateGetResponseBuilder().WithMethod(() => list)
               .WithCondition(() => list.Users.Select(x => x.Id).Contains(CurrentUserId));
        }

        [Route("lists/{id:int}/items")]
        public HttpResponseMessage GetItems(int id)
        {
            var list = _listService.Get(id);
            return CreateGetResponseBuilder().WithMethod(() => _itemService.GetByList(id))
                  .WithCondition(() => list.Users.Select(x => x.Id).Contains(CurrentUserId));
        }

        [Route("items/{id:int}")]
        public HttpResponseMessage GetItem(int id)
        {
            var item = _itemService.Get(id);
            return CreateGetResponseBuilder().WithMethod(() => item)
                .WithCondition(() => item.UsersId.Contains(CurrentUserId));
        }

        #endregion
        #region Post

        [Route("lists/")]
        public HttpResponseMessage PostList(ToDoList list)
        {
            var responseBuilder = CreatePostResponseBuilder(_listService);
            return responseBuilder.WithEntity(list);
        }
        [Route("lists/{id:int}/items/")]
        public HttpResponseMessage PostItem(int id, ToDoItem item)
        {
            var responseBuilder = CreatePostResponseBuilder(_itemService);
            return responseBuilder.WithEntity(item)
                .WithCondition(() => _listService.Get(id).Users.Select(x => x.Id).Contains(CurrentUserId));
        }

        [Route("lists/{id:int}/delete")]
        [HttpPost]
        public HttpResponseMessage DeleteList(int id)
        {
            HttpResponseMessage response;
            if (User.Identity.IsAuthenticated)
            {
                var list = _listService.Get(id);
                if (list.Users.Select(x => x.Id).Contains(CurrentUserId))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, "");
                    _listService.Delete(list);
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

        [Route("items/{id:int}/delete")]
        [HttpPost]
        public HttpResponseMessage DeleteItem(int id)
        {
            HttpResponseMessage response;
            if (User.Identity.IsAuthenticated)
            {
                var item = _itemService.Get(id);
                if (item.UsersId.Contains(CurrentUserId))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, "");
                    _itemService.Delete(item);
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

        private HttpPostResponseBuilder<TEntity> CreatePostResponseBuilder<TEntity>(ICrudService<TEntity> service)
            where TEntity : Entity
        {

            return new HttpPostResponseBuilder<TEntity>(User.Identity, Request, service);

        }

    }
}
