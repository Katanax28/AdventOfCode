public static class DaySixPartOne2025
{
    public static long Solve()
    {
        string[] lines = File.ReadAllLines("./2025/day_6/input.txt");
        long total = 0;
        List<int[]> linesAsIntArray = [];
        for (int i = 0; i < lines.Length - 1; i++)
        {
            string line = lines[i];
            string[] lineAsStringArray = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] lineAsIntArray = Array.ConvertAll(lineAsStringArray, int.Parse);
            linesAsIntArray.Add(lineAsIntArray);
        }
        string[] operationArray = lines[^1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < linesAsIntArray[0].Length; i++)
        {
            bool doesMultiply = operationArray[i] == "*";
            long currentEquationResult = linesAsIntArray[0][i];
            foreach (var row in linesAsIntArray.Skip(1))
            {
                if (doesMultiply) currentEquationResult *= row[i];
                else currentEquationResult += row[i];
            }
            total += currentEquationResult;
        }
        return total;
    }
}

// 913 too high