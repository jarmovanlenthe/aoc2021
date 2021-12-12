using System.IO;
using System.Linq;
using Challenges.Days;
using Xunit;

namespace TestChallenges
{
    public class TestDay12
    {
        [Fact]
        public void TestPart1()
        {
            var day = new Day12();
            var input = day.PreprocessData(File.ReadAllLines("Input/12_1.txt"));
            Assert.Equal(10, day.Part1(input));
            input = day.PreprocessData(File.ReadAllLines("Input/12_2.txt"));
            Assert.Equal(19, day.Part1(input));
            input = day.PreprocessData(File.ReadAllLines("Input/12_3.txt"));
            Assert.Equal(226, day.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            var day = new Day12();
            var input = day.PreprocessData(File.ReadAllLines("Input/12_1.txt"));
            Assert.Equal(36, day.Part2(input));
            input = day.PreprocessData(File.ReadAllLines("Input/12_2.txt"));
            Assert.Equal(103, day.Part2(input));
            input = day.PreprocessData(File.ReadAllLines("Input/12_3.txt"));
            Assert.Equal(3509, day.Part2(input));
        }
    }
}
