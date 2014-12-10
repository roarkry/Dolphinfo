using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dolphinfo.Controllers
{
    public class HomeController : Controller
    {
        private static uint x = 0;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NextImage()
        {
            string dirPath = ConfigurationManager.AppSettings["SlideShowSrcDir"];
            string[] filePaths = Directory.GetFiles(dirPath);
            string path = string.Empty;

            path = filePaths[x % filePaths.Length];
            ++x;

            return base.File(path, "image/jpeg");
        }
    }
}
