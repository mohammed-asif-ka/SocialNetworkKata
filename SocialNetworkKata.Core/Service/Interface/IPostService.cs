using SocialNetworkKata.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Service.Interface
{
    public interface IPostService
    {
        public User Post(string userName, string content);
        public User MentionPost(string userName, string content, string mentionedBy);
        public void SendMessage(string sender, string reciever, string message);


    }
}
