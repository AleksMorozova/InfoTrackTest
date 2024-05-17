using InfoTrackTest.Server.Data.Model;
using InfoTrackTest.Server.Repositories;

namespace InfoTrackTest.Server.Services
{
    public class SearchHistoryService : ISearchHistoryService
    {
        private readonly ISearchHistoryRepository _searchHistoryRepository;

        public SearchHistoryService(ISearchHistoryRepository searchHistoryRepository)
        {
            _searchHistoryRepository = searchHistoryRepository;
        }

        public void Add(SearchHistory searchHistory)
        {
            _searchHistoryRepository.AddSearchHistory(searchHistory);
        }

        public IEnumerable<SearchHistory> GetAllSearchCountHistory()
        {
            return _searchHistoryRepository.GetAllSearchHistory();
        }
    }
}
