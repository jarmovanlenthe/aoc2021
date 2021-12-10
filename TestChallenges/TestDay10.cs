using System.Collections.Generic;
using System.IO;
using Challenges.Days;
using Xunit;

namespace TestChallenges
{
    public class TestDay10
    {
        [Fact]
        public void TestPart1()
        {
            var day = new Day10();
            var input = day.PreprocessData(File.ReadAllLines("Input/10_1.txt"));
            Assert.Equal(26397, day.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            var day = new Day10();
            var input = day.PreprocessData(File.ReadAllLines("Input/10_1.txt"));
            Assert.Equal(288957, day.Part2(input));
        }
    }
}
