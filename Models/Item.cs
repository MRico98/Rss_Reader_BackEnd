namespace Rss_Reader_BackEnd.Models;

public class Item {
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public string? Title { get; set; }
    public string? Url { get; set; }
    public string? Description { get; set; }
    public List<CategoryItem>? CategoryItems { get; set; }
}