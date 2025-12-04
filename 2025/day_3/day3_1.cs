public class day3_1
{
    public static int Solve()
    {
        var batteryBanks = File.ReadAllLines("./2025/day_3/input.txt");
        int totalJoltage = 0;
        foreach (var bank in batteryBanks)
        {
            char highest = bank.Max();
            if (bank.IndexOf(highest) == bank.Length - 1) totalJoltage += highest - '0' + (bank.Remove(bank.Length - 1).Max() - '0') * 10;
            else totalJoltage += (highest - '0') * 10 + bank.Substring(bank.IndexOf(highest) + 1).Max() - '0';
        }
        return totalJoltage;
    }
}