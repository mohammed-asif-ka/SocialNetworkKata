using SocialNetworkKata.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Repository.Interface
{
    public interface IFollowRepository
    {
        public User Subscribe(string follower, string followed);

    }
}
