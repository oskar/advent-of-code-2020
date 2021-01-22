namespace advent_of_code_2020
{
    public class Day3 : IDay
    {
        public long PartOne(string[] input)
        {
            return Traverse(3, 1, input);
        }

        public long PartTwo(string[] input)
        {
            var trees1 = Traverse(1, 1, input);
            var trees2 = Traverse(3, 1, input);
            var trees3 = Traverse(5, 1, input);
            var trees4 = Traverse(7, 1, input);
            var trees5 = Traverse(1, 2, input);

            return trees1 * trees2 * trees3 * trees4 * trees5;
        }

        private static long Traverse(int right, int down, string[] input)
        {
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

            return trees;
        }
    }
}