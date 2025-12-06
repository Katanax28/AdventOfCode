public static class DaySixPartTwo2025
{
    public static long Solve()
    {
        long total = 0;
        List<string> lines = File.ReadAllLines("./2025/day_6/input.txt").ToList();
        List<string> operationArray = lines[^1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        string currentOperation = operationArray[^1];
        
        long currentTotal = 0;
        List<int> numberList = [];
        
        for (int i = lines[0].Length - 1; i >= -1; i--)
        {
            if (i == -1 || lines.All(l => l[i] == ' '))
            {
                if (currentOperation == "*")
                {
                    currentTotal = 1;
                    foreach (int number in numberList)
                    {
                        currentTotal *= number;
                    }
                }
                else
                {
                    foreach (int number in numberList)
                    {
                        currentTotal += number;
                    }
                }
                total += currentTotal;
                if (i == -1) break;
                
                operationArray.RemoveAt(operationArray.Count - 1);
                currentOperation = operationArray[^1];
                currentTotal = 0;
                numberList = [];
                continue;
            }

            string numberAsString = "";
            foreach (string line in lines.SkipLast(1))
            {
                numberAsString += line[i];
            }
            int num = int.Parse(numberAsString.Trim());
            numberList.Add(num);
        }
        return total;
    }
}