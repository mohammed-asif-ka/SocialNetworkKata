using SocialNetworkKata.Core.Model;
using SocialNetworkKata.Core.Repository;
using SocialNetworkKata.Core.Repository.Interface;
using SocialNetworkKata.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Service
{
    public class PostService: IPostService
    {
        private readonly IPostRepository _repo;
        public PostService(IPostRepository repo)
        {
            _repo = repo;
        }
        public User Post(string userName, string content)
        {
            return _repo.Post(new User(userName), new Post(content, DateTime.Now));
        }
        public User MentionPost(string userName, string content, string mentionedBy)
        {
            return _repo.Post(new User(userName), new Post(content, DateTime.Now, mentionedBy));
        }
        public void SendMessage(string sender, string reciever, string message)
        {
            _repo.SendMessage(new User(reciever), new Message(sender, reciever, message, DateTime.Now));
        }
    }
}
