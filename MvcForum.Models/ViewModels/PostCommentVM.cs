using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForum.Models.ViewModels
{
    using MvcForum.Models.EntityModels;

    public class PostCommentVM
    {
        public Post Post { get; set; }

        public Comment Comment { get; set; }
    }
}
