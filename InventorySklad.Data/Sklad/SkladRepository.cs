using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InventorySklad.Core.Sklad;
using Microsoft.EntityFrameworkCore;

namespace InventorySklad.Data.Sklad
{
    public class SkladRepository : ISkladRepo
    {
        private readonly IMapper _mapper;
        private readonly InventorySkladContext _context;
        public SkladRepository(IMapper mapper,
            InventorySkladContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<Core.Sklad.Sklad> AddAsync(Core.Sklad.Sklad sklad)
        {
            var entity = _mapper.Map<SkladDto>(sklad);
            var result = await _context.Sklads.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Core.Sklad.Sklad>(result.Entity);
        }
        public async Task<List<Core.Sklad.Sklad>> GetAsync()
        {
            var entities = await _context.Sklads.ToListAsync();
            return _mapper.Map<List<Core.Sklad.Sklad>>(entities);
        }
        public async Task<Core.Sklad.Sklad> GetByIdAsync(int id)
        {
            var entitie = await _context.Sklads.FirstAsync(x => x.Id == id);
            return _mapper.Map<Core.Sklad.Sklad>(entitie);
        }
        public async Task RemoveById(int id)
        {
            var entetie = await _context.Sklads.FirstAsync(x => x.Id == id);
            _context.Sklads.Remove(entetie);
            await _context.SaveChangesAsync();
        }
        public async Task<Core.Sklad.Sklad> Update(int id, string location)
        {
            SkladDto sklad = (
                from n in _context.Sklads
                where n.Id == id
                select n).First();
            
            sklad.Location = location;
            var addResult = _context.Sklads.Update(sklad);

            await _context.SaveChangesAsync();
            return _mapper.Map<Core.Sklad.Sklad>(addResult.Entity);
        }
    }
}