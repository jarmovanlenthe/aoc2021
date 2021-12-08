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
            var x = output.Select(o => o.Split(' ')).SelectMany(x => x);
            return x.Count(x => x.Length is 2 or 3 or 4 or 7);
        }

        public override int Part2(string[] puzzleInput)
        {
            var result = new List<int>();
            foreach (var entry in puzzleInput)
            {
                var allNumbers = entry.Replace(" | ", " ").Split(' ').Select(x =>
                {
                    var y = x.ToCharArray();
                    Array.Sort(y);
                    return y;
                }).ToArray();
                var output = entry.Split(" | ")[1].Split(' ').Select(x =>
                {
                    var y = x.ToCharArray();
                    Array.Sort(y);
                    return y;
                }).ToArray();

                //   a
                // b   c
                //   d
                // e   f
                //   g

                var one = allNumbers.First(x => x.Length == 2);
                var seven = allNumbers.First(x => x.Length == 3);
                var four = allNumbers.First(x => x.Length == 4);
                // 2,3,5 -> length 5
                // 2 has 1 overlap with 1, 2 with 7, 2 with 4
                // 3 has 2 overlap with 1, 3 with 7, 3 with 4
                // 5 has 1 overlap with 1, 2 with 7, 3 with 4
                // 6,9,0 -> length 6
                // 6 has 1 overlap with 1, 2 with 7, 3 with 4
                // 9 has 2 overlap with 1, 3 with 7, 4 with 4
                // 0 has 2 overlap with 1, 3 with 4, 3 with 4
                var outputNumber = "";
                foreach (var character in output)
                {
                    if (character.Length == 2)
                    {
                        outputNumber += "1";
                    }
                    else if (character.Length == 3)
                    {
                        outputNumber += "7";
                    }
                    else if (character.Length == 4)
                    {
                        outputNumber += "4";
                    }
                    else if (character.Length == 7)
                    {
                        outputNumber += "8";
                    }
                    else if (character.Length == 5)
                    {
                        if (character.Intersect(seven).Count() == 3)
                        {
                            outputNumber += "3";
                        }
                        else
                        {
                            if (character.Intersect(four).Count() == 2)
                            {
                                outputNumber += "2";
                            }
                            else
                            {
                                outputNumber += "5";
                            }
                        }
                    }
                    else if (character.Length == 6)
                    {
                        if (character.Intersect(one).Count() == 1)
                        {
                            outputNumber += "6";
                        }
                        else if (character.Intersect(four).Count() == 4)
                        {
                            outputNumber += "9";
                        }
                        else
                        {
                            outputNumber += "0";
                        }
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
