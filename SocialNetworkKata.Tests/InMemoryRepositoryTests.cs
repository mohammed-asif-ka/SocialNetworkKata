using SocialNetworkKata.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SocialNetworkKata.Tests
{
    public class InMemoryRepositoryTests
    {
        private readonly InMemoryRepository _repo;
        public InMemoryRepositoryTests()
        {
            _repo = new InMemoryRepository();
        }

        [Fact]
        public void Test_Get_ThrowsError_When_UserEmpty()
        {
            Assert.Throws<NullReferenceException>(() => _repo.Subscribe(null,"Asif"));
        }
    }
}
