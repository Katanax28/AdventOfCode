public static class DayNinePartOne2025
{
    public static long Solve()
    {
        string[] lines = File.ReadAllLines("./2025/day_9/input.txt");

        List<(int, int)> coords = [];
        foreach (var line in lines)
        {
            string[] splitLine = line.Split(',');
            int x = int.Parse(splitLine[0]);
            int y = int.Parse(splitLine[1]);
            coords.Add((x, y));
        }

        long biggestSize = 0;
        for (int i = 0; i < coords.Count; i++)
        {
            for (int j = i + 1; j < coords.Count; j++)
            {
                long thisSize = ((long)Math.Abs(coords[i].Item1 - coords[j].Item1) + 1) * ((long)Math.Abs(coords[i].Item2 - coords[j].Item2) + 1);
                if (thisSize <= biggestSize) continue;
                biggestSize = thisSize;
            }
        }

        return biggestSize;
    }
}
// 4776487744
// 2147423298 is too low