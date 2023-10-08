namespace CombinatorialOptimization
{
    public class VisitTime
    {
        public VisitTime(int index, DateTime from, DateTime to)
        {
            Index = index;
            From = from;
            To = to;
        }

        public int Index { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
