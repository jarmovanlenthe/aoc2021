using System.IO;
using System.Linq;
using Challenges.Days;
using Xunit;

namespace TestChallenges
{
    public class TestDay11
    {
        [Fact]
        public void TestPart1()
        {
            var day = new Day11();
            var input = day.PreprocessData(File.ReadAllLines("Input/11_1.txt"));
            Assert.Equal(1656, day.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            var day = new Day11();
            var input = day.PreprocessData(File.ReadAllLines("Input/11_1.txt"));
            Assert.Equal(195, day.Part2(input));
        }
    }
}
