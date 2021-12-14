using Challenges.Util;

namespace Challenges.Days;

public class Day14 : Day<Day14.Manual, long>
{
    private int _steps = 10;

    public class Manual
    {
        public string PolymerTemplate { get; init; }
        public Dictionary<string, char> Rules { get; init; }
    }


    public override long Part1(Manual puzzleInput)
    {
        var pairSet = new DefaultDictionary<string, long>();
        var charCount = new DefaultDictionary<char, long>();
        foreach (var c in puzzleInput.PolymerTemplate)
        {
            charCount[c]++;
        }

        foreach (var pair in puzzleInput.PolymerTemplate.Zip(puzzleInput.PolymerTemplate[1..]))
        {
            pairSet[$"{pair.First}{pair.Second}"]++;
        }

        for (var step = 0; step < _steps; step++)
        {
            var newPairSet = new DefaultDictionary<string, long>();
            foreach (var pair in pairSet.Keys)
            {
                if (puzzleInput.Rules.ContainsKey(pair))
                {
                    newPairSet[$"{pair[0]}{puzzleInput.Rules[pair]}"] += pairSet[pair];
                    newPairSet[$"{puzzleInput.Rules[pair]}{pair[1]}"] += pairSet[pair];
                    charCount[puzzleInput.Rules[pair]] += pairSet[pair];
                }
                else
                {
                    newPairSet[pair]++;
                }
            }

            pairSet = newPairSet;
        }

        var least = charCount.OrderBy(x => x.Value).First().Value;
        var most = charCount.OrderBy(x => x.Value).Last().Value;

        return most - least;
    }

    public override long Part2(Manual puzzleInput)
    {
        _steps = 40;
        return Part1(puzzleInput);
    }

    public override Manual PreprocessData(string[] puzzleInput)
    {
        return new Manual
        {
            PolymerTemplate = puzzleInput[0],
            Rules = new Dictionary<string, char>(puzzleInput[2..].Select(l => new KeyValuePair<string, char>(l.Split(" -> ").First(), l.Split(" -> ").Last()[0])))
        };
    }
}
