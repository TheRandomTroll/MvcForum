using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcForum.Data;
using MvcForum.Models.EntityModels;

namespace MvcForum.App.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    using MvcForum.Models.BindingModels;
    using MvcForum.Models.ViewModels;

    [RoutePrefix("")]
    public class ForumController : Controller
    {
        private UserManager _userManager;
        private MvcForumContext db = new MvcForumContext();
        public UserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            List<Category> vms = this.db.Categories.ToList();
            return this.View(vms);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")]CategoryBM category)
        {
            if (this.User.IsInRole("Administrator"))
            {
                if (ModelState.IsValid)
                {
                    db.Categories.Add(Mapper.Map<CategoryBM, Category>(category));
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
        }
        public ActionResult Category(int id)
        {
            var posts = this.db.Posts.Where(x => x.Category.Id == id);
            return this.View(posts);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
