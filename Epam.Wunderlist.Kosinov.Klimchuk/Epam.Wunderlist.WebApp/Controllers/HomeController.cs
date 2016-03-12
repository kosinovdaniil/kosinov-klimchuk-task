using Epam.Wunderlist.DomainModel;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Epam.Wunderlist.WebApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UploadFile()
        {
            string message = string.Empty, mimeType = string.Empty;

            var image = HttpContext.Request.Files[0];

            try
            {
                var path = Path.Combine(Server.MapPath("~/Files"), image.FileName);
                image.SaveAs(path);
                mimeType = image.ContentType;
                message = "File uploaded";
            }
            catch (Exception)
            {
                message = "File upload failed! Please try again";
            }
            return new JsonResult { Data = new { Message = message, MimeType = mimeType } };
        }
    }
}
