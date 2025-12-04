public static class day2_2
{
    public static long Solve()
    {
        var ranges = File.ReadAllText("./2025/day_2/input.txt").Split(',');
        long result = 0;
        foreach (var range in ranges)
        {
            long firstNumber = Int64.Parse(range.Split('-')[0]);
            long lastNumber = Int64.Parse(range.Split('-')[1]);

            for (long i = firstNumber; i <= lastNumber; i++) // iterate through every number in the range
            {
                string number = i.ToString();
                // try and splice the string in equal chunks. Max number length is 10 digits according to my sample input
                for (int chunkCount = 2; chunkCount <= 10; chunkCount++)
                {
                    int numberLength = number.Length;
                    if (numberLength % chunkCount != 0) continue; // if the string cannot be split up into this amount of equal chunks, it should continue to the next chunkCount.
                    string[] comparisonArray = new string[chunkCount];
                    for (int j = 0; j < chunkCount; j++)
                    {
                        comparisonArray[j] = number.Substring(j * (numberLength / chunkCount), numberLength / chunkCount);
                    }

                    if (comparisonArray.Any(o => o != comparisonArray[0])) continue; // if any of the chunks do not match the first, try the next chunkCount.
                    result += i; // if all the chunks are the same, add the entire number to the result
                    break;
                }
            }
        }
        return result;
    }
}