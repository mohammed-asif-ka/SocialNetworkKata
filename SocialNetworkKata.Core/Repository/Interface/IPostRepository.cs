using SocialNetworkKata.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Repository.Interface
{
    public interface IPostRepository
    {
        public User Post(User user, Post post);
        public User GetPosts(User user);
        public void SendMessage(User reciever, Message message);

    }
}
