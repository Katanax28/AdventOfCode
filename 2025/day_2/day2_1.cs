public static class day2_1 {
    public static long Solve()
    {
        var ranges = File.ReadAllText("./2025/day_2/input.txt").Split(',');
        long result = 0;
        foreach (var range in ranges)
        {
            long firstNumber = long.Parse(range.Split('-')[0]);
            long lastNumber = long.Parse(range.Split('-')[1]);
            
            for (long i = firstNumber; i <= lastNumber; i++)
            {
                string number = i.ToString();
                if (number.Substring(0, number.Length / 2) == number.Substring(number.Length / 2)) result += i;
            }
        }
        return result;
    }
}