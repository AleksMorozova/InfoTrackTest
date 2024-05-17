using InfoTrackTest.Server.Model;
using InfoTrackTest.Server.Services;
using Microsoft.Extensions.Logging;
using Moq;
using static System.Net.WebRequestMethods;
using System.Reflection.Metadata;
using System;
using InfoTrackTest.Server.Model.Requests;
using Moq.Protected;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Http.Headers;

namespace InfoTrackTests
{
    public class SearchServiceTests
    {
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler = new(MockBehavior.Strict);
        private readonly HttpClient _httpClient;
        private readonly Mock<ILogger<SearchService>> _mockLogger = new();
        private readonly Mock<ISearchHistoryService> _mockSearchCountHistoryRepository = new();
        private readonly SearchService _searchService;

        public SearchServiceTests()
        {
            _httpClient = new HttpClient(_mockHttpMessageHandler.Object);

            _searchService = new SearchService(_httpClient, _mockLogger.Object, _mockSearchCountHistoryRepository.Object);
        }
        [Fact]
        public async Task GetSearchCountAsync()
        {
            var request = new SearchRequest
            {
                Term = "test",
                Url = "example.com",
                SearchEngine = SearchEngine.Google
            };

            var responseContent = new StringContent(@"<div class=""egMi0 kCrYT""><a href=""/url?q=example.com""");

            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = responseContent
                })
                .Callback<HttpRequestMessage, CancellationToken>((req, ct) => req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain")))
                .Verifiable();

            var result = await _searchService.GetSearchCountAsync(request);

            Assert.Equal(1, result);
        }
    }
}