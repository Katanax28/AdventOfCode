using System;
Console.WriteLine("First run of the command is always slower, so here a first 'warmup' solution:");
WriteSolution(day1_1.Solve, 1, 1);

Console.WriteLine("2025:");
WriteSolution(day1_1.Solve, 1, 1);
WriteSolution(day1_2.Solve, 1, 2);
WriteSolution(day2_1.Solve, 2, 1);
WriteSolution(day2_2.Solve, 2, 2);
return;

void WriteSolution<T>(Func<T> func,  int day, int puzzle)
{
    var w = System.Diagnostics.Stopwatch.StartNew();
    T solution = func.Invoke();
    w.Stop();
    Console.WriteLine($"Solution of day {day}-{puzzle}: {solution} (took {w.ElapsedMilliseconds} ms)");
}