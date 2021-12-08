using System.Collections.Generic;
using System.Linq;

namespace Challenges.Days
{
    public class Day06 : Day<List<int>, long>
    {
        private int days = 80;
        public override long Part1(List<int> puzzleInput)
        {
            var fishOfDays = Enumerable.Repeat((long)0, 9).ToArray();
            foreach (var fishOfDay in puzzleInput)
            {
                fishOfDays[fishOfDay]++;
            }

            for (int i = 0; i < days; i++)
            {
                fishOfDays = new[]
                {
                    fishOfDays[1], fishOfDays[2], fishOfDays[3], fishOfDays[4], fishOfDays[5],
                    fishOfDays[6], fishOfDays[7] + fishOfDays[0], fishOfDays[8], fishOfDays[0]
                };
            }

            return fishOfDays.Sum();
        }

        public override long Part2(List<int> puzzleInput)
        {
            days = 256;
            return Part1(puzzleInput);

        }

        public override List<int> PreprocessData(string[] puzzleInput)
        {
            return puzzleInput[0].Split(',').Select(int.Parse).ToList();
        }
    }
}
