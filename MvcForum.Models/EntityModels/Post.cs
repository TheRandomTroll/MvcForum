using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForum.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Post
    {
        public Post()
        {
            this.Comments = new List<Comment>();
        }
        public int Id { get; set; }

        [Required]
        public string Topic { get; set; }
        [Required]

        public string Content { get; set; }

        [MinLength(11)]
        [MaxLength(11)]
        public string YoutubeUrl { get; set; }

        [Required]

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
