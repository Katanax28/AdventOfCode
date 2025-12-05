public static class DayFivePartOne2025
{
    public static int Solve()
    {
        string[] lines = File.ReadAllLines("./2025/day_5/input.txt");
        List<string> linesList = lines.ToList();
        List<string> freshIngredientLists = linesList.FindAll(x => x.Contains('-'));
        long parsed = 0;
        IEnumerable<(long, bool)> ingredientIds = linesList.FindAll(x => !x.Contains('-'))
            .Select(x => long.TryParse(x, out parsed)).Select(x => (parsed, false));

        List<(long, long)> freshIngredientRanges = [];
        foreach (var freshIngredientList in freshIngredientLists)
        {
            long firstItemInList = long.Parse(freshIngredientList.Remove(freshIngredientList.IndexOf('-')));
            long lastItemInList = long.Parse(freshIngredientList.Substring(freshIngredientList.IndexOf('-') + 1));
            freshIngredientRanges.Add((firstItemInList, lastItemInList));
        }

        int freshIngredientsCount = 0;
        var ingredients = ingredientIds.ToArray();
        for (int i = 0; i < ingredients.Length; i++)
        {
            var ingredient = ingredients[i];
            foreach (var freshIngredientRange in freshIngredientRanges)
            {
                if (!ingredient.Item2 && freshIngredientRange.Item1 <= ingredient.Item1 && freshIngredientRange.Item2 >= ingredient.Item1)
                {
                    freshIngredientsCount++;
                    ingredients[i] = (ingredients[i].Item1, true);
                    break;
                }
            }
        }
        return freshIngredientsCount;
    }
}

// 913 too high