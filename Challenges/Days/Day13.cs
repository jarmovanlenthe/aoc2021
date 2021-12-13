using Challenges.Util;

namespace Challenges.Days;

public class Day13 : Day<Day13.Manual, int>
{
    public class Manual
    {
        public HashSet<(int,int)> Sheet { get; set; }
        public List<(char, int)> Folds { get; init; }
    }

    private static string SheetToString(HashSet<(int,int)> sheet)
    {
        var result = "-----\n";
        for (var i = 0; i <= sheet.Select(k => k.Item2).Max(); i++)
        {
            for (var j = 0; j <= sheet.Select(k => k.Item1).Max(); j++)
            {
                if (sheet.Contains((j, i)))
                {
                    result += "#";
                }
                else
                {
                    result += " ";
                }
            }

            result += "\n";
        }

        result += "-----\n";
        return result;
    }

    private static HashSet<(int,int)> FoldUp(HashSet<(int,int)> sheet, int index)
    {
        return sheet.Select(x => (x.Item1, x.Item2 > index ? 2 * index - x.Item2 : x.Item2)).ToHashSet();
    }

    private static HashSet<(int,int)> FoldLeft(HashSet<(int,int)> sheet, int index)
    {
        return sheet.Select(x => (x.Item1 > index ? 2 * index - x.Item1 : x.Item1, x.Item2)).ToHashSet();
    }

    public override int Part1(Manual puzzleInput)
    {
        if (puzzleInput.Folds[0].Item1 == 'x')
        {
            return FoldLeft(puzzleInput.Sheet, puzzleInput.Folds[0].Item2).Count;
        }
        return FoldUp(puzzleInput.Sheet, puzzleInput.Folds[0].Item2).Count;
    }

    public override int Part2(Manual puzzleInput)
    {
        var sheet = puzzleInput.Sheet;
        foreach (var (axis, index) in puzzleInput.Folds)
        {
            if (axis == 'x')
            {
                sheet = FoldLeft(sheet, index);
                continue;
            }
            sheet = FoldUp(sheet, index);
        }
        Console.WriteLine(SheetToString(sheet));
        return 0;
    }

    public override Manual PreprocessData(string[] puzzleInput)
    {
        var sheetComplete = false;
        var sheet = new HashSet<(int,int)>();
        var folds = new List<(char, int)>();
        foreach (var line in puzzleInput)
        {
            if (string.IsNullOrEmpty(line))
            {
                sheetComplete = true;
                continue;
            }

            if (!sheetComplete)
            {
                var x = int.Parse(line.Split(',').First());
                var y = int.Parse(line.Split(',').Last());
                sheet.Add((x, y));
            }
            else
            {
                var axis = line.Split('=').First().Last();
                var index = int.Parse(line.Split('=').Last());
                folds.Add((axis, index));
            }
        }

        return new Manual
        {
            Sheet = sheet,
            Folds = folds
        };
    }
}
