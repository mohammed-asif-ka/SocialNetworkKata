using SocialNetworkKata.Core.Model;
using SocialNetworkKata.Core.Repository.Interface;
using SocialNetworkKata.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Service
{
    public class ReadingService:IReadingService
    {
        private readonly IPostRepository _repo;
        public ReadingService(IPostRepository repo)
        {
            _repo = repo;
        }
        public IList<string> GetTimeLinePosts(string userName)
        {
            var user = _repo.GetPosts(new User(userName));
            return user?.Posts.OrderByDescending(x => x.TimeStamp).Select(x => user.UserName + " - " + x.PrettyPrint).ToList();
        }
        public IList<string> GetAllPosts(string userName)
        {
            var user = _repo.GetPosts(new User(userName));
            var posts = user?.Posts.OrderByDescending(x=>x.TimeStamp).Select(x => (String.IsNullOrEmpty(x.MentionedBy)? user.UserName : x.MentionedBy) + " - " + x.PrettyPrint).ToList();
            if (user!= null && user.Following!=null)
            {
                foreach (var followedUser in user.Following)
                {
                    var followedUserDetail = _repo.GetPosts(new User(followedUser));
                    var followedUserPost = followedUserDetail?.Posts.OrderByDescending(x => x.TimeStamp).Select(x => (String.IsNullOrEmpty(x.MentionedBy) ? followedUserDetail.UserName : x.MentionedBy) + " - " + x.PrettyPrint).ToList();
                    posts.AddRange(followedUserPost);
                }
            }
            return posts;
        }

        public IList<string> GetAllMessages(string userName)
        {
            var user = _repo.GetPosts(new User(userName));
            var messages = user?.Messages?.OrderByDescending(x => x.TimeStamp).Select(x => x.PrettyPrint).ToList();
            return messages;
        }
    }
}
