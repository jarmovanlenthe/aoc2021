using System.Resources;

namespace Challenges.Days;

public class Day12 : Day<List<Day12.Cave>, int>
{
    public enum CaveSize
    {
        Small,
        Big
    }
    public class Cave
    {
        public string Name { get; init; }
        public CaveSize Size { get; init; }
        public List<Cave> Neighbors { get; } = new();
    }

    private static bool SingleCaveVisitedTwice(List<Cave> path)
    {
        var x = path.Where(c => c.Name.ToLower() == c.Name).ToList();
        return x.Count != x.Distinct().Count();
    }

    private static void FindAllPaths(List<Cave> caveSystem, List<List<Cave>> paths, Cave currentCave, List<Cave> prevPath, bool part2=false)
    {
        var path = prevPath.ToList();
        if (currentCave == caveSystem.Single(c => c.Name == "end"))
        {
            path.Add(currentCave);
            paths.Add(path);
            return;
        }

        if (currentCave.Size == CaveSize.Small && path.Contains(currentCave))
        {
            if (!part2)
            {
                return;
            }
            if (currentCave.Name == "start" || SingleCaveVisitedTwice(path))
            {
                return;
            }
        }

        path.Add(currentCave);
        foreach (var neighbor in currentCave.Neighbors)
        {
            FindAllPaths(caveSystem, paths, neighbor, path, part2);
        }
    }

    public override int Part1(List<Cave> puzzleInput)
    {
        var cavePaths = new List<List<Cave>>();
        FindAllPaths(puzzleInput, cavePaths, puzzleInput.Single(c => c.Name == "start"), new List<Cave>());
        return cavePaths.Count;
    }

    public override int Part2(List<Cave> puzzleInput)
    {
        var cavePaths = new List<List<Cave>>();
        FindAllPaths(puzzleInput, cavePaths, puzzleInput.Single(c => c.Name == "start"), new List<Cave>(), true);
        return cavePaths.Count;
    }

    public override List<Cave> PreprocessData(string[] puzzleInput)
    {
        var caves = new List<Cave>();
        foreach (var caveConnection in puzzleInput.Select(c => c.Split('-')))
        {
            var cave1 = caves.FirstOrDefault(c => c.Name == caveConnection[0]);
            var cave2 = caves.FirstOrDefault(c => c.Name == caveConnection[1]);
            if (cave1 == null)
            {
                cave1 = new Cave { Name = caveConnection[0], Size = caveConnection[0].ToLower() == caveConnection[0] ? CaveSize.Small : CaveSize.Big};
                caves.Add(cave1);
            }
            if (cave2 == null)
            {
                cave2 = new Cave { Name = caveConnection[1], Size = caveConnection[1].ToLower() == caveConnection[1] ? CaveSize.Small : CaveSize.Big};
                caves.Add(cave2);
            }

            cave1.Neighbors.Add(cave2);
            cave2.Neighbors.Add(cave1);
        }

        return caves;
    }
}
