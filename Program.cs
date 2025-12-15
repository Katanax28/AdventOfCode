int puzzleCount = 0;
Console.WriteLine("First run of the command is always slower, so here a first 'warmup' solution:");
WriteSolution(DayOnePartOne2025.Solve);

Console.WriteLine("2025:");
WriteSolution(DayOnePartOne2025.Solve);
WriteSolution(DayOnePartTwo2025.Solve);
WriteSolution(DayTwoPartOne2025.Solve);
WriteSolution(DayTwoPartTwo2025.Solve);
WriteSolution(DayThreePartOne2025.Solve);
WriteSolution(DayThreePartTwo2025.Solve);
WriteSolution(DayFourPartOne2025.Solve);
WriteSolution(DayFourPartTwo2025.Solve);
WriteSolution(DayFivePartOne2025.Solve);
WriteSolution(DayFivePartTwo2025.Solve);
WriteSolution(DaySixPartOne2025.Solve);
WriteSolution(DaySixPartTwo2025.Solve);
WriteSolution(DaySevenPartOne2025.Solve);
WriteSolution(DaySevenPartTwo2025.Solve);
WriteSolution(DayEightPartOne2025.Solve);
WriteSolution(DayEightPartTwo2025.Solve);
WriteSolution(DayNinePartOne2025.Solve);
WriteSolution(DayNinePartTwo2025.Solve);

return;

void WriteSolution<T>(Func<T> func)
{
    var w = System.Diagnostics.Stopwatch.StartNew();
    T solution = func.Invoke();
    w.Stop();
    Console.WriteLine($"Solution of day {(puzzleCount + 2) / 2 }-{puzzleCount % 2 + 1}: {solution} (took {w.ElapsedMilliseconds} ms)");
    puzzleCount++;
}