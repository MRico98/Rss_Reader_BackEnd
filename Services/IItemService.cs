using Rss_Reader_BackEnd.Models;
using Rss_Reader_BackEnd.Models.Enum;

namespace Rss_Reader_BackEnd.Services;

public interface IItemService 
{
    List<Item> GetAllItems(String sortBy, SortOrder sortOrder);
    void SetNewItems(List<Item> items);

    void SetNewItem(Item item);
}