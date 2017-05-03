using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForum.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using MvcForum.Models.EntityModels;

    public class MvcForumContext : IdentityDbContext<User>
    {
        public MvcForumContext()
            : base("MvcForum", throwIfV1Schema: false)
        {
        }

        public static MvcForumContext Create()
        {
            return new MvcForumContext();
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}
