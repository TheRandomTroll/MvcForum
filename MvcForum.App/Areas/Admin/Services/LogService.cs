namespace MvcForum.App.Areas.Admin.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MvcForum.Data;
    using MvcForum.Models.EntityModels.Admin;

    public class LogService
    {
        private readonly MvcForumContext db = new MvcForumContext();

        public void AddLog(string action, string username)
        {
            var log = new Log { Action = action, Username = username, LoggedAt = DateTime.UtcNow };
            this.db.Logs.Add(log);
            this.db.SaveChanges();
        }

        public IEnumerable<Log> GetLogs()
        {
            return this.db.Logs.ToList().OrderByDescending(x => x.LoggedAt);
        }
    }
}