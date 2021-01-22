using System.Collections.Generic;
using System.Linq;

namespace advent_of_code_2020
{
    public class Day6 : IDay
    {
        public long PartOne(string[] input)
            => GetGroupsPart1(input).Select(g => g.Count).Sum();

        public long PartTwo(string[] input)
            => GetGroupsPart2(input).Select(g => g.Count).Sum();

        private static IEnumerable<HashSet<char>> GetGroupsPart1(string[] input)
        {
            var group = new HashSet<char>();
            foreach (var line in input)
            {
                if (line == "")
                {
                    yield return group;
                    group = new HashSet<char>();
                }
                else
                {
                    group.UnionWith(line.ToHashSet());
                }
            }

            if (group.Count > 0)
            {
                yield return group;
            }
        }

        private static IEnumerable<HashSet<char>> GetGroupsPart2(string[] input)
        {
            HashSet<char> group = null;
            foreach (var line in input)
            {
                if (line == "")
                {
                    yield return group;
                    group = null;
                }
                else
                {
                    if (group == null)
                    {
                        group = line.ToHashSet();
                    }
                    else
                    {
                        group.IntersectWith(line.ToHashSet());
                    }
                }
            }

            if (group?.Count > 0)
            {
                yield return group;
            }
        }
    }
}