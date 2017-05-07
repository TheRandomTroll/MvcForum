namespace MvcForum.App.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using MvcForum.App.Areas.Admin.Services;
    using MvcForum.Data;
    using MvcForum.Models.BindingModels;
    using MvcForum.Models.EntityModels;

    public class PostsController : Controller
    {
        private readonly MvcForumContext db = new MvcForumContext();

        private readonly LogService logService = new LogService();

        // GET: Posts/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Topic,Content,Category")] NewPostBM postBm)
        {
            if (this.ModelState.IsValid)
            {
                Category cat = this.db.Categories.First(x => x.Name == postBm.Category);
                Post post = new Post
                                {
                                    Topic = postBm.Topic,
                                    Content = postBm.Content,
                                    CreatedOn = DateTime.Now,
                                    Author = this.db.Users.First(x => x.UserName == this.User.Identity.Name),
                                    Category = cat
                                };
                this.db.Posts.Add(post);
                this.db.SaveChanges();
                this.logService.AddLog("Wrote a post", this.User.Identity.Name);
                return this.RedirectToAction("Category", "Forum", new { id = cat.Id });
            }

            return this.View();
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Post post = this.db.Posts.Find(id);
            if (post == null)
            {
                return this.HttpNotFound();
            }

            return this.View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = this.db.Posts.Find(id);
            var catId = post.Category.Id;
            this.db.Posts.Remove(post);
            this.db.SaveChanges();
            this.logService.AddLog("Deleted a post", this.User.Identity.Name);
            return this.RedirectToAction("Category", "Forum", new { id = catId });
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Post post = this.db.Posts.Find(id);
            if (post == null)
            {
                return this.HttpNotFound();
            }

            return this.View(post);
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