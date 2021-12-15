using System.IO;
using System.Linq;
using Challenges.Days;
using Xunit;

namespace TestChallenges
{
    public class TestDay15
    {
        [Fact]
        public void TestPart1()
        {
            var day = new Day15();
            var input = day.PreprocessData(File.ReadAllLines("Input/15_1.txt"));
            Assert.Equal(40, day.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            var day = new Day15();
            var input = day.PreprocessData(File.ReadAllLines("Input/15_1.txt"));
            Assert.Equal(315, day.Part2(input));
        }
    }
}
