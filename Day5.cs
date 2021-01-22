using System;
using System.Linq;

namespace advent_of_code_2020
{
    public class Day5 : IDay
    {
        public long PartOne(string[] input)
        {
            return input.Select(GetSeatId1).Max();
        }

        public long PartTwo(string[] input)
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

        private static int GetSeatId1(string boardingPass)
            => Convert.ToInt32(string.Concat(boardingPass.Select(c => c is 'F' or 'L' ? '0' : '1')), 2);

        private static int GetSeatId2(string boardingPass) => boardingPass
            .Select(c => c is 'F' or 'L' ? 0 : 1)
            .Select((bit, i) => bit << boardingPass.Length - i - 1)
            .Sum();
    }
}