using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace XunitTest1
{
    public class Class1
    {
        public Class1(ITestOutputHelper testOutputHelper)
        {
            this.output = testOutputHelper;
        }

        [Theory]
        [InlineData("abcdef", 174)]
        [InlineData("zyxel", 10041)]
        public void TestTheory(string data1, int data2)
        {
        }

        [Fact]
        public void WithOutput()
        {
            output.WriteLine("Line 1");
            output.WriteLine("Line 2");
            Thread.Sleep(TimeSpan.FromMilliseconds(150));
        }

        [Fact]
        public void LongRunning()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        //[Fact]
        public void Crash()
        {
            Environment.FailFast("Crash");
        }

        [Fact]
        public void Failed()
        {
            output.WriteLine("Some output");
            Assert.True(true);
        }

        [Fact(Skip = "Reason!!")]
        public void Skipped()
        {
        }

        [Fact]
        public void Passed()
        {
            var i = Sub;
            var j = Sub.Name;
            var k = this.Sub.Name;
        }

        public Class2 Sub = new Class2();
        private readonly ITestOutputHelper output;
    }

    public class Class2
    {
        public string Name { get; set; } = "Foo";
    }
}
