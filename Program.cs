using System;
using System.IO;
using System.Linq;

namespace advent_of_code_2020
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 1 || !int.TryParse(args[0], out var dayNumber) || dayNumber < 1 || dayNumber > 25)
            {
                Console.WriteLine("Specify day between 1 and 25");
                return;
            }

            var day = GetDay(dayNumber);
            if (day == null)
            {
                Console.WriteLine($"Day {dayNumber} is not implemented");
                return;
            }

            var input = GetInput(dayNumber);
            if (input == null)
            {
                Console.WriteLine($"Input for day {dayNumber} not found");
            }

            Console.WriteLine($"Day {dayNumber} part 1: {day.PartOne(input)}");
            Console.WriteLine($"Day {dayNumber} part 2: {day.PartTwo(input)}");
        }

        private static string[] GetInput(int dayNumber)
        {
            var fileName = $"Day{dayNumber}.input";
            return File.Exists(fileName) ? File.ReadAllLines(fileName) : null;
        }

        private static IDay GetDay(int dayNumber)
        {
            var type = typeof(Program).Assembly
                .GetTypes()
                .Where(t => typeof(IDay).IsAssignableFrom(t) && t.IsClass)
                .FirstOrDefault(t => t.Name == "Day" + dayNumber);
            return type != null ? (IDay) Activator.CreateInstance(type) : null;
        }
    }
}
