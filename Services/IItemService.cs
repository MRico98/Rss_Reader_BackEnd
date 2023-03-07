using Rss_Reader_BackEnd.Models;
using Rss_Reader_BackEnd.Models.Enum;
using Rss_Reader_BackEnd.Models.Request;

namespace Rss_Reader_BackEnd.Services;

public interface IItemService 
{
    List<Item> GetAllItems(String sortBy, SortOrder sortOrder);
    void SetNewItems(List<ItemRequest> items);

    void SetNewItem(Item item);
}