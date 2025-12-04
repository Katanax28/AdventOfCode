public static class DayOnePartTwo2025
{
    public static int Solve()
    {
        var lines = File.ReadAllLines("./2025/day_1/input.txt");
        int dial = 50;
        int result = 0;
        foreach (var line in lines)
        {
            int rotations = int.Parse(line.AsSpan(1));
            if (line[0] == 'R')
            {
                dial += rotations;
                result += dial / 100;
                dial %= 100;
            }
            else
            {
                int target = dial == 0 ? 100 : dial;
                if (rotations >= target) result += 1 + (rotations - target) / 100;
                dial = (dial - rotations + 1000) % 100;
            }
        }

        return result;
    }
}