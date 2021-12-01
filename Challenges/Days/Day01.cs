using System.Linq;

namespace Challenges.Days
{
    public class Day01 : Day<int[], int>
    {
        public override int Part1(int[] puzzleInput)
        {
            return puzzleInput.Zip(puzzleInput[1..]).Select(x => x.First < x.Second).Count(x => x);
        }

        public override int Part2(int[] puzzleInput)
        {
            var sums = puzzleInput.Zip(puzzleInput[1..]).Zip(puzzleInput[2..]).Select(x => x.First.First + x.First.Second + x.Second).ToArray();
            return sums.Zip(sums[1..]).Select(x => x.First < x.Second).Count(x => x);
        }

        public override int[] PreprocessData(string[] puzzleInput)
        {
            return puzzleInput.Select(int.Parse).ToArray();
        }
    }
}
