namespace MvcForum.App.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper;

    using MvcForum.App.Areas.Admin.Services;
    using MvcForum.Data;
    using MvcForum.Models.BindingModels;
    using MvcForum.Models.EntityModels;

    public class CommentsController : Controller
    {
        private readonly MvcForumContext db = new MvcForumContext();
        private LogService service = new LogService();

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
            CommentBM comment = new CommentBM
                                    {
                                        PostId = post.Id
                                    };
            return this.View(comment);
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
                this.service.AddLog("Wrote a comment", User.Identity.Name);
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
            int postId = comment.PostId;
            this.db.Comments.Remove(comment);
            this.service.AddLog("Deleted a comment", User.Identity.Name);

            this.db.SaveChanges();

            return this.RedirectToAction("Details", "Posts", new {@id = postId});
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comment = this.db.Comments.Find(id);
            var commentBm = Mapper.Map<Comment, CommentBM>(comment);
            if (comment == null)
            {
                return this.HttpNotFound();
            }

            return this.View(commentBm);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Content,PostId")] Comment comment)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Entry(comment).CurrentValues["Content"] = comment.Content;
                this.service.AddLog("Editted a comment", User.Identity.Name);

                this.db.SaveChanges();
                return this.RedirectToAction("Details", "Posts", new {@id = comment.PostId});
            }
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