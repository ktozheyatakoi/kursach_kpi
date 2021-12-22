using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventorySklad.Core.Sklad
{
    public interface ISkladService
    {
        Task<List<Sklad>> GetAsync();
        Task<Sklad> GetByIdAsync(int id);
        Task<Sklad> Update(int id, string location);
        Task RemoveById(int id);
        Task<Sklad> AddAsync(Sklad sklad);
    }
}