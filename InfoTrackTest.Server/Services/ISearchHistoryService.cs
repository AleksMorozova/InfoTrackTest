using InfoTrackTest.Server.Data.Model;

namespace InfoTrackTest.Server.Services
{
    public interface ISearchHistoryService
    {
        public IEnumerable<SearchHistory> GetAllSearchCountHistory();
        public void Add(SearchHistory searchHistory);

    }
}
