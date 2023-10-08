using CombinatorialOptimization.Optimizator.Models;

namespace CombinatorialOptimization
{
    public class VisitScheduler
    {
        private List<VisitTime> _visitTimes;
        private int _workerCount;

        public VisitScheduler(List<VisitTime> visit_times, int workerCount)
        {
            this._visitTimes = visit_times;
            this._workerCount = workerCount;
        }

        public Solution GenerateBestSolution()
        {
            var optimizator = new Optimizator.Optimizator(_visitTimes, _workerCount);
            return optimizator.GenerateInitialSolution();
        }
    }
}
