namespace Rss_Reader_BackEnd.Models;

public class CategoryItem {
    public string? CategoryName { get; set; }
    public Item? Item { get; set; }
    public int ItemForeignKey { get; set; }
}