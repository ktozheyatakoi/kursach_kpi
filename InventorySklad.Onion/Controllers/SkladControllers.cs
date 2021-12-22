using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InventorySklad.Core.Sklad;
using InventorySklad.Orchestrators.Sklad;
using Microsoft.AspNetCore.Mvc;

namespace InventorySklad.Onion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkladControllers : ControllerBase
    {
        private readonly ISkladService _skladService;
        private readonly IMapper _mapper;
        public SkladControllers(IMapper mapper, ISkladService skladService)
        {
            _mapper = mapper;
            _skladService = skladService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var sklads = await _skladService.GetAsync();
            return Ok(_mapper.Map<List<Orchestrators.Sklad.Sklad>>(sklads));
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> PostAsync(Orchestrators.Sklad.Sklad sklad)
        {
            var skladModel = _mapper.Map<Core.Sklad.Sklad>(sklad);
            var createdModel = await _skladService.AddAsync(skladModel);
            return Ok(_mapper.Map<Orchestrators.Sklad.Sklad>(createdModel));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var sklad = await _skladService.GetByIdAsync(id);
            return Ok(_mapper.Map<Orchestrators.Sklad.Sklad>(sklad));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateByIdAsync(int id, UpdateLocation location)
        {
            await _skladService.Update(id, location.Location);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            await _skladService.RemoveById(id);
            return Ok();
        }
    }
}