using InfoTrackTest.Server.Model.Requests;
using InfoTrackTest.Server.Model.Responses;
using InfoTrackTest.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrackTest.Server.Controllers;

[ApiController]
[Route("search")]
public class SearchCountController : ControllerBase
{
    private readonly ISearchService _searchService;
    private readonly ISearchHistoryService _searchHistoryService;

    public SearchCountController(ISearchService searchService, ISearchHistoryService searchHistoryService)
    {
        _searchService = searchService;
        _searchHistoryService = searchHistoryService;
    }

    [HttpPost]
    [Route("count")]
    public ActionResult<SearchResponse> GetSearchCountAsync([FromBody] SearchRequest searchRequest)
    {
        //TODO: add request validation

        return Ok(_searchService.GetSearchCountAsync(searchRequest));
    }

    [HttpGet]
    [Route("history")]
    public ActionResult<SearchResponse> Add()
    {
        return Ok(_searchHistoryService.GetAllSearchCountHistory());
    }
}
