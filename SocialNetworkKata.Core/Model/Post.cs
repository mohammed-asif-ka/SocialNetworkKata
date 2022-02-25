using SocialNetworkKata.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Model
{
    public class Post
    {
        public Post()
        {
        }
        public Post(string message, DateTime timeStamp)
        {
            Content = message;
            TimeStamp = timeStamp;
        }
        public Post(string message, DateTime timeStamp,string mentionedBy)
        {
            Content = message;
            TimeStamp = timeStamp;
            MentionedBy = mentionedBy;
        }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? MentionedBy { get; set; }
        public string PrettyPrint
            => $"{Content} ({TimeFormatter.PrettyPrint(TimeStamp)})";
    }
}
