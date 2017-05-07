namespace MvcForum.App
{
    using System.Web.Mvc;

    using MvcForum.App.Attributes;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}