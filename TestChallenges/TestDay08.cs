using System.Collections.Generic;
using System.IO;
using Challenges.Days;
using Xunit;

namespace TestChallenges
{
    public class TestDay08
    {
        [Fact]
        public void TestPart1()
        {
            var day = new Day08();
            var input = File.ReadAllLines("Input/08_1.txt");
            Assert.Equal(26, day.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            var day = new Day08();
            var input = File.ReadAllLines("Input/08_2.txt");
            Assert.Equal(5353, day.Part2(input));
            input = File.ReadAllLines("Input/08_1.txt");
            Assert.Equal(61229, day.Part2(input));
        }
    }
}
