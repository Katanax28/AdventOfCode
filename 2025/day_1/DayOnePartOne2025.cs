public static class DayOnePartOne2025 {
    public static int Solve()
    {
        var lines = File.ReadAllLines("./2025/day_1/input.txt");
        int dial = 50;
        int result = 0;
        foreach (var line in lines)
        {
            int rotations = int.Parse(line.AsSpan(1));
            dial = line[0] == 'R' ? (dial + rotations) % 100 : (dial - rotations + 1000) % 100;
            if (dial == 0) result++;
        }
        return result;
    }
}