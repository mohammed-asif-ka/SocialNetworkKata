using Moq;
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
    public class ReadingServiceTests
    {
        private readonly ReadingService _service;
        private readonly Mock<IPostRepository> _repo;
        public ReadingServiceTests()
        {
            _repo = new Mock<IPostRepository>();
            _service = new ReadingService(_repo.Object);
        }

        [Fact]
        public void GetTimeLinePosts_GivenUserNameAsEmpty_GetEmptyList()
        {
            var repo = Mock.Of<IPostRepository>();
            var obj = _service.GetTimeLinePosts("");
            Assert.Equal(null, obj);
        }
        [Fact]
        public void GetTimeLinePosts_GivenUserName_ReturnStingPosts()
        {
            var repo = Mock.Of<IPostRepository>();
            var obj = _service.GetAllPosts("Alice");
            Assert.Null(obj);
        }
    }
}
