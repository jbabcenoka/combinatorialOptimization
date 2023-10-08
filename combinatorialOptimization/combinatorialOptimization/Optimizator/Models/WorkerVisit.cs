namespace CombinatorialOptimization.Optimizator.Models
{
    public class WorkerVisit
    {
        public WorkerVisit(int workerNumber)
        {
            WorkerIndex = workerNumber;
        }

        public List<VisitTime> Visits { get; set; } = new List<VisitTime>();
        private int WorkerIndex { get; set; }

        public void Add(VisitTime visit)
        {
            Visits.Add(visit);
        }

        public void Remove(int visitIndex)
        {
            var visit = Visits.FirstOrDefault(x => x.Index == visitIndex);
            if (visit != null)
                Visits.Remove(visit);
        }

        public bool HasVisit(int visitIndex)
        {
            return Visits.Where(x => x.Index == visitIndex).Any();
        }

        public WorkerVisit Copy()
        {
            var newWorkerVisit = new WorkerVisit(WorkerIndex);

            var newVisits = new List<VisitTime>();
            foreach (var visitTime in Visits)
            {
                newVisits.Add(new VisitTime(visitTime.Index, visitTime.From, visitTime.To));
            }
            newWorkerVisit.Visits = newVisits;

            return newWorkerVisit;
        }

        public int GetWorkerNumber()
        {
            return WorkerIndex;
        }

        public void SetWorkerNumber(int index)
        {
            WorkerIndex = index;
        }

        private bool IsIntersectingVisits(VisitTime visit1, VisitTime visit2)
        {
            return visit1.From <= visit2.To && visit1.To >= visit2.From;
        }

        public void PrintWorkerVisit()
        {
            Console.WriteLine($"Worker {WorkerIndex + 1} has following visits:");

            foreach (var visit in Visits.OrderBy(x => x.From))
            {
                Console.Write($"From {visit.From} to {visit.To}");
                if (Visits.Any(x => x != visit && IsIntersectingVisits(x, visit)))
                {
                    Console.Write(" - intersecting");
                }
                Console.WriteLine();
            }
        }
    }
}
