using System;
Console.WriteLine("First run of the command is always slower, so here a first 'warmup' solution:");
WriteSolution(DayOnePartOne2025.Solve, 1, 1);

Console.WriteLine("2025:");
WriteSolution(DayOnePartOne2025.Solve, 1, 1);
WriteSolution(DayOnePartTwo2025.Solve, 1, 2);
WriteSolution(DayTwoPartOne2025.Solve, 2, 1);
WriteSolution(DayTwoPartTwo2025.Solve, 2, 2);
WriteSolution(DayThreePartOne2025.Solve, 3, 1);
WriteSolution(DayThreePartTwo2025.Solve, 3, 2);
WriteSolution(DayFourPartOne2025.Solve, 4, 1);
WriteSolution(DayFourPartTwo2025.Solve, 4, 2);
WriteSolution(DayFivePartOne2025.Solve, 5, 1);
WriteSolution(DayFivePartTwo2025.Solve, 5, 2);


return;

void WriteSolution<T>(Func<T> func,  int day, int puzzle)
{
    var w = System.Diagnostics.Stopwatch.StartNew();
    T solution = func.Invoke();
    w.Stop();
    Console.WriteLine($"Solution of day {day}-{puzzle}: {solution} (took {w.ElapsedMilliseconds} ms)");
}