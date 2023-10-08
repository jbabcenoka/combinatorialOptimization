using System.Diagnostics;

namespace CombinatorialOptimization;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        var visitIndex = 0;
        var visits = new List<VisitTime>
        {
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 07:00"), DateTime.Parse("2023-10-01 08:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 07:00"), DateTime.Parse("2023-10-01 08:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 08:00"), DateTime.Parse("2023-10-01 10:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 08:00"), DateTime.Parse("2023-10-01 10:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 09:00"), DateTime.Parse("2023-10-01 12:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 10:00"), DateTime.Parse("2023-10-01 12:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 11:00"), DateTime.Parse("2023-10-01 13:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 11:00"), DateTime.Parse("2023-10-01 15:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:00"), DateTime.Parse("2023-10-01 13:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 13:00"), DateTime.Parse("2023-10-01 14:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 14:00"), DateTime.Parse("2023-10-01 16:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 14:00"), DateTime.Parse("2023-10-01 16:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:00"), DateTime.Parse("2023-10-01 17:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 16:00"), DateTime.Parse("2023-10-01 19:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 16:00"), DateTime.Parse("2023-10-01 19:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 16:00"), DateTime.Parse("2023-10-01 17:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 17:00"), DateTime.Parse("2023-10-01 18:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 18:00"), DateTime.Parse("2023-10-01 20:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 19:00"), DateTime.Parse("2023-10-01 19:30")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 22:00"), DateTime.Parse("2023-10-01 23:00")),
        };

        var workersCount = 2;

        var optimizator = new Optimizator.Optimizator(visits, workersCount);
        var firstFit = optimizator.GenerateInitialSolution();
        firstFit.PrintSolution();

        var simulatedAnealing = optimizator.SimulatedAnnealing();
        simulatedAnealing.PrintSolution();

        stopwatch.Stop();

        TimeSpan elapsedTime = stopwatch.Elapsed;
        Console.WriteLine($"\nElapsed Time: {elapsedTime}");
    }
}