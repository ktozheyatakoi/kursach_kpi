using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InventorySklad.Core.Item;
using InventorySklad.Orchestrators.Item;
using Microsoft.AspNetCore.Mvc;
using Item = InventorySklad.Orchestrators.Item.Item;

namespace InventorySklad.Onion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemControllers : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        public ItemControllers(IMapper mapper, IItemService itemService)
        {
            _mapper = mapper;
            _itemService = itemService;
        }
        [HttpPost("sklads/{skladId}/sklads")]
        public async Task<IActionResult> PostAsync(Item item, int skladId)
        {
            var itemModel = _mapper.Map<InventorySklad.Core.Item.Item>(item);
            itemModel.SkladId = skladId;
            var createdModel = await _itemService.AddAsync(itemModel);
            return Ok(_mapper.Map<Orchestrators.Item.Item>(createdModel));
        }
        [HttpGet("sklads/sklads/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            return Ok(_mapper.Map<Item>(item));
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateByIdAsync(int id, UpdateName name)
        {
            await _itemService.Update(id, name.Name);
            return Ok((id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            await _itemService.RemoveById(id);
            return Ok();
        }
    }
}