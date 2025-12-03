public class day3_1
{
    public static int Solve()
    {
        var batteryBanks = File.ReadAllLines("./2025/day_3/input.txt");
        int totalJoltage = 0;
        foreach (var batteryBank in batteryBanks)
        {
            int firstBattery = 0;
            int secondBattery = 0;
            for(int index = 0; index < batteryBank.Length; index++)
            {
                var battery = batteryBank[index];
                int batteryLevel = battery - '0';
                if (firstBattery == 0) 
                {
                    firstBattery = batteryLevel;
                    continue;
                }
                if (secondBattery == 0) 
                {
                    secondBattery = batteryLevel;
                    continue;
                }

                if (batteryLevel < firstBattery && batteryLevel < secondBattery) continue;
                if (index + 1 < batteryBank.Length && batteryLevel > firstBattery)
                {
                    firstBattery = batteryLevel;
                    secondBattery = batteryBank[index + 1] - '0';
                    index++;
                }
                else if (firstBattery >= secondBattery) secondBattery = batteryLevel;
                else
                {
                    int temp = secondBattery;
                    secondBattery = batteryLevel;
                    firstBattery = temp;
                }
                Console.WriteLine($"{firstBattery}, {secondBattery}");
                
            }

            totalJoltage += 10 * firstBattery + secondBattery;
        }
        return totalJoltage;
    }
}

// 16886 too low

// 16907 too high
