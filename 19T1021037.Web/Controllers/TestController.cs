using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19T1021037.Web.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        public string SayHello(string id)
        {
            return $"{id}";
        }
    }
}