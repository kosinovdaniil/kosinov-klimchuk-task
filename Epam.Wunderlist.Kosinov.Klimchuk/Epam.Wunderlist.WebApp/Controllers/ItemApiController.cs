using System.Linq;
using System.Net.Http;
using System.Web.Http;
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
            return CreateResponseBuilder().WithMethod(() => _listService.GetByUser(id))
                .WithCondition(() => CurrentUserId == id);
        }

        [Route("lists/{id:int}")]
        public HttpResponseMessage GetList(int id)
        {
            var list = _listService.Get(id);
            return CreateResponseBuilder().WithMethod(() => list)
               .WithCondition(() => list.Users.Select(x => x.Id).Contains(CurrentUserId));
        }

        [Route("lists/{id:int}/items")]
        public HttpResponseMessage GetItems(int id)
        {
            var list = _listService.Get(id);
            return CreateResponseBuilder().WithMethod(() => _itemService.GetByList(id))
                  .WithCondition(() => list.Users.Select(x => x.Id).Contains(CurrentUserId));
        }

        [Route("items/{id:int}")]
        public HttpResponseMessage GetItem(int id)
        {
            var item = _itemService.Get(id);
            return CreateResponseBuilder().WithMethod(() => item)
                .WithCondition(() => item.UsersId.Contains(CurrentUserId));
        }

        #endregion

        #region Post

        [Route("lists/")]
        public HttpResponseMessage PostList(ToDoList list)
        {
            return CreateResponseBuilder().WithMethod(() => _listService.Create(list));
        }
        [Route("lists/{id:int}/items/")]
        public HttpResponseMessage PostItem(int id, ToDoItem item)
        {
            item.List = _listService.Get(id);
            return CreateResponseBuilder().WithMethod(() => _itemService.Create(item))
              .WithCondition(() => _listService.Get(id).Users.Select(x => x.Id).Contains(CurrentUserId));
        }

        #endregion

        #region Put
        [Route("items/")]
        [HttpPut]
        public HttpResponseMessage UpdateItem(ToDoItem item)
        {
            return CreateResponseBuilder().WithCondition(() => item.UsersId.Contains(CurrentUserId))
                .WithMethod(() => _itemService.Update(item));
        }

        [Route("lists/")]
        [HttpPut]
        public HttpResponseMessage UpdateList(ToDoList list)
        {
            return CreateResponseBuilder().WithCondition(() => list.Users.Select(x => x.Id).Contains(CurrentUserId))
                .WithMethod(() => _listService.Update(list));
        }

        #endregion

        #region Delete

        [Route("lists/{id:int}")]
        [HttpDelete]
        public HttpResponseMessage DeleteList(int id)
        {
            var list = _listService.Get(id);
            return CreateResponseBuilder().WithCondition(() => list.Users.Select(x => x.Id).Contains(CurrentUserId))
                .WithMethod(() => _listService.Delete(list));
        }

        [Route("items/{id:int}")]
        [HttpDelete]
        public HttpResponseMessage DeleteItem(int id)
        {
            var item = _itemService.Get(id);
            return CreateResponseBuilder().WithCondition(() => item.UsersId.Contains(CurrentUserId))
                .WithMethod(() => _itemService.Delete(item));
        }

        #endregion

        #region Private methods

        private int CurrentUserId
        {
            get
            {
                return this.GetCurrentUserId();
            }
        }

        private HttpResponseBuilder CreateResponseBuilder()
        {
            return this.CreateResponseBuilder();
        }

        #endregion

    }
}
