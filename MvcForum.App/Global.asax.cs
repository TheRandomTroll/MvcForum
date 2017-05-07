namespace MvcForum.App
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using AutoMapper;

    using MvcForum.Models.BindingModels;
    using MvcForum.Models.EntityModels;
    using MvcForum.Models.ViewModels;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(
                config =>
                    {
                        config.CreateMap<Category, CategoryVM>();
                        config.CreateMap<CategoryBM, Category>();
                        config.CreateMap<Post, PostVM>();
                        config.CreateMap<NewPostBM, Post>();
                        config.CreateMap<CommentBM, Comment>();
                    });
        }
    }
}