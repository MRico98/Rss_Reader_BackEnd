namespace Rss_Reader_BackEnd.Models.Request;

public class ItemRequest {
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
}