using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcForum.App.Areas.Admin.Controllers
{
    using MvcForum.App.Attributes;

    [AdminOnly]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}