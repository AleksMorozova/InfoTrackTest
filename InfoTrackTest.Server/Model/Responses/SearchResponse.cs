namespace InfoTrackTest.Server.Model.Responses;

public class SearchResponse
{
    public string Url { get; set; }
    public string Keywords { get; set; }
    public string Ranking { get; set; }
    public int Occurrences { get; set; }
    public string SearchDate { get; set; }
}
