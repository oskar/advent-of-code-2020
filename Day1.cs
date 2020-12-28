using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_of_code_2020
{
    public class Day1 : IDay
    {
        public void Run(string[] input)
        {
            var numbers = input.Select(l => Convert.ToInt32(l)).ToList();
            Part1(numbers);
            Part2(numbers);
        }

        private static void Part1(IReadOnlyList<int> numbers)
        {
            Console.WriteLine("Part 1");
            for (var i = 0; i < numbers.Count; i++)
            {
                var first = numbers[i];
                for (var j = i + 1; j < numbers.Count; j++)
                {
                    var second = numbers[j];
                    if (first + second == 2020)
                    {
                        Console.WriteLine($"First number: {first} (at index {i})");
                        Console.WriteLine($"Second number: {second} (at index {j})");
                        Console.WriteLine($"Product: {first * second}");
                        return;
                    }
                }
            }
        }

        private static void Part2(IReadOnlyList<int> numbers)
        {
            Console.WriteLine("Part 2");
            for (var i = 0; i < numbers.Count; i++)
            {
                var first = numbers[i];
                for (var j = i + 1; j < numbers.Count; j++)
                {
                    var second = numbers[j];
                    for (var k = j + 1; k < numbers.Count; k++)
                    {
                        var third = numbers[k];
                        if (first + second + third == 2020)
                        {
                            Console.WriteLine($"First number: {first} (at index {i})");
                            Console.WriteLine($"Second number: {second} (at index {j})");
                            Console.WriteLine($"Third number: {third} (at index {k})");
                            Console.WriteLine($"Product: {first * second * third}");
                            return;
                        }
                    }
                }
            }
        }
    }
}