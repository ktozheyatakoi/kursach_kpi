using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InventorySklad.Core.Item;
using Microsoft.EntityFrameworkCore;

namespace InventorySklad.Data.Item
{
    public class ItemRepository : IItemRepo
    {
        private readonly IMapper _mapper;
        private readonly InventorySkladContext _context;
        public ItemRepository(IMapper mapper,
            InventorySkladContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Core.Item.Item> AddAsync(Core.Item.Item item)
        {
            var entity = _mapper.Map<ItemDto>(item);
            var result = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Core.Item.Item>(result.Entity);
        }

        public async Task<List<Core.Item.Item>> GetAsync()
        {
            var entities = await _context.Items.ToListAsync();
            return _mapper.Map<List<Core.Item.Item>>(entities);
        }

        public async Task<Core.Item.Item> GetByIdAsync(int id)
        {
            var entity = await _context.Items.FirstAsync(x => x.Id == id);
            return _mapper.Map<Core.Item.Item>(entity);
        }

        public async Task RemoveById(int id)
        {
            var entity = await _context.Items.FirstAsync(x => x.Id == id);
            await _context.SaveChangesAsync();
            _context.Items.Remove(entity);
        }

        public async Task<Core.Item.Item> Update(int id, string name)
        {
            ItemDto item = (
                from n in _context.Items
                where n.Id == id
                select n).First();
            
            item.Name = name;
            var addResult = _context.Items.Update(item);

            await _context.SaveChangesAsync();
            return _mapper.Map<Core.Item.Item>(addResult.Entity);
        }
    }
}