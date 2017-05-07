namespace MvcForum.App.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using MvcForum.Data;
    using MvcForum.Models.BindingModels;
    using MvcForum.Models.EntityModels;

    public class CommentsController : Controller
    {
        private readonly MvcForumContext db = new MvcForumContext();

        public ActionResult Create(int? id)
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
            CommentBM comment = new CommentBM();
            return this.View(post);
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Content, PostId")] CommentBM commentBm)
        {
            if (this.ModelState.IsValid)
            {
                Post post = this.db.Posts.Find(commentBm.PostId);
                Comment comment = new Comment
                                      {
                                          Post = post,
                                          Author =
                                              this.db.Users.First(x => x.UserName == this.User.Identity.Name),
                                          Content = commentBm.Content,
                                          CreatedOn = DateTime.Now
                                      };
                this.db.Comments.Add(comment);
                this.db.SaveChanges();
                return this.RedirectToAction("Details", "Posts", new { id = commentBm.PostId });
            }

            return this.View(commentBm);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comment = this.db.Comments.Find(id);
            if (comment == null)
            {
                return this.HttpNotFound();
            }

            return this.View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = this.db.Comments.Find(id);
            this.db.Comments.Remove(comment);
            this.db.SaveChanges();

            return this.RedirectToAction("Index");
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comment = this.db.Comments.Find(id);
            if (comment == null)
            {
                return this.HttpNotFound();
            }

            return this.View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreatedOn,Content,AuthorId,PostId")] Comment comment)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Entry(comment).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            this.ViewBag.AuthorId = new SelectList(this.db.Users, "Id", "Email", comment.AuthorId);
            this.ViewBag.PostId = new SelectList(this.db.Posts, "Id", "Topic", comment.PostId);
            return this.View(comment);
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