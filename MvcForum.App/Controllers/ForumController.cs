namespace MvcForum.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;

    using Microsoft.AspNet.Identity.Owin;

    using MvcForum.App.Attributes;
    using MvcForum.Data;
    using MvcForum.Models.BindingModels;
    using MvcForum.Models.EntityModels;

    using PagedList;
    
    public class ForumController : Controller
    {
        private UserManager _userManager;

        private readonly MvcForumContext db = new MvcForumContext();

        public UserManager UserManager
        {
            get
            {
                return this._userManager ?? this.HttpContext.GetOwinContext().GetUserManager<UserManager>();
            }

            private set
            {
                this._userManager = value;
            }
        }

        [Route("/Forum/Category/{id:int}?page={page:int?}")]
        public ActionResult Category(int id, int? page)
        {
            var posts = this.db.Posts.Where(x => x.Category.Id == id).ToList();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            return this.View(posts.ToPagedList(pageNumber, pageSize));
        }

        [AdminOnly]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] CategoryBM category)
        {
                if (this.ModelState.IsValid)
                {
                    this.db.Categories.Add(Mapper.Map<CategoryBM, Category>(category));
                    this.db.SaveChanges();
                    return this.RedirectToAction("Index");
                }

            return this.View();
        }

        public ActionResult Index()
        {
            List<Category> vms = this.db.Categories.ToList();
            return this.View(vms);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}