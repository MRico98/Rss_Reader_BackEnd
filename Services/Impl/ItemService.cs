using Rss_Reader_BackEnd.Models;
using Rss_Reader_BackEnd.Models.Enum;
using Rss_Reader_BackEnd.Repositories;

namespace Rss_Reader_BackEnd.Services.Impl;

public class ItemService : IItemService
{
    protected IRepository<Item> ItemRepository;
    protected IRepository<Category> CategoryRepository;

    public ItemService (IRepository<Item> ItemRepository, IRepository<Category> CategoryRepository)
    {
        this.ItemRepository = ItemRepository;
        this.CategoryRepository = CategoryRepository;
    }

    public List<Item> GetAllItems(string sortBy, SortOrder sortOrder)
    {
        String sortByCondition = sortBy;
        if(sortOrder == SortOrder.Ascending)
        {
            sortByCondition += " ASC";
        }
        else {
            sortByCondition += " DESC";
        }
        return ItemRepository.FindAllSorting(sortByCondition).ToList();
    }

    public void SetNewItem(Item item)
    {
        ItemRepository.Create(item);
        ItemRepository.Save();
    }

    public void SetNewItems(List<Item> items)
    {
        ItemRepository.Create(items);
        ItemRepository.Save();
    }
}