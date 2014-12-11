using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dolphinfo.Controllers
{
    public class VersionController : ApiController
    {
        public string Get()
        {
            return ConfigurationManager.AppSettings["BuildIdentifier"];
        }
    }
}