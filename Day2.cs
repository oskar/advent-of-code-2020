using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace advent_of_code_2020
{
    public class Day2 : IDay
    {
        private readonly Regex _linePattern = new(@"^(\d*)-(\d*) (\w): (\w*)$");

        public void Run(string inputFile)
        {
            var lines = File.ReadAllLines(inputFile);
            Console.WriteLine($"Found {lines.Length} lines in {inputFile}");

            var parsedLines = lines.Select(Parse).ToList();

            Console.WriteLine("Part 1");
            var count = parsedLines.Count(l => IsValidPart1(l.First, l.Second, l.Character, l.Password));
            Console.WriteLine($"Valid passwords: {count}");

            Console.WriteLine("Part 2");
            count = parsedLines.Count(l => IsValidPart2(l.First, l.Second, l.Character, l.Password));
            Console.WriteLine($"Valid passwords: {count}");
        }

        private (int First, int Second, char Character, string Password) Parse(string line)
        {
            var match = _linePattern.Match(line);
            return (int.Parse(match.Groups[1].Value),
                int.Parse(match.Groups[2].Value),
                char.Parse(match.Groups[3].Value),
                match.Groups[4].Value);
        }

        private static bool IsValidPart1(int lowerBound, int upperBound, char character, string password)
        {
            var count = 0;
            foreach (var chr in password)
            {
                if (chr == character) count++;
                if (count > upperBound)
                    return false;
            }

            return count >= lowerBound;
        }

        private static bool IsValidPart2(int firstPosition, int secondPosition, char character, string password)
            => character == password[firstPosition - 1] ^ character == password[secondPosition - 1];
    }
}