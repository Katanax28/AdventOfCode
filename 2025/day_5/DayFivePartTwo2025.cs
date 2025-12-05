public class DayFivePartTwo2025
{
    public static long Solve()
    {
        string[] rangesAsStrings = File.ReadAllLines("./2025/day_5/input.txt").Where(x => x.Contains('-')).ToArray();
        long totalItems = 0;
        List<(long, long)> rangesAsTuples = [];
        foreach (var range in rangesAsStrings)
        {
            long firstItemInList = long.Parse(range.Remove(range.IndexOf('-')));
            long lastItemInList = long.Parse(range.Substring(range.IndexOf('-') + 1));
            rangesAsTuples.Add((firstItemInList, lastItemInList));
        }
        
        rangesAsTuples.Sort(); // idk why but this line fixed everything lol

        for (int i = 0; i < rangesAsTuples.Count; i++)
        {
            for (int j = 0; j < rangesAsTuples.Count && i < rangesAsTuples.Count; j++)
            {
                if(i == j) continue;
                if (rangesAsTuples[i].Item1 >= rangesAsTuples[j].Item1 &&
                    rangesAsTuples[i].Item1 <= rangesAsTuples[j].Item2 ||
                    rangesAsTuples[i].Item2 >= rangesAsTuples[j].Item1 &&
                    rangesAsTuples[i].Item2 <= rangesAsTuples[j].Item2)
                {
                    rangesAsTuples[i] = (Math.Min(rangesAsTuples[i].Item1, rangesAsTuples[j].Item1),
                        Math.Max(rangesAsTuples[i].Item2, rangesAsTuples[j].Item2));
                    rangesAsTuples.RemoveAt(j);
                    j--;
                }
            }
        }

        foreach (var range in rangesAsTuples)
        {
            totalItems += range.Item2 - range.Item1 + 1;
        }

        return totalItems;
    }
}