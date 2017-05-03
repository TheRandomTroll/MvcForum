using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForum.Models.ViewModels
{
    using MvcForum.Models.EntityModels;

    public class PostVM
    {
        public string Topic { get; set; }
        public string Content { get; set; }
        public virtual Category Category { get; set; }

        public virtual User Author { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
