using System;
using System.Collections.Generic;
using System.IO;

namespace Challenges.Days
{
    public abstract class Day<T, V> : IDay<T, V>
    {
        protected T? PuzzleInput;
        public int DayNumber { get; set; }

        public void Start()
        {
            Console.WriteLine($"---    Day {DayNumber:00}     ---");
            PuzzleInput = PreprocessData(GetInput());
            Console.WriteLine("--- Puzzle Output ---");
            Console.Write("Part 1 solution: ");
            Console.WriteLine($"{Part1(PuzzleInput)}");
            PuzzleInput = PreprocessData(GetInput());
            Console.Write("Part 2 solution: ");
            Console.WriteLine($"{Part2(PuzzleInput)}");
        }
        private string[] GetInput()
        {
            return File.ReadAllLines($"Input/{DayNumber:00}.txt");
        }

        public abstract V Part1(T puzzleInput);
        public abstract V Part2(T puzzleInput);
        public abstract T PreprocessData(string[] puzzleInput);
    }
}
