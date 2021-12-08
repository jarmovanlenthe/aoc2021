using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Xml;

namespace Challenges.Days
{
    public class Day08 : Day<string[], int>
    {
        public override int Part1(string[] puzzleInput)
        {
            var output = puzzleInput.Select(entry => entry.Split(" | ")[1]);
            return output.Select(o => o.Split(' ')).SelectMany(x => x).Count(x => x.Length is 2 or 3 or 4 or 7);
        }

        public override int Part2(string[] puzzleInput)
        {
            var result = new List<int>();
            foreach (var entry in puzzleInput)
            {
                var allNumbers = entry.Replace(" | ", " ").Split(' ').ToArray();
                var output = entry.Split(" | ")[1].Split(' ').ToArray();

                var one = allNumbers.First(x => x.Length == 2);
                var seven = allNumbers.First(x => x.Length == 3);
                var four = allNumbers.First(x => x.Length == 4);

                var outputNumber = "";
                foreach (var character in output)
                {
                    switch (character.Length)
                    {
                        case 2:
                            outputNumber += "1";
                            break;
                        case 3:
                            outputNumber += "7";
                            break;
                        case 4:
                            outputNumber += "4";
                            break;
                        case 7:
                            outputNumber += "8";
                            break;
                        case 5 when character.Intersect(seven).Count() == 3:
                            outputNumber += "3";
                            break;
                        case 5 when character.Intersect(four).Count() == 2:
                            outputNumber += "2";
                            break;
                        case 5:
                            outputNumber += "5";
                            break;
                        case 6 when character.Intersect(one).Count() == 1:
                            outputNumber += "6";
                            break;
                        case 6 when character.Intersect(four).Count() == 4:
                            outputNumber += "9";
                            break;
                        case 6:
                            outputNumber += "0";
                            break;
                    }
                }

                result.Add(int.Parse(outputNumber));
            }

            return result.Sum();
        }

        public override string[] PreprocessData(string[] puzzleInput)
        {
            return puzzleInput;
        }
    }
}
