using BLL.Interface.Services;
using BLL.Interfacies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Script.Serialization;
using Wunderlist.ViewModels;

namespace Wunderlist.Controllers
{
    //TODO add authorization and http response
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

        private string Serialize(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }
        [Route("users")]
        public string Get()
        {
            return Serialize(_userService.GetAll());
        }
        [Route("users/{id:int}")]
        public string Get(int id)
        {
            return Serialize(_userService.Get(id));
        }

        [Route("users")]
        public string Get(string email)
        {
            return Serialize(_userService.Get(email));
        }

        [Route("{id:int}/lists")]
        public string GetLists(int id)
        {
            //var lists = _listService.GetByUser(id)
            //return Serialize(lists);
            throw new NotImplementedException();
        }
        [Route("lists/{id:int}")]
        public string GetList(int id)
        {
            return Serialize(_listService.Get(id));
        }
        [Route("lists/{id:int}/items")]
        public string GetItems(int id)
        {
            //var items = _listService.GetByList(id)
            //return Serialize(items);
            throw new NotImplementedException();
        }
        [Route("items/{id:int}")]
        public string GetItem(int id)
        {
            return Serialize(_listService.Get(id));
        }
        [Route("items/{id:int}/subitems")]
        public string GetSubItems(int id)
        {

            //return Serialize(_subItemService.GetByItem(id));
            throw new NotImplementedException();
        }
        [Route("subitems/{id:int}")]
        public string GetSubItem(int id)
        {
            return Serialize(_subItemService.Get(id));
        }
        [Route("items/{id:int}/files")]
        public string GetFiles(int id)
        {
            //return Serialize(_subItemService.GetByItem(id));
            throw new NotImplementedException();
        }
        [Route("files/{id:int}")]
        public string GetFile(int id)
        {
            return Serialize(_fileService.Get(id));
        }

    }
}
