namespace InfoTrackTest.Server.Data.Model
{
    public class SearchHistory
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Term { get; set; } = string.Empty;
        public string SearchEngine { get; set; } = string.Empty;
        public string Indices { get; set; } = string.Empty;
        public DateTimeOffset DateOfExcecution { get; set; }
    }
}
