using System;

namespace advent_of_code_2020
{
    public class Day3 : IDay
    {
        public void Run(string[] input)
        {
            Console.WriteLine("Part 1");
            Traverse(3, 1);

            Console.WriteLine("Part 2");
            var trees1 = Traverse(1, 1);
            var trees2 = Traverse(3, 1);
            var trees3 = Traverse(5, 1);
            var trees4 = Traverse(7, 1);
            var trees5 = Traverse(1, 2);
            Console.WriteLine($"Product: {trees1 * trees2 * trees3 * trees4 * trees5}");

            long Traverse(int right, int down)
            {
                Console.WriteLine($"Slope: ({right}, {down})");

                var column = 0;
                var row = 0;
                var trees = 0;

                while (row < input.Length - 1)
                {
                    column += right;
                    row += down;

                    var line = input[row];
                    if (line[column % line.Length] == '#')
                    {
                        trees++;
                    }
                }

                Console.WriteLine($"Trees: {trees}");
                return trees;
            }
        }
    }
}
