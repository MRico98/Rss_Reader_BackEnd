using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rss_Reader_BackEnd.Models;
using Rss_Reader_BackEnd.Models.Enum;
using Rss_Reader_BackEnd.Models.Request;
using Rss_Reader_BackEnd.Repositories;

namespace Rss_Reader_BackEnd.Services.Impl;

public class ItemService : IItemService
{
    protected IRepository<Item>? ItemRepository { get; set; }
    protected IRepository<CategoryItem>? CategoryItem { get; set; }
    private readonly IMapper Mapper;

    public ItemService (IRepository<Item> ItemRepository,IMapper Mapper)
    {
        this.ItemRepository = ItemRepository;
        this.Mapper = Mapper;
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
        return ItemRepository.FindAllSorting(sortByCondition).Include(b => b.CategoryItems).ToList();
    }

    public void SetNewItem(Item item)
    {
        ItemRepository.Create(item);
        ItemRepository.Save();
    }

    public void SetNewItems(List<ItemRequest> items)
    {
        List<Item> itemsEntities = Mapper.Map<List<Item>>(items);
        ItemRepository.Create(itemsEntities);
        ItemRepository.Save();
    }
}