using System.Collections.Generic;
using System.IO;
using Challenges.Days;
using Xunit;

namespace TestChallenges
{
    public class TestDay06
    {
        [Fact]
        public void TestPart1()
        {
            var day = new Day06();
            Assert.Equal(5934, day.Part1(new List<int>{3,4,3,1,2}));
        }

        [Fact]
        public void TestPart2()
        {
            var day = new Day06();
            Assert.Equal(26984457539, day.Part2(new List<int>{3,4,3,1,2}));
        }
    }
}
