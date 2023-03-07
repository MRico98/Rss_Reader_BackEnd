
using Microsoft.AspNetCore.Mvc;
using Rss_Reader_BackEnd.Models.Enum;
using Rss_Reader_BackEnd.Models.Request;
using Rss_Reader_BackEnd.Services;

namespace Rss_Reader_BackEnd.Controller;


[Route("[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    protected IItemService ItemService { get; set; }

    public ItemController (IItemService itemService) {
        ItemService = itemService;
    }

    [HttpGet]
    public IActionResult Get(SortOrder sortOrder = SortOrder.Ascending,[FromQuery] String OrderBy = "CreationDate")
    {
        return Ok(ItemService.GetAllItems(OrderBy,sortOrder));
    }

    [HttpPost]
    public IActionResult Post([FromBody]List<ItemRequest> items)
    {
        if (!ModelState.IsValid){
            return BadRequest(ModelState);
        }
        ItemService.SetNewItems(items);
        return Ok(items);
    }
}