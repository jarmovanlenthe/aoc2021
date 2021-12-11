namespace Challenges.Days;

public class Day11 : Day<List<Day11.Octopus>, int>
{
    public class Octopus
    {
        public (int,int) Position { get; set; }
        public int Energy { get; set; }
        public bool Flashed { get; set; }
    }

    private static readonly (int, int)[] Neighbors =
    {
        (0, 1), (1, 0), (-1, 0), (0, -1), (-1, -1), (1, 1), (-1, 1), (1, -1)
    };

    private int DoSteps(List<Octopus> puzzleInput, int part)
    {
        var flashCount = 0;
        var stop = false;
        var step = 0;

        while(!stop)
        {
            foreach (var octopus in puzzleInput)
            {
                octopus.Energy++;
            }

            var flashers = puzzleInput.Where(o => o.Energy > 9).ToList();
            while (flashers.Count != 0)
            {
                foreach (var octopus in flashers)
                {
                    octopus.Flashed = true;
                    foreach (var neighbor in Neighbors.Select(x => (x.Item1+octopus.Position.Item1, x.Item2+octopus.Position.Item2)))
                    {
                        if (neighbor.Item1 is < 10 and >= 0 && neighbor.Item2 is < 10 and >= 0)
                        {
                            puzzleInput.Single(o => o.Position == neighbor).Energy++;
                        }
                    }
                }
                flashers = puzzleInput.Where(o=> !o.Flashed && o.Energy > 9).ToList();
            }

            step++;

            if (part == 2 && puzzleInput.All(o => o.Flashed))
            {
                return step;
            }

            foreach (var octopus in puzzleInput.Where(o => o.Flashed))
            {
                flashCount += 1;
                octopus.Flashed = false;
                octopus.Energy = 0;
            }

            if (part == 1 && step == 100)
            {
                return flashCount;
            }
        }

        return flashCount;
    }

    public override int Part1(List<Octopus> puzzleInput)
    {
        return DoSteps(puzzleInput, 1);
    }

    public override int Part2(List<Octopus> puzzleInput)
    {
        return DoSteps(puzzleInput, 2);
    }

    public override List<Octopus> PreprocessData(string[] puzzleInput)
    {
        var octopi = new List<Octopus>();
        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < 10; j++)
            {
                octopi.Add(new Octopus
                {
                    Position = (i, j),
                    Energy = int.Parse(puzzleInput[i][j].ToString())
                });
            }
        }

        return octopi;
    }
}
