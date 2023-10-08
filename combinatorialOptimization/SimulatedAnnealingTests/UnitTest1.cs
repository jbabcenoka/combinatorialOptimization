using CombinatorialOptimization;
using CombinatorialOptimization.Optimizator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SimulatedAnnealingTests
{
    [TestClass]
    public class OptimizatorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var visitIndex = 0;
            var visits = new List<VisitTime>
            {
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 08:00"), DateTime.Parse("2023-10-01 10:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 09:00"), DateTime.Parse("2023-10-01 11:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:00"), DateTime.Parse("2023-10-01 14:00")),
            };

            var workersCount = 2;

            var optimizator = new Optimizator(visits, workersCount);
            var firstFit = optimizator.GenerateInitialSolution();
            firstFit.PrintSolution();

            var simulatedAnnealing = optimizator.SimulatedAnnealing();
            simulatedAnnealing.PrintSolution();

            stopwatch.Stop();

            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine($"\nElapsed Time: {elapsedTime}");

            var lessCost = simulatedAnnealing.GetCost() < firstFit.GetCost();
            Assert.AreEqual(true, lessCost);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var visitIndex = 0;
            var visits = new List<VisitTime>
            {
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 08:00"), DateTime.Parse("2023-10-01 10:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 08:00"), DateTime.Parse("2023-10-01 13:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 08:00"), DateTime.Parse("2023-10-01 13:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 09:00"), DateTime.Parse("2023-10-01 10:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 13:00"), DateTime.Parse("2023-10-01 15:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:00"), DateTime.Parse("2023-10-01 14:00")),
            };

            var workersCount = 3;

            var optimizator = new Optimizator(visits, workersCount);
            var firstFit = optimizator.GenerateInitialSolution();
            firstFit.PrintSolution();

            var simulatedAnnealing = optimizator.SimulatedAnnealing();
            simulatedAnnealing.PrintSolution();

            stopwatch.Stop();

            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine($"\nElapsed Time: {elapsedTime}");

            var lessCost = simulatedAnnealing.GetCost() < firstFit.GetCost();
            Assert.AreEqual(1, lessCost ? 1 : 0);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var visitIndex = 0;
            var visits = new List<VisitTime>
            {
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 09:00"), DateTime.Parse("2023-10-01 10:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 09:00"), DateTime.Parse("2023-10-01 11:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 10:00"), DateTime.Parse("2023-10-01 11:30")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:00"), DateTime.Parse("2023-10-01 13:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:00"), DateTime.Parse("2023-10-01 13:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:00"), DateTime.Parse("2023-10-01 13:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:00"), DateTime.Parse("2023-10-01 16:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 16:10"), DateTime.Parse("2023-10-01 18:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 18:10"), DateTime.Parse("2023-10-01 19:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 18:10"), DateTime.Parse("2023-10-01 19:00")),
            };

            var workersCount = 3;

            var optimizator = new Optimizator(visits, workersCount);
            var firstFit = optimizator.GenerateInitialSolution();
            firstFit.PrintSolution();

            var simulatedAnnealing = optimizator.SimulatedAnnealing();
            simulatedAnnealing.PrintSolution();

            stopwatch.Stop();

            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine($"\nElapsed Time: {elapsedTime}");

            var lessCost = simulatedAnnealing.GetCost() < firstFit.GetCost();
            Assert.AreEqual(1, lessCost ? 1 : 0);
        }
    }
}