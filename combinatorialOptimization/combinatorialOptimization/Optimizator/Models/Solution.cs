namespace CombinatorialOptimization.Optimizator.Models
{
    public class Solution
    {
        private Dictionary<int, int> _workers = new Dictionary<int, int>(); //worker Index, worker Max Working Hours

        public Solution(Dictionary<int, int> workers)
        {
            for (int workerIndex = 0; workerIndex < workers.Count; workerIndex++)
            {
                _workers.Add(workerIndex, workers[workerIndex]);
                WorkerVisits.Add(workerIndex, new List<VisitTime>());
            }
        }

        public Solution()
        {
        }

        public Dictionary<int, List<VisitTime>> WorkerVisits { get; set; } = new Dictionary<int, List<VisitTime>>();

        public int GetCost()
        {
            var totalCost = 0;

            foreach (var workerNumber in WorkerVisits.Keys)
            {
                //check whether times are intersecting
                var visitedVisits = new HashSet<VisitTime>();

                foreach (var visit in WorkerVisits[workerNumber])
                {
                    var intersectingCount = visitedVisits.Where(v => IsIntersectingVisits(v, visit)).Count();
                    if (intersectingCount > 0)
                    {
                        totalCost += intersectingCount;
                    }

                    visitedVisits.Add(visit);
                }

                var totalHoursSpent = WorkerVisits[workerNumber].Sum(visit => (visit.To - visit.From).TotalHours);

                // ja tiek pārsniegta slodze stundās - palielināt cost
                if (totalHoursSpent > _workers[workerNumber])
                {
                    totalCost++;
                }
            }

            return totalCost;
        }

        public Solution Copy()
        {
            var newSolution = new Solution(_workers);
            var newWorkerVisits = new Dictionary<int, List<VisitTime>>();

            foreach (var workerIndex in WorkerVisits.Keys)
            {
                // Copy visits
                var newVisits = new List<VisitTime>();
                foreach (var visitTime in WorkerVisits[workerIndex])
                {
                    newVisits.Add(new VisitTime(visitTime.Index, visitTime.From, visitTime.To));
                }

                newWorkerVisits.Add(workerIndex, newVisits);
            }

            newSolution.WorkerVisits = newWorkerVisits;
            return newSolution;
        }

        private bool IsIntersectingVisits(VisitTime visit1, VisitTime visit2)
        {
            return visit1.From <= visit2.To && visit1.To >= visit2.From;
        }

        public void PrintSolution()
        {
            foreach (var workerVisits in WorkerVisits)
            {
                Console.WriteLine($"Worker {workerVisits.Key + 1} (max hours {_workers[workerVisits.Key]}) has following visits:");

                foreach (var visit in workerVisits.Value.OrderBy(x => x.From))
                {
                    Console.Write($"From {visit.From} to {visit.To}");
                    if (workerVisits.Value.Any(x => x != visit && IsIntersectingVisits(x, visit)))
                    {
                        Console.Write(" - intersecting");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine($"Cost: {GetCost()}");
            Console.WriteLine("\n");
        }
    }
}
