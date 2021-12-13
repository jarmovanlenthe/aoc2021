using System.IO;
using System.Linq;
using Challenges.Days;
using Xunit;
using Xunit.Sdk;

namespace TestChallenges
{
    public class TestDay13
    {
        [Fact]
        public void TestPart1()
        {
            var day = new Day13();
            var input = day.PreprocessData(File.ReadAllLines("Input/13_1.txt"));
            Assert.Equal(17, day.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            var day = new Day13();
            var input = day.PreprocessData(File.ReadAllLines("Input/13_1.txt"));
            Assert.Equal(0, day.Part2(input)); //FAKE!
        }
    }
}
