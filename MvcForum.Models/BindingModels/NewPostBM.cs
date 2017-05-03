using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForum.Models.BindingModels
{
    public class NewPostBM
    {
        public string Topic { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }
    }
}
