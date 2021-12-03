using System;
using System.Collections.Generic;
using System.Linq;
using Challenges.Util;

namespace Challenges.Days
{
    public class Day03 : Day<string[], int>
    {
        public override int Part1(string[] puzzleInput)
        {
            var gammaRate = "";
            foreach (var l in puzzleInput.Transpose())
            {
                if (l.Count(e => e == '1') > l.Count() / 2)
                {
                    gammaRate += '1';
                }
                else
                {
                    gammaRate += "0";
                }
            }

            var epsilonRate = string.Join("", gammaRate.Select(x => x == '1' ? '0' : '1'));

            return Convert.ToInt32(gammaRate, fromBase: 2) * Convert.ToInt32(epsilonRate, fromBase: 2);
        }

        private string filterNumbers(string[] toConsider, int position, char keep)
        {
            if (toConsider.Length == 1)
            {
                return toConsider[0];
            }

            var elementsAtPosition = toConsider.Transpose().ToArray()[position].ToArray();
            var keepValue = keep;
            if (elementsAtPosition.Count(x => x == '1') * 2 != elementsAtPosition.Length)
            {
                var mostFrequent = elementsAtPosition.Count(x => x == '1') > elementsAtPosition.Length / 2 ? '1' : '0';
                keepValue = keep == '1' ? mostFrequent : mostFrequent == '1' ? '0' : '1';
            }

            return filterNumbers(toConsider.Where(x => x[position] == keepValue).ToArray(), position + 1, keep);



        }
        public override int Part2(string[] puzzleInput)
        {
            var oxygenRate = filterNumbers(puzzleInput, 0, '1');
            var co2Rating = filterNumbers(puzzleInput, 0, '0');
            return Convert.ToInt32(oxygenRate, fromBase: 2) * Convert.ToInt32(co2Rating, fromBase: 2);
        }

        public override string[] PreprocessData(string[] puzzleInput)
        {
            return puzzleInput;
        }
    }
}
