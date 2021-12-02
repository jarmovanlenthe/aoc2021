using Challenges.Days;
using Xunit;

namespace TestChallenges
{
    public class TestDay02
    {
        Day02.Instruction[] input = {
            new() { Direction = "forward", Amount = 5},
            new() { Direction = "down", Amount = 5},
            new() { Direction = "forward", Amount = 8},
            new() { Direction = "up", Amount = 3},
            new() { Direction = "down", Amount = 8},
            new() { Direction = "forward", Amount = 2}
        };

        [Fact]
        public void TestPart1()
        {
            var day = new Day02();
            Assert.Equal(150, day.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            var day = new Day02();
            Assert.Equal(900, day.Part2(input));
        }
    }
}
