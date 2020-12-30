using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_of_code_2020
{
    public class Day5 : IDay
    {
        public void Run(string[] input)
        {
            Console.WriteLine("Part 1");
            Console.WriteLine(
                $"Highest seat ID (char[] -> string -> two-base integer): {input.Select(GetSeatId1).Max()}");
            Console.WriteLine(
                $"Highest seat ID (bit-shifting): {input.Select(GetSeatId2).Max()}");

            Console.WriteLine("Part 2");
            Console.WriteLine($"My seat ID (LINQ): {GetMissingSeatId1(input)}");
            Console.WriteLine($"My seat ID (foreach): {GetMissingSeatId2(input)}");
        }

        private static int GetSeatId1(string boardingPass)
            => Convert.ToInt32(string.Concat(boardingPass.Select(c => c is 'F' or 'L' ? '0' : '1')), 2);

        private static int GetSeatId2(string boardingPass) => boardingPass
            .Select(c => c is 'F' or 'L' ? 0 : 1)
            .Select((bit, i) => bit << boardingPass.Length - i - 1)
            .Sum();

        private static int GetMissingSeatId1(IEnumerable<string> input)
        {
            var seatIds = input.Select(GetSeatId1).ToList();
            var min = seatIds.Min();
            var max = seatIds.Max();
            var sum = seatIds.Sum();
            var arithmeticSeriesSum = (min + max) * (max - min + 1) / 2;
            return arithmeticSeriesSum - sum;
        }

        private static int GetMissingSeatId2(IEnumerable<string> input)
        {
            int min = int.MaxValue, max = 0, sum = 0;
            foreach (var seatId in input.Select(GetSeatId1))
            {
                min = seatId < min ? seatId : min;
                max = seatId > max ? seatId : max;
                sum += seatId;
            }

            var arithmeticSeriesSum = (min + max) * (max - min + 1) / 2;
            return arithmeticSeriesSum - sum;
        }
    }
}
