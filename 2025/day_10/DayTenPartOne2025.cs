public class DayTenPartOne2025
{
    public static long Solve()
    {
        string[] lines = File.ReadAllLines("./2025/day_10/input.txt");
        int result = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            var charsToRemove = new []{ "(", ")", "[", "]", "{", "}" };
            for (var index = 0; index < charsToRemove.Length; index++)
            {
                var c = charsToRemove[index];
                line = line.Replace(c, string.Empty);
            }

            string[] parts = line.Split(" ");
            var lights = parts[0];
            uint targetLights = 0;
            for (var j = 0; j < lights.Length; j++)
            {
                var c = lights[j];
                if (c == '#')
                {
                    targetLights += (uint)Math.Pow(2, j);
                }
            }

            string[] buttonsAsStrings = parts.Skip(1).SkipLast(1).ToArray();
            uint[] buttons = new uint[buttonsAsStrings.Length];
            for (int j = 0; j < buttonsAsStrings.Length; j++)
            {
                uint button = 0;
                int[] curr = buttonsAsStrings[j].Split(',').Select(int.Parse).ToArray();
                foreach (var num in curr)
                {
                    button += (uint)Math.Pow(2, num);
                }
                buttons[j] = button;
            }

            int lowestButtonPressCount = buttons.Length; // originally assume all buttons need to be pressed.
            for(uint j = 1; j < Math.Pow(2, buttons.Length); j++)
            {
                uint currentLights = 0;
                uint buttonsToPress = j;
                int currentIteration = 0;
                while (buttonsToPress != 0)
                {
                    if ((buttonsToPress & 1) == 1) currentLights ^= buttons[currentIteration];
                    buttonsToPress >>= 1;
                    currentIteration++;
                }

                int countedBits = CountBits(j);
                if (currentLights == targetLights && countedBits < lowestButtonPressCount) lowestButtonPressCount = countedBits;
            }
            Console.WriteLine(lowestButtonPressCount);
            result += lowestButtonPressCount;
        }
        
        return result;
    }

    private static int CountBits(uint value)
    {
        int count = 0;
        while (value != 0)
        {
            count++;
            value &= value - 1;
        }
        return count;
    }
}