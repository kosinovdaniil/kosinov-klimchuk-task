using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Interfacies.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wunderlist.Infrastructure.Mappers;
using Wunderlist.ViewModels;

namespace Wunderlist.Controllers
{
    public class FileController : Controller
    {
        #region Fields
        private readonly IFileService _fileService;
        #endregion

        #region Constructor

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        #endregion   
        
        public ActionResult Index()
        {
            return View();
        }    

        //[HttpPost]
        //public ActionResult Upload(HttpPostedFileBase upl)
        //{
        //    var result = new List<FileViewModel>();

        //    foreach (string file in Request.Files)
        //    {
        //        var uploadFile = Request.Files[file];

        //        if (uploadFile == null)
        //            return new HttpStatusCodeResult(204, "File not found!");

        //        var bllFile = new BllFile {
        //            Name = Path.GetFileName(uploadFile.FileName),
        //            AddingDate = DateTime.Now
        //        };

        //        //using (var binaryReader = new BinaryReader(uploadFile.InputStream))
        //        //{
        //        //    bllFile.DataOfFile = binaryReader.ReadBytes(uploadFile.ContentLength);
        //        //}

        //        //bllFile.IsShared = false;
        //        //bllFile.UserId = userService.GetByLogin(HttpContext.User.Identity.Name).Id;

        //        try
        //        {
        //            _fileService.Create(bllFile);
        //        }
        //        //catch (ArgumentNullException e)
        //        //{
        //        //    return RedirectToAction("Index", "Error", new { id = "Параметр " + e.Message + " NULL" });
        //        //}
        //        catch
        //        {
        //            return RedirectToAction("Index", "Error", new { id = "Error! File's can't be save. Pleace, try again." });
        //        }

        //        result.Add(bllFile.ToFileViewModel());
        //    }
        //    return PartialView("_FilePartial", result);
        //}
    }
}