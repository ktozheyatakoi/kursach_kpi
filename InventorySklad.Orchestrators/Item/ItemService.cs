using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventorySklad.Core.Item;

namespace InventorySklad.Orchestrators.Item
{
    public class ItemService : IItemService
    {
        private readonly IItemRepo itemRepository_;
        public ItemService(IItemRepo itemRepository)
        {
            itemRepository_ = itemRepository;
        }

        public async Task<Core.Item.Item> AddAsync(Core.Item.Item item)
        {
            return await itemRepository_.AddAsync(item);
        }

        public async Task<Core.Item.Item> GetByIdAsync(int id)
        {
            return await itemRepository_.GetByIdAsync(id);
        }

        public async Task<Core.Item.Item> Update(int id, string name)
        {
            var item = await itemRepository_.GetByIdAsync(id);
            item.Name = name;
            await itemRepository_.Update(id, name);
            return item;
        }
        public async Task RemoveById(int id)
        {
            var item = await itemRepository_.GetByIdAsync(id);
            if (item == null)
                throw new ArgumentOutOfRangeException();
            await itemRepository_.RemoveById(id);

        }
    }
}