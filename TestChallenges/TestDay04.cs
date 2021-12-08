using System.IO;
using Challenges.Days;
using Xunit;

namespace TestChallenges
{
    public class TestDay04
    {
        [Fact]
        public void TestPart1()
        {
            var day = new Day04();
            var input = day.PreprocessData(File.ReadAllLines("Input/04_1.txt"));
            Assert.Equal(4512, day.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            var day = new Day04();
            var input = day.PreprocessData(File.ReadAllLines("Input/04_1.txt"));
            Assert.Equal(1924, day.Part2(input));
        }
    }
}
