using System;
using System.Linq;

namespace advent_of_code_2020
{
    public class Day1 : IDay
    {
        public long PartOne(string[] input)
        {
            var numbers = input.Select(l => Convert.ToInt32(l)).ToList();
            for (var i = 0; i < numbers.Count; i++)
            {
                var first = numbers[i];
                for (var j = i + 1; j < numbers.Count; j++)
                {
                    var second = numbers[j];
                    if (first + second == 2020)
                    {
                        return first * second;
                    }
                }
            }

            throw new Exception("Number not found");
        }

        public long PartTwo(string[] input)
        {
            var numbers = input.Select(l => Convert.ToInt32(l)).ToList();
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
                            return first * second * third;
                        }
                    }
                }
            }

            throw new Exception("Number not found");
        }
    }
}