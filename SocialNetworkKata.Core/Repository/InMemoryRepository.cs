using SocialNetworkKata.Core.Model;
using SocialNetworkKata.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Repository
{
    public class InMemoryRepository: IInMemoryRepository
    {
        private List<User> _users = new List<User>();
        public InMemoryRepository()
        {

        }

        public void Add(User user)
        {
            _users.Add(user);   
        }
        public User? Get(User user)
        {
            return _users.FirstOrDefault<User>(x => x.UserName.ToLower() == user.UserName.ToLower());
        }
        public void AddPostOnly(User user, Post post)
        {
            _users.FirstOrDefault<User>(x=> x.UserName.ToLower() == user.UserName.ToLower()).Posts.Add(post);
        }
        public User? GetUserByName(string userName) => _users.FirstOrDefault(x => x.UserName.ToLower() == userName.ToLower());
        public User? Subscribe(User follower, string followed)
        {
            var followerList = follower.Following?.Count>0 ? follower.Following : new List<string>();
            if (!followerList.Contains(followed,StringComparer.InvariantCultureIgnoreCase))
            {
                followerList.Add(followed);
                follower.Following = followerList;
            }
            return follower;
        }
        public void AddMessageOnly(User user, Message message)
        {
            //_users?.FirstOrDefault<User>(x => x.UserName.ToLower() == user.UserName.ToLower()).Messages = new List<Message>();
            _users?.FirstOrDefault<User>(x => x.UserName.ToLower() == user.UserName.ToLower()).Messages.Add(message);
        }
    }
}
