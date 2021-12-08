using System.Collections.Generic;
using System.IO;
using Challenges.Days;
using Xunit;

namespace TestChallenges
{
    public class TestDay07
    {
        [Fact]
        public void TestPart1()
        {
            var day = new Day07();
            Assert.Equal(37, day.Part1(new List<int>{16,1,2,0,4,2,7,1,2,14}));
        }

        [Fact]
        public void TestPart2()
        {
            var day = new Day07();
            Assert.Equal(168, day.Part2(new List<int>{16,1,2,0,4,2,7,1,2,14}));
        }
    }
}
