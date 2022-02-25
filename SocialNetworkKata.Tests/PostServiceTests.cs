using Moq;
using SocialNetworkKata.Core.Model;
using SocialNetworkKata.Core.Repository.Interface;
using SocialNetworkKata.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SocialNetworkKata.Tests
{
    public class PostServiceTests
    {
        private readonly PostService _service;
        private readonly Mock<IPostRepository> _repo;
        public PostServiceTests()
        {
            _repo = new Mock<IPostRepository>();
            _service = new PostService(_repo.Object);
        }

        [Fact]
        public void Post_givenUserName_and_content_should_return_user()
        {
            //var in1memory = Mock.Of<IInMemoryRepository>();
            //var repo = Mock.Of<IPostRepository>();
            //var post = Mock.Of<Post>(x => x.Content == "Wow" && x.TimeStamp == DateTime.Now);
            //var user1 = Mock.Of<User>(x => x.UserName == "Alice");
            //var value = repo.Post(user, post) as User;
            //Assert.Null(value);
            var user = _service.Post("Alice", "It is a wonderful Day!");
            Assert.Null(user);
        }
    }
}
