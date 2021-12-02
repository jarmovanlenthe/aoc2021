using System.Linq;

namespace Challenges.Days
{
    public class Day02 : Day<Day02.Instruction[], int>
    {
        public struct Instruction
        {
            public string Direction;
            public int Amount;
        }

        public override int Part1(Instruction[] puzzleInput)
        {
            return puzzleInput.Where(x => x.Direction == "forward").Select(x => x.Amount).Sum() *
                   ( puzzleInput.Where(x => x.Direction == "down").Select(x => x.Amount).Sum() -
                     puzzleInput.Where(x => x.Direction == "up").Select(x => x.Amount).Sum());
        }

        public override int Part2(Instruction[] puzzleInput)
        {
            var aim = 0;
            var forwardPosition = 0;
            var depth = 0;
            foreach (var instruction in puzzleInput)
            {
                switch (instruction.Direction)
                {
                    case "down":
                        aim += instruction.Amount;
                        break;
                    case "up":
                        aim -= instruction.Amount;
                        break;
                    case "forward":
                        forwardPosition += instruction.Amount;
                        depth += aim * instruction.Amount;
                        break;
                }
            }

            return forwardPosition * depth;
        }

        public override Instruction[] PreprocessData(string[] puzzleInput)
        {
            return puzzleInput.Select(x => new Instruction
            {
                Direction = x.Split(' ').First(),
                Amount = int.Parse(x.Split(' ').Last())
            }).ToArray();
        }
    }
}
