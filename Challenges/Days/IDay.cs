using System.Collections.Generic;

namespace Challenges.Days
{
    public interface IDay<T, V> : IStartable
    {
        public V Part1(T puzzleInput);
        public V Part2(T puzzleInput);
        public abstract T PreprocessData(string[] puzzleInput);
    }
}
