using SocialNetworkKata.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Repository.Interface
{
    public interface IInMemoryRepository
    {
        public void Add(User user);
        public User? Get(User user);
        //public void Add(User user, Post post)
        public void AddPostOnly(User user, Post post);
        public User? GetUserByName(string userName);
        public User? Subscribe(User follower, string followed);
        public void AddMessageOnly(User user, Message post);

    }
}
