namespace InfoTrackTest.Server.Model.Requests;

public class SearchRequest
{
    public string Term { get; set; }
    public string Url { get; set; }
    public SearchEngine SearchEngine { get; set; }
    public string Count { get; set; }
}
