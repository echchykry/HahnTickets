namespace HahnTickets.Shared.Pagination
{
    public class PaginatedList<T>
    {
        public int PageIndex { get; private set; }
        public int Count { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public List<T> Items { get; private set; } = new List<T>();
        private PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            Count = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;

            Items.AddRange(items);
        }

        public static PaginatedList<T> Create(IEnumerable<T> source, int first, int pageSize)
        {
            var count = source.Count();
            var items = pageSize == -1 ? source.ToList() :
                source.Skip(first).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, first, pageSize);
        }
    }
}
