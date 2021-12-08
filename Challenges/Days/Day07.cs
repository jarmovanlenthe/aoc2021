using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges.Days
{
    public class Day07 : Day<List<int>, int>
    {
        public override int Part1(List<int> puzzleInput)
        {
            var minFuel = 10000000;
            for (var i = puzzleInput.Min(); i < puzzleInput.Max(); i++)
            {
                var fuel = puzzleInput.Select(x => Math.Abs(x - i)).Sum();
                if (fuel < minFuel)
                {
                    minFuel = fuel;
                }
            }

            return minFuel;
        }

        private int DoSum(int x)
        {
            if (x == 0)
            {
                return 0;
            }

            return x + DoSum(x - 1);
        }
        public override int Part2(List<int> puzzleInput)
        {
            var minFuel = 1000000000;
            for (var i = puzzleInput.Min(); i < puzzleInput.Max(); i++)
            {
                var fuel = puzzleInput.Select(x => DoSum(Math.Abs(x - i))).Sum();
                if (fuel < minFuel)
                {
                    minFuel = fuel;
                }
            }

            return minFuel;
        }

        public override List<int> PreprocessData(string[] puzzleInput)
        {
            return puzzleInput[0].Split(',').Select(int.Parse).ToList();
        }
    }
}
