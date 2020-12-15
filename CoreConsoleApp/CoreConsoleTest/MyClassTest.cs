using CoreConsoleLib;
using Xunit;

namespace CoreConsoleTest
{
    public class MyClassTest
    {
        [Fact]
        public void MyFuncTest()
        {
            var result = MyClass.MyFunc();
            Assert.NotNull(result);
        }
    }
}