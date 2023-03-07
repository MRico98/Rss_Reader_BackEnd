using System.ComponentModel.DataAnnotations;

namespace Rss_Reader_BackEnd.Models.Request;

public class ItemRequest {
    [Required]
    public DateTime CreationDate { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Url { get; set; }
    [Required]
    public string? Description { get; set; }
    public List<String> Categories { get; set; } = new List<string>();
}