using System.Web.Mvc;

namespace MvcForum.App.Areas.Chat
{
    public class ChatAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Chat";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Chat_default",
                "Chat/{controller}/{action}/{id}",
                new { controller = "Chat", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}