using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForum.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Post
    {
        public Post()
        {
            this.Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public virtual User Author { get; set; }
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
