using Challenges.Days;
using Xunit;

namespace TestChallenges
{
    public class TestDay01
    {
        [Fact]
        public void TestPart1()
        {
            var day = new Day01();
            Assert.Equal(7, day.Part1(new []{199, 200, 208, 210, 200, 207, 240, 269, 260, 263}));
        }

        [Fact]
        public void TestPart2()
        {
            var day = new Day01();
            Assert.Equal(5, day.Part2(new []{199, 200, 208, 210, 200, 207, 240, 269, 260, 263}));
        }
    }
}
