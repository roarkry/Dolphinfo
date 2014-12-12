using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dolphinfo.Controllers
{
    public class FilesController : ApiController
    {
        public IEnumerable<string> Get()
        {
            string dirPath = ConfigurationManager.AppSettings["SlideShowSrcDir"];
            string[] filePaths = Directory.GetFiles(dirPath);
            
            IEnumerable<string> fileNames = filePaths.Select(x => Path.GetFileName(x));
            
            return fileNames;
        }

        public HttpResponseMessage Get(string fileName)
        {
            string dirPath = ConfigurationManager.AppSettings["SlideShowSrcDir"];
            string[] filePaths = Directory.GetFiles(dirPath);

            string path = filePaths.FirstOrDefault(x => Path.GetFileName(x) == fileName);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return result;
        }
    }
}