namespace CombinatorialOptimization.Optimizator.Models
{
    public class Solution
    {
        public Solution(int workerCount)
        {
            for (int workerIndex = 0; workerIndex < workerCount; workerIndex++)
            {
                WorkerVisits.Add(new WorkerVisit(workerIndex));
            }
        }

        public Solution()
        {
        }

        public List<WorkerVisit> WorkerVisits { get; set; } = new List<WorkerVisit>();

        public int GetCost()
        {
            var totalCost = 0;
            var workerVisits = WorkerVisits.ToDictionary(x => x.GetWorkerNumber(), x => x.Visits);

            foreach (var workerNumber in workerVisits.Keys)
            {
                //check whether times are intersecting
                var visitedVisits = new HashSet<VisitTime>();

                foreach (var visit in workerVisits[workerNumber])
                {
                    var intersectingCount = visitedVisits.Where(v => IsIntersectingVisits(v, visit)).Count();
                    if (intersectingCount > 0)
                    {
                        totalCost += intersectingCount;
                    }

                    visitedVisits.Add(visit);
                }
            }

            return totalCost;
        }

        public Solution Copy()
        {
            var newWorkerVisits = new List<WorkerVisit>();

            foreach (var workerVisit in WorkerVisits)
            {
                var newWorkerVisit = workerVisit.Copy();
                newWorkerVisit.SetWorkerNumber(workerVisit.GetWorkerNumber());
                newWorkerVisits.Add(newWorkerVisit);
            }

            return new Solution
            {
                WorkerVisits = newWorkerVisits
            };
        }

        private bool IsIntersectingVisits(VisitTime visit1, VisitTime visit2)
        {
            return visit1.From <= visit2.To && visit1.To >= visit2.From;
        }
        
        public void PrintSolution()
        {
            foreach (var workerVisits in WorkerVisits)
            {
                workerVisits.PrintWorkerVisit();
            }

            Console.WriteLine($"Cost: {GetCost()}");
            Console.WriteLine("\n");
        }
    }
}
