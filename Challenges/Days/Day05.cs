using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Challenges.Util;

namespace Challenges.Days
{
    public class Day05 : Day<List<Day05.Line>, int>
    {
        public class Line
        {
            public (int, int) Coord1 { get; set; }
            public (int, int) Coord2 { get; set; }
        }

        public override int Part1(List<Line> puzzleInput)
        {
            var linesToConsider =
                puzzleInput.Where(x => x.Coord1.Item1 == x.Coord2.Item1 || x.Coord1.Item2 == x.Coord2.Item2);
            return Part2(linesToConsider.ToList());
        }

        public override int Part2(List<Line> puzzleInput)
        {
            var grid = new DefaultDictionary<(int, int), int>();
            foreach (var line in puzzleInput)
            {
                var points = new List<(int, int)>();
                var x = line.Coord1.Item1;
                var y = line.Coord1.Item2;
                points.Add((x, y));
                while ((x, y) != line.Coord2)
                {
                    if (x < line.Coord2.Item1)
                    {
                        x += 1;
                    }
                    else if (x > line.Coord2.Item1)
                    {
                        x -= 1;
                    }
                    if (y < line.Coord2.Item2)
                    {
                        y += 1;
                    }
                    else if (y > line.Coord2.Item2)
                    {
                        y -= 1;
                    }
                    points.Add((x, y));
                }

                foreach (var point in points)
                {
                    grid[point] += 1;
                }
            }

            return grid.Count(x => x.Value > 1);        }

        public override List<Line> PreprocessData(string[] puzzleInput)
        {
            var result = new List<Line>();
            foreach (var lineWithCoords in puzzleInput)
            {
                var coords = lineWithCoords.Split(" -> ");
                var coord1 = coords[0].Split(',').Select(int.Parse).ToArray();
                var coord2 = coords[1].Split(',').Select(int.Parse).ToArray();
                result.Add(new Line
                {
                    Coord1 = (coord1[0], coord1[1]),
                    Coord2 = (coord2[0], coord2[1])
                });
            }

            return result;
        }
    }

}
