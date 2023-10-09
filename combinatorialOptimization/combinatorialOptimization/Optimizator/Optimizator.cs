using CombinatorialOptimization.Optimizator.Models;
using System.Linq;

namespace CombinatorialOptimization.Optimizator
{
    public class Optimizator
    {
        private readonly List<VisitTime> _visitTimes;
        private Dictionary<int, int> _workers = new Dictionary<int, int>();

        private readonly double _temperature = 100000;
        private readonly double _coolingRate = 50;
        private readonly int _maxIterations = 10000;

        public Optimizator(List<VisitTime> visits, Dictionary<int, int> workers)
        {
            _visitTimes = visits;
            if (workers.Count <= 1)
            {
                throw new Exception("Worker count must be more then 1.");
            }

            foreach (var worker in workers)
            {
                _workers.Add(worker.Key, worker.Value);
            }
        }

        /* Initialize first solution using First Fit algorithm. */
        public Solution GenerateInitialSolution()
        {
            var finalCost = 0;
            var firstFit = new Solution(_workers);

            foreach (var visit in _visitTimes)
            {
                int workerBestCost = finalCost;
                int? bestVisitorIndex = null;

                var workersTimes = firstFit.WorkerVisits
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
                if (bestVisitorIndex != null)
                    firstFit.WorkerVisits[bestVisitorIndex.Value]
                    .Add(visit);
            }

            return firstFit;
        }

        /* Implemented Simulated Annealing algorithm. */
        public Solution SimulatedAnnealing(Solution initialSolution)
        {
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

            // Remove random visit
            var random = new Random();
            var randomVisit = _visitTimes[random.Next(_visitTimes.Count)];
            var workerWithVisits = newSolution.WorkerVisits
                .Where(kv => kv.Value.Any(visit => visit.Index == randomVisit.Index))
                .FirstOrDefault();
            var itemToRemove = workerWithVisits.Value.Find(x => x.Index == randomVisit.Index);
            if (itemToRemove != null)
                newSolution.WorkerVisits[workerWithVisits.Key].Remove(itemToRemove);

            // Add this visit to other worker
            newSolution.WorkerVisits.Where(x => x.Key != workerWithVisits.Key)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefault()
                .Value
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
