using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForum.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using MvcForum.Models.EntityModels;

    public class NewPostBM
    {
        [Required]

        public string Topic { get; set; }
        [Required]

        public string Content { get; set; }
        [Required]

        public string Category { get; set; }

        public string YoutubeUrl { get; set; }
    }
}
