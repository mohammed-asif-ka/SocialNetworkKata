using SocialNetworkKata.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Service.Interface
{
    public interface IReadingService
    {
        public IList<string> GetTimeLinePosts(string userName);
        public IList<string> GetAllPosts(string userName);
        public IList<string> GetAllMessages(string userName);
    }
}
