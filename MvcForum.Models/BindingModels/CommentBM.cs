﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForum.Models.BindingModels
{
    using MvcForum.Models.EntityModels;

    public class CommentBM
    {
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}
