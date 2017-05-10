using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcForum.App.Areas.Admin.Controllers
{
    using MvcForum.App.Attributes;
    using MvcForum.Data;

    using PagedList;

    [AdminOnly]
    public class BanController : Controller
    {

        private MvcForumContext db = new MvcForumContext();
        // GET: Admin/Ban
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = page ?? 1;
            var users = db.Users.ToList().ToPagedList(pageNumber, pageSize);
            return this.View(users);
        }

        public ActionResult Ban(string id)
        {
            var user = db.Users.Find(id);
            user.Banned = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Unban(string id)
        {
            var user = db.Users.Find(id);
            user.Banned = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}