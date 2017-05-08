using Microsoft.AspNet.SignalR;

namespace MvcForum.App.Areas.Chat.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            this.Clients.All.addNewMessageToPage(name, message);
        }
    }

}
