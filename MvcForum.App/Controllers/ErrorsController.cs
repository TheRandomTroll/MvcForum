using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcForum.App.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult Banned()
        {
            return View();
        }
    }
}