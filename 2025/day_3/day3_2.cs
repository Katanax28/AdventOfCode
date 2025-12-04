public class day3_2
{
    public static long Solve()
    {
        var batteryBanks = File.ReadAllLines("./2025/day_3/input.txt");
        long totalJoltage = 0;
        foreach (var batteryBank in batteryBanks)
        {
            string bank = batteryBank;
            int batteriesNeeded = 12;
            while (batteriesNeeded > 0)
            {
                string loadingBank = bank.Remove(bank.Length - (batteriesNeeded - 1));
                var max = loadingBank.Max();
                totalJoltage += (long)Math.Round((max - '0') * (Math.Pow(10, batteriesNeeded) / 10));
                batteriesNeeded--;
                bank = bank.Substring(bank.IndexOf(max) + 1);
            }
        }
        return totalJoltage;
    }
}