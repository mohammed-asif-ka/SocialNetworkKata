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
    public class FollowService: IFollowService
    {
        private readonly IFollowRepository _repo;
        public FollowService(IFollowRepository repo)
        {
            _repo = repo;
        }
        public User Subscribe(string followerUserName, string followedUserName)
        {
            return _repo.Subscribe(followerUserName, followedUserName);
        }
    }
}
