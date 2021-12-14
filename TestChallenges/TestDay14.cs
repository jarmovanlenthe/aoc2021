using System.IO;
using Challenges.Days;
using Xunit;

namespace TestChallenges
{
    public class TestDay14
    {
        [Fact]
        public void TestPart1()
        {
            var day = new Day14();
            var input = day.PreprocessData(File.ReadAllLines("Input/14_1.txt"));
            Assert.Equal(1588, day.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            var day = new Day14();
            var input = day.PreprocessData(File.ReadAllLines("Input/14_1.txt"));
            Assert.Equal(2188189693529, day.Part2(input));
        }
    }
}
