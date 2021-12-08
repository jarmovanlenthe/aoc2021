using System.Collections.Generic;
using System.Linq;

namespace Challenges.Days
{
    public class Day04 : Day<Day04.Game, int>
    {
        public class Number
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool Marked { get; set; }
            public int Value { get; set; }
        }

        public class Board
        {
            public Number[] Numbers { get; set; }

            public bool hasWinner()
            {
                for (var i = 0; i < 5; i++)
                {
                    if (Numbers.Count(x => x.X == i && x.Marked) == 5 || Numbers.Count(x => x.Y == i && x.Marked) == 5)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public class Game
        {
            public int _atNumber;
            public int[] NumbersToDraw { get; set; }
            public Board[] Boards { get; set; }

            public IEnumerable<Board> WonGames
            {
                get
                {
                    return Boards.Where(x => x.hasWinner());
                }
            }

            public void DrawNumber()
            {
                foreach (var num in Boards.SelectMany(board =>
                    board.Numbers.Where(num => num.Value == NumbersToDraw[_atNumber])))
                {
                    num.Marked = true;
                }

                _atNumber++;
            }
        }

        public override int Part1(Game puzzleInput)
        {
            while (!puzzleInput.WonGames.Any())
            {
                puzzleInput.DrawNumber();
            }

            var maxScore = puzzleInput.WonGames.Select(board => board.Numbers.Where(n => n.Marked == false).Sum(x => x.Value)).Max();
            return maxScore * puzzleInput.NumbersToDraw[puzzleInput._atNumber - 1];
        }

        public override int Part2(Game puzzleInput)
        {
            while (puzzleInput.WonGames.Count() + 1 != puzzleInput.Boards.Length)
            {
                puzzleInput.DrawNumber();
            }

            var lastBoard = puzzleInput.Boards.Single(b => !b.hasWinner());

            while (!lastBoard.hasWinner())
            {
                puzzleInput.DrawNumber();
            }

            var score = lastBoard.Numbers.Where(n => n.Marked == false).Sum(n => n.Value);
            return score * puzzleInput.NumbersToDraw[puzzleInput._atNumber - 1];
        }

        public override Game PreprocessData(string[] puzzleInput)
        {
            var game = new Game
            {
                NumbersToDraw = puzzleInput[0].Split(',').Select(int.Parse).ToArray(),
            };
            var boards = new List<Board>();
            var i = 2;
            while (i < puzzleInput.Length)
            {
                var nums = new List<Number>();
                for (var j = 0; j < 5; j++)
                {
                    var x = 0;
                    foreach (var s in puzzleInput[i+j].Trim().Replace("  ", " ").Split(' '))
                    {
                        nums.Add(new Number
                        {
                            Value = int.Parse(s),
                            X = j,
                            Y = x
                        });
                        x += 1;
                    }
                }
                boards.Add(new Board
                {
                    Numbers = nums.ToArray()
                });
                i += 6;

            }

            game.Boards = boards.ToArray();
            return game;
        }
    }
}
