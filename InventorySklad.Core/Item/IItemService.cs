using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventorySklad.Core.Item
{
    public interface IItemService
    {
        Task<Item> GetByIdAsync(int id);
        Task<Item> Update(int id, string name);
        Task RemoveById(int id);
        Task<Item> AddAsync(Item item);
    }
}