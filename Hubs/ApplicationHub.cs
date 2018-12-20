using System.Threading.Tasks;
using DojoInfoCenter.Models;
using Microsoft.AspNetCore.SignalR;

namespace DojoInfoCenter
{
    public class ApplicationHub : Hub
    {
        public Task send(MessageObject message)
        {
            return Clients.All.SendAsync("Send", message.MessageTxt);
        }
    }
}