using InfoTrackTest.Server.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace InfoTrackTest.Server.Repositories
{
    public interface ISearchHistoryRepository
    {
        public void AddSearchHistory(SearchHistory searchHistory);

        public IEnumerable<SearchHistory> GetAllSearchHistory();
    }
}
