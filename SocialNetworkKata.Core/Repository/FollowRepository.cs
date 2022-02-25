using SocialNetworkKata.Core.Model;
using SocialNetworkKata.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Repository
{
    public class FollowRepository : IFollowRepository
    {
        private readonly IInMemoryRepository _inMemory;
        public FollowRepository(IInMemoryRepository inMemory)
        {
            _inMemory = inMemory;
        }

        public User Subscribe(string follower, string followed)
        {
            var matchedUser = _inMemory.GetUserByName(follower);
            if (matchedUser == null)
            {
                matchedUser = new User(follower);
                _inMemory.Add(matchedUser);
            }
            var user = _inMemory.Subscribe(matchedUser, followed);
                
            return user;
        }

        public User GetPosts(User user)
        {
            return _inMemory.Get(user);
        }
    }
}
