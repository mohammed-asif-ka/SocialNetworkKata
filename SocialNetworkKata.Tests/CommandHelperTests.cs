using SocialNetworkKata.ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SocialNetworkKata.Tests
{
    public class CommandHelperTests
    {
        [Fact]
        public void Test_SplitHelper_whenIndexOut()
        {
            Assert.Throws<IndexOutOfRangeException>(() => CommandHelper.SplitHelper(@"a/", "/"));
            //Assert.Equal("Hello", exceptionDetails.Message);
        }
        [Fact]
        public void Test_SplitHelper_working()
        {
            Assert.Equal(Tuple.Create("a", "b"), CommandHelper.SplitHelper(@"a/b", "/"));
        }
        [Fact]
        public void Test_SplitHelperShort_working()
        {
            Assert.Equal("a", CommandHelper.SplitHelperShort(@"a/", "/"));
        }
        //[Fact]
        //public void Test_PrintAcknowledgment_ListIsEmpty()
        //{
        //    var list = new List<string>();
        //    Assert.Throws<Exception>(() => CommandHelper.PrintAcknowledgment(list,false));
        //    Assert.PropertyChanged(CommandHelper.PrintAcknowledgment(list, false));
        //}
    }
}
