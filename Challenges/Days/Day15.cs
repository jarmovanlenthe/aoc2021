namespace Challenges.Days;

public class Day15 : Day<Dictionary<Day15.Point, int>, long>
{
    // Big thanks to https://github.com/encse/adventofcode/blob/master/2021/Day15/Solution.cs for copying everything, but learning a lot too!
    // - PriorityQueues :-D
    // - usage of `with`
    // - usage of `from`, `let`, and `select`

    public record Point(int x, int y);

    private static IEnumerable<Point> Neighbors(Point point) =>
        new[]
        {
            point with { y = point.y + 1 },
            point with { y = point.y - 1 },
            point with { x = point.x + 1 },
            point with { x = point.x - 1 },
        };

    private static long CalculateTotalRisk(Dictionary<Point, int> grid)
    {
        var topLeft = new Point(0, 0);
        var bottomRight = new Point(grid.Keys.MaxBy(p => p.x).x, grid.Keys.MaxBy(p => p.y).y);

        var q = new PriorityQueue<Point, int>();
        var totalRiskMap = new Dictionary<Point, int>();

        totalRiskMap[topLeft] = 0;
        q.Enqueue(topLeft, 0);

        while (q.Count > 0) {
            var p = q.Dequeue();

            foreach (var n in Neighbors(p)) {
                if (grid.ContainsKey(n) && !totalRiskMap.ContainsKey(n)) {
                    var totalRisk = totalRiskMap[p] + grid[n];
                    totalRiskMap[n] = totalRisk;
                    if (n == bottomRight) {
                        break;
                    }
                    q.Enqueue(n, totalRisk);
                }
            }
        }

        return totalRiskMap[bottomRight];
    }
    public override long Part1(Dictionary<Point, int> puzzleInput)
    {
        return CalculateTotalRisk(puzzleInput);
    }

    public override long Part2(Dictionary<Point, int> puzzleInput)
    {
        var (ccol, crow) = (puzzleInput.Keys.MaxBy(p => p.x).x + 1, puzzleInput.Keys.MaxBy(p => p.y).y + 1);

        var res = new Dictionary<Point, int>(
            from y in Enumerable.Range(0, crow * 5)
            from x in Enumerable.Range(0, ccol * 5)

            // x, y and risk level in the original map:
            let tileY = y % crow
            let tileX = x % ccol
            let tileRiskLevel = puzzleInput[new Point(tileX, tileY)]

            // risk level is increased by tile distance from origin:
            let tileDistance = (y / crow) + (x / ccol)

            // risk level wraps around from 9 to 1:
            let riskLevel = (tileRiskLevel + tileDistance - 1) % 9 + 1
            select new KeyValuePair<Point, int>(new Point(x, y), riskLevel)
        );
        return CalculateTotalRisk(res);
    }

    public override Dictionary<Point, int> PreprocessData(string[] puzzleInput)
    {
        var result = new Dictionary<Point, int>();
        for (var y = 0; y < puzzleInput.Length; y++)
        {
            for (var x = 0; x < puzzleInput[y].Length; x++)
            {
                result[new Point(x, y)] = int.Parse(puzzleInput[y][x].ToString());
            }
        }

        return result;
    }
}
