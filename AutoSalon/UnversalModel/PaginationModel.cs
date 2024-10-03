namespace AutoSalonAPI.UnversalModel
{
    public class PaginationModel<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int Total { get; set; } = 0;
        public int Page { get; set; } = 1;
        public int Limit { get; set; }
    }
}
