using SocialNetworkKata.Core.Utility;
using System;
using Xunit;

namespace SocialNetworkKata.Tests
{
    public class TimeFormatterTest
    {
        [Fact]
        public void PrettyPrint_MethodReturns_String()
        {
            Assert.IsType<string>(TimeFormatter.PrettyPrint(DateTime.Now));
        }

        [Fact]
        public void PrettyPrint_MethodNotNull()
        {
            Assert.Throws<FormatException>(() => TimeFormatter.PrettyPrint(DateTime.Parse("")));
            //Assert.Equal("Hello", exceptionDetails.Message);
        }

        [Fact]
        public void PrettyPrint_ReturnsTimeIn_RequiredFormat()
        {
            Assert.Equal("0 second ago", TimeFormatter.PrettyPrint(DateTime.Now));
        }
    }
}