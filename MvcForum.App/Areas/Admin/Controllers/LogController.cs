namespace MvcForum.App.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using MvcForum.App.Areas.Admin.Services;
    using MvcForum.App.Attributes;

    using PagedList;

    [AdminOnly]
    public class LogController : Controller
    {
        readonly LogService service = new LogService();

        // GET: Admin/Log
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            var logs = this.service.GetLogs().ToPagedList(pageNumber, pageSize);
            return this.View(logs);
        }
    }
}