using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challenges.Days
{
    public class Day10 : Day<IEnumerable<StringReader>, long>
    {
        private static readonly Dictionary<char, int> ScoresPart1 = new()
        {
            {' ', 0},
            {')', 3 },
            {']', 57},
            {'}', 1197},
            {'>', 25137}
        };

        private static readonly Dictionary<char, int> ScoresPart2 = new()
        {
            { ')', 1 },
            { ']', 2 },
            { '}', 3 },
            { '>', 4 }
        };
        private static (char, Stack<char>) ProcessChunk(StringReader s)
        {
            var endChars = new Stack<char>();
            int n;
            while ((n = s.Read()) != -1)
            {
                var c = (char)n;
                switch (c)
                {
                    case '{':
                        endChars.Push('}');
                        break;
                    case '(':
                        endChars.Push(')');
                        break;
                    case '<':
                        endChars.Push('>');
                        break;
                    case '[':
                        endChars.Push(']');
                        break;
                    default:
                        if (c != endChars.Pop())
                        {
                            return (c, endChars);
                        }
                        break;
                }
            }

            return (' ', endChars);
        }
        public override long Part1(IEnumerable<StringReader> puzzleInput)
        {
            return puzzleInput.Select(ProcessChunk).Select(x => ScoresPart1[x.Item1]).Sum();
        }

        private static long CalculateScore(Stack<char> st)
        {
            var totalScore = (long)0;
            while (st.TryPop(out var c))
            {
                totalScore *= 5;
                totalScore += ScoresPart2[c];
            }

            return totalScore;
        }
        public override long Part2(IEnumerable<StringReader> puzzleInput)
        {
            var endChars = puzzleInput.Select(ProcessChunk).Where(x => x.Item1 == ' ').Select(x => x.Item2).Select(CalculateScore).OrderBy(x => x).ToList();
            return endChars[(endChars.Count - 1) / 2];
        }

        public override IEnumerable<StringReader> PreprocessData(string[] puzzleInput)
        {
            return puzzleInput.Select(x => new StringReader(x));
        }
    }
}
