using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.DomainModel;
namespace Epam.Wunderlist.WebApp.Controllers
{
    [RoutePrefix("api")]
    public class FileApiController : ApiController
    {

        private readonly IUserService _userService;

        public FileApiController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("image")]
        public HttpResponseMessage PostImage()
        {
            throw new NotImplementedException();
        }

        #region Private methods

        private int CurrentUserId
        {
            get
            {
                return ApiControllerExtensions.GetCurrentUserId(this);
            }
        }

        private HttpResponseBuilder CreateResponseBuilder()
        {
            return ApiControllerExtensions.CreateResponseBuilder(this);
        }

        #endregion
    }
}
