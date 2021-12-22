using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventorySklad.Core.Sklad;

namespace InventorySklad.Orchestrators.Sklad
{
    public class SkladService : ISkladService
    {
        private readonly ISkladRepo skladRepository_;
        public SkladService(ISkladRepo skladRepository)
        {
            skladRepository_ = skladRepository;
        }
        public async Task<Core.Sklad.Sklad> AddAsync(Core.Sklad.Sklad sklad)
        {
            return await skladRepository_.AddAsync(sklad);
        }
        public async Task<List<Core.Sklad.Sklad>> GetAsync()
        {
            return await skladRepository_.GetAsync();
        }
        public async Task<Core.Sklad.Sklad> GetByIdAsync(int id)
        {
            return await skladRepository_.GetByIdAsync(id);
        }

        public async Task<Core.Sklad.Sklad> Update(int id, string location)
        {
            var sklad = await skladRepository_.GetByIdAsync(id);
            if (sklad == null)
                throw new ArgumentOutOfRangeException();
            sklad.Location = location;
            var updateSklad = await skladRepository_.Update(id, location);
            return updateSklad;
        }
        public async Task RemoveById(int id)
        {
            var sklad = await skladRepository_.GetByIdAsync(id);
            if (sklad == null)
                throw new ArgumentOutOfRangeException();
            await skladRepository_.RemoveById(id);
        }
    }
}