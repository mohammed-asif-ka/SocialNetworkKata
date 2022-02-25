using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Model
{
    public class User
    {
        public User(string userName)
        {
            UserName = userName;
            Posts = new List<Post>();
            Messages = new List<Message>();
        }
        public User()
        {
        }
        public User(string userName, Post post)
        {
            UserName = userName;
            Posts.Add(post);
            Messages = new List<Message>();
        }
        public string UserName { get; set; }
        public IList<Post> Posts { get; set; }
        public IList<string>? Following { get; set; }
        public IList<Message> Messages { get; set; }
    }
}
