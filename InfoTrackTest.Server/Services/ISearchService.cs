using InfoTrackTest.Server.Model.Requests;

namespace InfoTrackTest.Server.Services;

public interface ISearchService
{
    public Task<int> GetSearchCountAsync(SearchRequest searchRequest);
}