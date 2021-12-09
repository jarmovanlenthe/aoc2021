using System.Collections.Generic;
using System.Linq;

namespace Challenges.Days
{
    public class Day09 : Day<Dictionary<(int,int), int>, int>
    {
        private static readonly (int, int)[] Neighbors = {
            (0, -1),
            (-1, 0),
            (0, 1),
            (1, 0)
        };

        private List<(int, int)> FindLowestPoints(Dictionary<(int, int), int> grid)
        {
            var lowestPoints = new List<(int, int)>();
            foreach (var (pX, pY) in grid.Keys)
            {
                var isLowest = true;
                foreach (var neighbor in Neighbors.Select(x => (x.Item1 + pX, x.Item2 + pY)))
                {
                    if (grid.ContainsKey(neighbor) && grid[neighbor] < grid[(pX, pY)])
                    {
                        isLowest = false;
                    }
                }

                if (isLowest && grid[(pX, pY)] != 9)
                {
                    lowestPoints.Add((pX, pY));
                }
            }

            return lowestPoints;
        }

        public override int Part1(Dictionary<(int, int), int> puzzleInput)
        {
            var lowestPoints = FindLowestPoints(puzzleInput);

            return lowestPoints.Select(x => puzzleInput[x] + 1).Sum();
        }

        private HashSet<(int, int)> FindBasin(Dictionary<(int, int), int> grid, (int, int) point)
        {
            var basin = new HashSet<(int, int)>();
            var seen = new HashSet<(int, int)>();
            var pointsToCheck = new HashSet<(int, int)> { point };

            while (pointsToCheck.Any())
            {
                var newPointsToCheck = new HashSet<(int, int)>();
                foreach (var pointToCheck in pointsToCheck)
                {
                    seen.Add(pointToCheck);
                    if (grid[pointToCheck] == 9)
                    {
                        continue;

                    }
                    basin.Add(pointToCheck);
                    var neighbors = Neighbors.Select(x => (x.Item1 + pointToCheck.Item1, x.Item2 + pointToCheck.Item2));
                    foreach (var neighbor in neighbors)
                    {
                        if (!seen.Contains(neighbor) && !basin.Contains(neighbor) && grid.ContainsKey(neighbor))
                        {
                            newPointsToCheck.Add(neighbor);
                        }
                    }

                }

                pointsToCheck = newPointsToCheck;
            }

            return basin;
        }
        public override int Part2(Dictionary<(int, int), int> puzzleInput)
        {
            var lowestPoints = FindLowestPoints(puzzleInput);
            var basins = lowestPoints.Select(lowestPoint => FindBasin(puzzleInput, lowestPoint));

            return basins.OrderByDescending(x => x.Count).Take(3).Select(x => x.Count).Aggregate(1, (acc, val) => acc * val);
        }

        public override Dictionary<(int, int), int> PreprocessData(string[] puzzleInput)
        {
            var result = new Dictionary<(int, int), int>();
            for (var i = 0; i < puzzleInput.Length; i++)
            {
                for (var j = 0; j < puzzleInput[i].Length; j++)
                {
                    result[(i, j)] = int.Parse(puzzleInput[i][j].ToString());
                }
            }

            return result;
        }
    }
}
