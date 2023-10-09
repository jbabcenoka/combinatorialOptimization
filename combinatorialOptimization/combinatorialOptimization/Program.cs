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
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:00"), DateTime.Parse("2023-10-01 16:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:00"), DateTime.Parse("2023-10-01 16:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:00"), DateTime.Parse("2023-10-01 16:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:00"), DateTime.Parse("2023-10-01 16:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:10"), DateTime.Parse("2023-10-01 16:30")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 16:10"), DateTime.Parse("2023-10-01 18:00")),
            new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 16:10"), DateTime.Parse("2023-10-01 18:00")),
            new VisitTime(visitIndex, DateTime.Parse("2023-10-01 16:10"), DateTime.Parse("2023-10-01 18:00")),
          };

        var workerIndex = 0;
        var workers = new Dictionary<int, int>();
        workers.Add(workerIndex++, 10);
        workers.Add(workerIndex++, 10);
        workers.Add(workerIndex, 4);

        var optimizator = new Optimizator.Optimizator(visits, workers);
        var firstFit = optimizator.GenerateInitialSolution();
        firstFit.PrintSolution();

        var simulatedAnnealing = optimizator.SimulatedAnnealing(firstFit);
        simulatedAnnealing.PrintSolution();

        stopwatch.Stop();

        TimeSpan elapsedTime = stopwatch.Elapsed;
        Console.WriteLine($"\nElapsed Time: {elapsedTime}");
    }
}