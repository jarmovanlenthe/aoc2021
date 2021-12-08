using System.IO;
using Challenges.Days;
using Xunit;

namespace TestChallenges
{
    public class TestDay05
    {
        [Fact]
        public void TestPart1()
        {
            var day = new Day05();
            var input = day.PreprocessData(File.ReadAllLines("Input/05_1.txt"));
            Assert.Equal(5, day.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            var day = new Day05();
            var input = day.PreprocessData(File.ReadAllLines("Input/05_1.txt"));
            Assert.Equal(12, day.Part2(input));
        }
    }
}
