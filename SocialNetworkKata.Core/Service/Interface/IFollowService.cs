using SocialNetworkKata.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Service.Interface
{
    public interface IFollowService
    {
        public User Subscribe(string followerUserName, string followedUserName);
        
    }
}
