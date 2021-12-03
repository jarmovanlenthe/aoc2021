using System.IO;
using Challenges.Days;
using Xunit;

namespace TestChallenges
{
    public class TestDay03
    {
        [Fact]
        public void TestPart1()
        {
            var day = new Day03();
            var input = File.ReadAllLines("Input/03_1.txt");
            Assert.Equal(198, day.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            var day = new Day03();
            var input = File.ReadAllLines("Input/03_1.txt");
            Assert.Equal(230, day.Part2(input));
        }
    }
}
