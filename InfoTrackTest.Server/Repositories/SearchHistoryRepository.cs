using InfoTrackTest.Server.Data.Model;

namespace InfoTrackTest.Server.Repositories
{
    public class SearchHistoryRepository : ISearchHistoryRepository
    {
        private readonly SearchHistoryContext _context;

        public SearchHistoryRepository(SearchHistoryContext context)
        {
            _context = context;
        }

        public void AddSearchHistory(SearchHistory searchHistory)
        {
            _context.SearchCountHistory.Add(searchHistory);

            _context.SaveChanges();
        }

        public IEnumerable<SearchHistory> GetAllSearchHistory()
        {
            return _context.SearchCountHistory;
        }
    }
}
