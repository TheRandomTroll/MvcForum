using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForum.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public virtual User Author { get; set; }

        public virtual Post Post { get; set; }
        
        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
    }
}
