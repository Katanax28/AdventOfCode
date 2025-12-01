Console.WriteLine("2025:");
WriteSolution(day1_1.Solve, 1, 1);
WriteSolution(day1_2.Solve, 1, 2);
return;

void WriteSolution(Func<int> func,  int day, int puzzle)
{
    var w = System.Diagnostics.Stopwatch.StartNew();
    int solution = func.Invoke();
    w.Stop();
    Console.WriteLine($"Solution of day {day}-{puzzle}: {solution} (took {w.ElapsedMilliseconds} ms)");
}