using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForum.Models.EntityModels.Admin
{
    public class Log
    {
        public int Id { get; set; }

        public string Action { get; set; }

        public string Username { get; set; }

        public DateTime LoggedAt { get; set; }
    }
}
