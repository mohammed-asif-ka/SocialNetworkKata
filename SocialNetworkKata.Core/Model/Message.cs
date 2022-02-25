using SocialNetworkKata.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Model
{
    public class Message
    {
        public Message(string sender, string reciever, string message, DateTime timeSatamp)
        {
            SenderName = sender;
            RecieverName = reciever;
            DirectMessage = message;
            TimeStamp = timeSatamp;
        }
        public string DirectMessage { get; set; }
        public DateTime TimeStamp { get; set; }
        public string SenderName { get; set; }
        public string RecieverName { get; set; }
        public string PrettyPrint
            => $"{SenderName} send : {DirectMessage} ({TimeFormatter.PrettyPrint(TimeStamp)})";
    }
}
