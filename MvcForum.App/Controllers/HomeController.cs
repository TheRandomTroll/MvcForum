using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcForum.App.Controllers
{
    using MvcForum.Data;

    public class HomeController : Controller
    {
        private MvcForumContext db = new MvcForumContext();
        // GET: Home
        public ActionResult Index()
        {
            var posts = this.db.Posts.OrderByDescending(x => x.CreatedOn).Take(3).ToList();
            return View(posts);
        }
    }
}