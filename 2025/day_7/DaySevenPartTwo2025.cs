public static class DaySevenPartTwo2025
{
    private static readonly char[][] Grid = File.ReadAllLines("./2025/day_7/input.txt").Select(item => item.ToArray()).ToArray();
    
    public static long Solve()
    {
        int arrayWidth = Grid[0].Length;
        long[] timeLineCount = new long[arrayWidth];
        int index = Array.FindIndex(Grid[0], x => x == 'S');
        timeLineCount[index] = 1;
        for (int y = 1; y < Grid.Length; y++)
        {
            long[] nextTimeLineCount = new long[arrayWidth];
            for (int x = 0; x < arrayWidth; x++)
            {
                if (Grid[y][x] == '^')
                {
                    nextTimeLineCount[x - 1] += timeLineCount[x];
                    nextTimeLineCount[x + 1] += timeLineCount[x];
                }

                if (Grid[y][x] == '.') nextTimeLineCount[x] += timeLineCount[x];
            }
            timeLineCount = nextTimeLineCount;
        }
        return timeLineCount.Sum();
    }
}