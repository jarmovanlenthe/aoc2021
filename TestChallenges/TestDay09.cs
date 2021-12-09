using System.Collections.Generic;
using System.IO;
using Challenges.Days;
using Xunit;

namespace TestChallenges
{
    public class TestDay09
    {
        [Fact]
        public void TestPart1()
        {
            var day = new Day09();
            var input = day.PreprocessData(File.ReadAllLines("Input/09_1.txt"));
            Assert.Equal(15, day.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            var day = new Day09();
            var input = day.PreprocessData(File.ReadAllLines("Input/09_1.txt"));
            Assert.Equal(1134, day.Part2(input));
        }
    }
}
