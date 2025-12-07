public static class DaySevenPartOne2025
{
    public static int Solve()
    {
        int result = 0;
        char[][] grid = File.ReadAllLines("./2025/day_7/input.txt").Select(item => item.ToArray()).ToArray();
        for (int y = 1; y < grid.Length; y++) // skip first row
        {
            for (int x = 0; x < grid[y].Length; x++)
            {
                if (grid[y - 1][x] == '|' || grid[y - 1][x] == 'S')
                {
                    if (grid[y][x] == '.') grid[y][x] = '|';
                    if (grid[y][x] == '^')
                    {
                        grid[y][x - 1] = '|';
                        grid[y][x + 1] = '|';
                        result++;
                    }
                }
            }
        }
        return result;
    }
}