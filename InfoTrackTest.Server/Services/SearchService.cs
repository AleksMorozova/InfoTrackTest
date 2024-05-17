using InfoTrackTest.Server.Model;
using InfoTrackTest.Server.Model.Exceptions;
using InfoTrackTest.Server.Model.Requests;
using System.Text.RegularExpressions;
using System.Web;
using Constants = InfoTrackTest.Server.Model.Constants;

namespace InfoTrackTest.Server.Services;

public class SearchService : ISearchService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<SearchService> _logger;
    private readonly ISearchHistoryService _searchHistoryService;

    public SearchService(HttpClient httpClient, ILogger<SearchService> logger, ISearchHistoryService searchHistoryService)
    {
        _httpClient = httpClient;
        _logger = logger;
        _searchHistoryService = searchHistoryService;
    }

    public async Task<int> GetSearchCountAsync(SearchRequest searchRequest)
    {
        string searchUrl = SearchService.GetUrl(searchRequest.Term, searchRequest.Count, searchRequest.SearchEngine);
        SearchService.AddHeaders(searchRequest.SearchEngine, _httpClient);

        var indices = new List<int>();
        try
        {
            var response = await _httpClient.GetStringAsync(searchUrl);

            indices = ParseSearchResults(response, searchRequest.Url, SearchService.GetRegex(SearchEngine.Google)).ToList();

            _logger.LogInformation($"Search done on \"{SearchEngine.Google}\" with search term: \"{searchRequest.Term}\" and url: \"{searchRequest.Url}\"");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        var count = indices.Count != 0 ? indices.Count : 0;

        _searchHistoryService.Add(new Data.Model.SearchHistory()
        {
            Id = Guid.NewGuid(),
            Url = searchRequest.Url,
            Term = searchRequest.Term,
            SearchEngine = searchRequest.SearchEngine.ToString(),
            DateOfExcecution = DateTime.Now,
            Indices = count.ToString()
        });

        return count;
    }

    private static string GetUrl(string searchTerm, string resultCount, SearchEngine searchEngine)
    {
        return searchEngine switch
        {
            SearchEngine.Google => $"http://www.google.co.uk/search?q={HttpUtility.UrlEncode(searchTerm)}&num={resultCount}",
            SearchEngine.Bing => $"http://www.bing.com/search?q={HttpUtility.UrlEncode(searchTerm)}&count={resultCount}",
            _ => throw new CaseNotHandledException("Search Engin implementation missing")
        };
    }

    private static string GetRegex(SearchEngine searchEngine)
    {
        return searchEngine switch
        {
            SearchEngine.Google => Constants.GoogleRegex,
            SearchEngine.Bing => Constants.BingRegex,
            _ => throw new CaseNotHandledException("Search Engin implementation missing")
        };
    }

    private static void AddHeaders(SearchEngine searchEngine, HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36");
    }

    private static IEnumerable<int> ParseSearchResults(string htmlContent, string targetUrl, string regex)
    {
        var indices = new List<int>();

        var matches = Regex.Matches(htmlContent, regex);

        int rank = 1;
        foreach (Match match in matches)
        {
            if (match.Groups[0].Value.Contains(targetUrl))
            {
                indices.Add(rank);
            }
            rank++;
        }

        return indices;
    }
}