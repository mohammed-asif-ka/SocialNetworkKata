using SocialNetworkKata.Core.Model;
using SocialNetworkKata.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly IInMemoryRepository _inMemory;
        public PostRepository(IInMemoryRepository inMemory)
        {
            _inMemory = inMemory;
        }
        public User Post(User user, Post post)
        {
            var matched = _inMemory.Get(user);
            if (matched == null)
            {
                user.Posts.Add(post);
                _inMemory.Add(user);
            }
            else
            {
                _inMemory.AddPostOnly(user, post);
            }
            return matched;
        }

        public User GetPosts(User user)
        {
            return _inMemory.Get(user);
        }

        public void SendMessage(User reciever, Message message)
        {
            var matchedReciever = _inMemory.Get(reciever);
            if(matchedReciever == null)
            {
                reciever.Messages.Add(message);
                _inMemory.Add(reciever);
            }
            else
            {
                _inMemory.AddMessageOnly(matchedReciever, message);
            }
        }
    }
}
