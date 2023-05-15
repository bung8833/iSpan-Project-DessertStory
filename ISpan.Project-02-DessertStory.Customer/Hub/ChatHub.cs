using Microsoft.AspNetCore.SignalR;
using System.Configuration;
using System.Threading.Tasks;

namespace ISpan.Project_02_DessertStory.Customer.Hubs
{
    public class ChatHub:Hub
    {
        private static List<(string Username, string Message, DateTime Timestamp)> ChatHistory = new List<(string, string, DateTime)>();
        private static Timer CleanupTimer;

        static ChatHub()
        {
            // 初始化清理定時器，將在每個小時清理過期訊息
            CleanupTimer = new Timer(CleanupExpiredMessages, null, TimeSpan.FromHours(1), TimeSpan.FromHours(1));
        }

        private static void CleanupExpiredMessages(object state)
        {
            var now = DateTime.UtcNow;
            lock (ChatHistory)
            {
                ChatHistory.RemoveAll(x => now - x.Timestamp > TimeSpan.FromHours(1));
            }
        }
        public async Task SendMessage(string username, string message)
        {
            var timestamp = DateTime.UtcNow;
            lock (ChatHistory)
            {
                ChatHistory.Add((username, message, timestamp));
            }

            await Clients.All.SendAsync("ReceiveMessage", username, message, timestamp);
        }


        public async Task GetChatHistory()
        {
            List<(string, string, DateTime)> chatHistoryCopy;
            lock (ChatHistory)
            {
                chatHistoryCopy = ChatHistory.ToList();
            }
            await Clients.Caller.SendAsync("ReceiveChatHistory", chatHistoryCopy);
        }
    }
}
