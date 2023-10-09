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

            var visitIndex = 0;
            var visits = new List<VisitTime>
            {
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 08:00"), DateTime.Parse("2023-10-01 10:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 09:00"), DateTime.Parse("2023-10-01 11:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 11:00"), DateTime.Parse("2023-10-01 13:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:00"), DateTime.Parse("2023-10-01 14:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 17:00"), DateTime.Parse("2023-10-01 18:00")),
                new VisitTime(visitIndex, DateTime.Parse("2023-10-01 17:00"), DateTime.Parse("2023-10-01 19:00")),
            };

            var workerIndex = 0;
            var workers = new Dictionary<int, int>();
            workers.Add(workerIndex++, 5); 
            workers.Add(workerIndex, 6); 

            var optimizator = new Optimizator(visits, workers);
            var firstFit = optimizator.GenerateInitialSolution();
            var simulatedAnnealing = optimizator.SimulatedAnnealing(firstFit);

            Console.WriteLine($"First fit:");
            firstFit.PrintSolution();
            Console.WriteLine($"Simulated Annealing:");
            simulatedAnnealing.PrintSolution();

            var finalCost = simulatedAnnealing.GetCost();
            var lessCost = finalCost == 0 || finalCost < firstFit.GetCost();
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
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 08:00"), DateTime.Parse("2023-10-01 12:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 09:00"), DateTime.Parse("2023-10-01 10:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 13:00"), DateTime.Parse("2023-10-01 15:00")),
                new VisitTime(visitIndex, DateTime.Parse("2023-10-01 12:00"), DateTime.Parse("2023-10-01 14:00")),
            };

            var workerIndex = 0;
            var workers = new Dictionary<int, int>();
            workers.Add(workerIndex++, 8);
            workers.Add(workerIndex++, 4);
            workers.Add(workerIndex, 8);

            var optimizator = new Optimizator(visits, workers);
            var firstFit = optimizator.GenerateInitialSolution();
            var simulatedAnnealing = optimizator.SimulatedAnnealing(firstFit);

            Console.WriteLine($"First fit:");
            firstFit.PrintSolution();
            Console.WriteLine($"Simulated Annealing:");
            simulatedAnnealing.PrintSolution();

            var finalCost = simulatedAnnealing.GetCost();
            var lessCost = finalCost == 0 || finalCost < firstFit.GetCost();
            Assert.AreEqual(true, lessCost);
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
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 09:00"), DateTime.Parse("2023-10-01 12:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 09:00"), DateTime.Parse("2023-10-01 12:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 08:00"), DateTime.Parse("2023-10-01 11:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 10:00"), DateTime.Parse("2023-10-01 11:30")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:00"), DateTime.Parse("2023-10-01 13:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:00"), DateTime.Parse("2023-10-01 13:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:00"), DateTime.Parse("2023-10-01 16:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:10"), DateTime.Parse("2023-10-01 16:30")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 16:10"), DateTime.Parse("2023-10-01 18:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 16:10"), DateTime.Parse("2023-10-01 18:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 18:10"), DateTime.Parse("2023-10-01 19:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 18:10"), DateTime.Parse("2023-10-01 19:00")),
                new VisitTime(visitIndex, DateTime.Parse("2023-10-01 18:10"), DateTime.Parse("2023-10-01 19:00")),
            };

            var workerIndex = 0;
            var workers = new Dictionary<int, int>();
            workers.Add(workerIndex++, 10);
            workers.Add(workerIndex++, 6);
            workers.Add(workerIndex, 4);

            var optimizator = new Optimizator(visits, workers);
            var firstFit = optimizator.GenerateInitialSolution();
            var simulatedAnnealing = optimizator.SimulatedAnnealing(firstFit);

            Console.WriteLine($"First fit:");
            firstFit.PrintSolution();
            Console.WriteLine($"Simulated Annealing:");
            simulatedAnnealing.PrintSolution();

            var finalCost = simulatedAnnealing.GetCost();
            var lessCost = finalCost == 0 || finalCost < firstFit.GetCost();
            Assert.AreEqual(true, lessCost);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var visitIndex = 0;
            var visits = new List<VisitTime>
            {
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 08:00"), DateTime.Parse("2023-10-01 09:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 09:00"), DateTime.Parse("2023-10-01 10:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 10:00"), DateTime.Parse("2023-10-01 11:30")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:00"), DateTime.Parse("2023-10-01 13:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:30"), DateTime.Parse("2023-10-01 13:30")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:00"), DateTime.Parse("2023-10-01 16:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:10"), DateTime.Parse("2023-10-01 16:30")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 16:10"), DateTime.Parse("2023-10-01 18:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 18:10"), DateTime.Parse("2023-10-01 19:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 18:10"), DateTime.Parse("2023-10-01 19:00")),
                new VisitTime(visitIndex, DateTime.Parse("2023-10-01 18:10"), DateTime.Parse("2023-10-01 19:00")),
            };

            var workerIndex = 0;
            var workers = new Dictionary<int, int>();
            workers.Add(workerIndex++, 2);
            workers.Add(workerIndex++, 10);
            workers.Add(workerIndex, 2);

            var optimizator = new Optimizator(visits, workers);
            var firstFit = optimizator.GenerateInitialSolution();
            var simulatedAnnealing = optimizator.SimulatedAnnealing(firstFit);

            Console.WriteLine($"First fit:");
            firstFit.PrintSolution();
            Console.WriteLine($"Simulated Annealing:");
            simulatedAnnealing.PrintSolution();

            var finalCost = simulatedAnnealing.GetCost();
            var lessCost = finalCost == 0 || finalCost < firstFit.GetCost();
            Assert.AreEqual(true, lessCost);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var visitIndex = 0;
            var visits = new List<VisitTime>
            {
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 08:00"), DateTime.Parse("2023-10-01 10:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 08:00"), DateTime.Parse("2023-10-01 09:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 08:00"), DateTime.Parse("2023-10-01 09:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 08:00"), DateTime.Parse("2023-10-01 09:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 09:00"), DateTime.Parse("2023-10-01 10:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 09:00"), DateTime.Parse("2023-10-01 10:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 09:00"), DateTime.Parse("2023-10-01 10:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 10:00"), DateTime.Parse("2023-10-01 11:30")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 10:00"), DateTime.Parse("2023-10-01 11:30")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 10:00"), DateTime.Parse("2023-10-01 11:30")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:00"), DateTime.Parse("2023-10-01 13:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:00"), DateTime.Parse("2023-10-01 13:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:00"), DateTime.Parse("2023-10-01 13:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:30"), DateTime.Parse("2023-10-01 13:30")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:30"), DateTime.Parse("2023-10-01 13:30")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 12:30"), DateTime.Parse("2023-10-01 13:30")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 14:00"), DateTime.Parse("2023-10-01 15:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 14:00"), DateTime.Parse("2023-10-01 15:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 14:00"), DateTime.Parse("2023-10-01 15:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:30"), DateTime.Parse("2023-10-01 16:30")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:30"), DateTime.Parse("2023-10-01 16:30")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:00"), DateTime.Parse("2023-10-01 16:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:00"), DateTime.Parse("2023-10-01 16:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:00"), DateTime.Parse("2023-10-01 16:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:00"), DateTime.Parse("2023-10-01 16:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 15:10"), DateTime.Parse("2023-10-01 16:30")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 16:10"), DateTime.Parse("2023-10-01 18:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 16:10"), DateTime.Parse("2023-10-01 18:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 16:10"), DateTime.Parse("2023-10-01 18:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 16:10"), DateTime.Parse("2023-10-01 18:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 16:10"), DateTime.Parse("2023-10-01 18:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 18:10"), DateTime.Parse("2023-10-01 19:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 18:10"), DateTime.Parse("2023-10-01 19:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 18:10"), DateTime.Parse("2023-10-01 19:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 18:10"), DateTime.Parse("2023-10-01 19:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 18:10"), DateTime.Parse("2023-10-01 19:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 18:10"), DateTime.Parse("2023-10-01 19:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 18:10"), DateTime.Parse("2023-10-01 19:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 19:00"), DateTime.Parse("2023-10-01 20:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 21:00"), DateTime.Parse("2023-10-01 22:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 21:00"), DateTime.Parse("2023-10-01 22:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 21:00"), DateTime.Parse("2023-10-01 22:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 22:00"), DateTime.Parse("2023-10-01 23:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 22:00"), DateTime.Parse("2023-10-01 23:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 22:00"), DateTime.Parse("2023-10-01 23:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 22:00"), DateTime.Parse("2023-10-01 23:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 22:00"), DateTime.Parse("2023-10-01 23:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 22:00"), DateTime.Parse("2023-10-01 23:00")),
                new VisitTime(visitIndex++, DateTime.Parse("2023-10-01 22:00"), DateTime.Parse("2023-10-01 23:00")),
                new VisitTime(visitIndex, DateTime.Parse("2023-10-01 22:00"), DateTime.Parse("2023-10-01 23:00")),
            };

            var workerIndex = 0;
            var workers = new Dictionary<int, int>();
            workers.Add(workerIndex++, 8);
            workers.Add(workerIndex++, 8);
            workers.Add(workerIndex++, 8);
            workers.Add(workerIndex++, 8);
            workers.Add(workerIndex++, 8);
            workers.Add(workerIndex++, 8);
            workers.Add(workerIndex++, 8);
            workers.Add(workerIndex, 8);

            var optimizator = new Optimizator(visits, workers);
            var firstFit = optimizator.GenerateInitialSolution();
            var simulatedAnnealing = optimizator.SimulatedAnnealing(firstFit);

            Console.WriteLine("First fit:");
            firstFit.PrintSolution();
            Console.WriteLine("Simulated Annealing:");
            simulatedAnnealing.PrintSolution();

            var finalCost = simulatedAnnealing.GetCost();
            var lessCost = finalCost == 0 || finalCost < firstFit.GetCost();
            Assert.AreEqual(true, lessCost);
        }
    }
}