using CombinatorialOptimization.Optimizator.Models;
using System.Linq;

namespace CombinatorialOptimization.Optimizator
{
    public class Optimizator
    {
        private readonly List<VisitTime> _visitTimes;
        private readonly int _workerCount;

        private readonly double _temperature = 100000;
        private readonly double _coolingRate = 10;
        private readonly int _maxIterations = 1000;

        public Optimizator(List<VisitTime> visits, int workerCount)
        {
            _visitTimes = visits;
            if (workerCount <= 1)
            {
                throw new Exception("Worker count must be more then 1.");
            }

            _workerCount = workerCount;
        }

        /* Initialize first solution using First Fit algorithm. */
        public Solution GenerateInitialSolution()
        {
            var finalCost = 0;
            var firstFit = new Solution(_workerCount);

            foreach (var visit in _visitTimes)
            {
                int workerBestCost = finalCost;
                int? bestVisitorIndex = null;

                var workersTimes = firstFit.WorkerVisits
                    .Select(x => new KeyValuePair<int, List<VisitTime>>(x.GetWorkerNumber(), x.Visits))
                    .OrderBy(x => Guid.NewGuid());

                foreach (var workerTimes in workersTimes)
                {
                    workerTimes.Value.Add(visit);
                    var currentCost = firstFit.GetCost();

                    if (bestVisitorIndex == null)
                    {
                        workerBestCost = currentCost;
                        bestVisitorIndex = workerTimes.Key;
                    }
                    else if (currentCost < workerBestCost)
                    {
                        workerBestCost = currentCost;
                        bestVisitorIndex = workerTimes.Key;
                    }

                    workerTimes.Value.Remove(visit);
                }

                finalCost = workerBestCost;
                firstFit.WorkerVisits
                    .FirstOrDefault(x => x.GetWorkerNumber() == bestVisitorIndex)?
                    .Add(visit);
            }

            return firstFit;
        }

        /* Implemented Simulated Annealing algorithm. */
        public Solution SimulatedAnnealing()
        {
            var initialSolution = GenerateInitialSolution();
            var currentSolution = initialSolution.Copy();
            var bestSolution = initialSolution.Copy();
            var temperature = _temperature;

            for (var iteration = 0; iteration < _maxIterations; iteration++)
            {
                var newSolution = GenerateNewSolution(currentSolution);

                if (newSolution.GetCost() - bestSolution.GetCost() < 0)
                {
                    bestSolution = newSolution;
                }

                if (newSolution.GetCost() - currentSolution.GetCost() < 0
                    || RoolTheDice(currentSolution.GetCost(), newSolution.GetCost(), temperature))
                {
                    currentSolution = newSolution;
                }

                temperature -= _coolingRate;
            }

            return bestSolution;
        }

        /* Generate solution */
        private Solution GenerateNewSolution(Solution solution)
        {
            var newSolution = solution.Copy();

            var random = new Random();
            var randomVisit = _visitTimes[random.Next(_visitTimes.Count)];

            // Remove visit
            var worker = newSolution.WorkerVisits
                .FirstOrDefault(x => x.HasVisit(randomVisit.Index));

            if (worker != null)
                worker.Remove(randomVisit.Index);

            // Add visit to other worker 
            newSolution.WorkerVisits
                .Where(x => x.GetWorkerNumber() != worker?.GetWorkerNumber())
                .OrderBy(x => Guid.NewGuid())
                .First()
                .Add(randomVisit);

            return newSolution;
        }

        /* Checks the probability */
        private bool RoolTheDice(int currentCost, int newCost, double temperature)
        {
            var random = new Random();
            var ePow = Math.Exp((currentCost - newCost) / temperature);

            return random.NextDouble() < ePow;
        }
    }
}
