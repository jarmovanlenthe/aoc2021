using System.Linq;
using Challenges.Util;

namespace Challenges.Days
{
    public class Day01 : Day<int[], int>
    {
        public override int Part1(int[] puzzleInput)
        {
            return puzzleInput.Zip(puzzleInput[1..], (x, y) => x < y).Count(x => x);
        }

        public override int Part2(int[] puzzleInput)
        {
            var sums = puzzleInput.ZipThree(puzzleInput[1..], puzzleInput[2..], (x, y, z) => x + y + z).ToArray();
            return sums.Zip(sums[1..], (x, y) => x < y).Count(x => x);
        }

        public override int[] PreprocessData(string[] puzzleInput)
        {
            return puzzleInput.Select(int.Parse).ToArray();
        }
    }
}
