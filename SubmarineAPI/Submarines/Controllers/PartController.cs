using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubmarineAPI.Submarines.Models;

namespace SubmarineAPI.Submarines.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartController : ControllerBase
    {
        private readonly DataContext _dataContext;
        
        public PartController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Part>>> GetAll()
            => Ok(await _dataContext.Parts
                .Select(x => new Part(x))
                .ToListAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Part>> GetById(int id)
            => await _dataContext.Parts.FindAsync(id) switch
            {
                { } part => Ok(new Part(part)),
                _ => BadRequest("Part not found.")
            };

        [HttpPost]
        public async Task<ActionResult<List<Part>>> Add(Part part)
        {
            _dataContext.Parts.Add(part.MapToDb());
            await _dataContext.SaveChangesAsync();
            
            return Ok(await _dataContext.Parts
                .Select(x => new Part(x))
                .ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Part>>> Update(Part request)
        {
            if (await _dataContext.Parts.FindAsync(request.Id) is not { } part)
            {
                return BadRequest("Part not found");
            }

            MapToDb();
            
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Parts
                .Select(x => new Part(x))
                .ToListAsync());

            void MapToDb()
            {
                part.Name = request.Name;
                part.Type = request.Type;
                part.Description = request.Description;

                part.Rank = request.Outfitting.Rank;
                part.Components = request.Outfitting.Components;

                part.Surveillance = request.Functionality.Surveillance;
                part.Retrieval = request.Functionality.Retrieval;
                part.Speed = request.Functionality.Speed;
                part.Range = request.Functionality.Range;
                part.Favor = request.Functionality.Favor;

                part.Materials = request.CraftingAndRepairs.Materials;
                part.Desynthesizable = request.CraftingAndRepairs.Desynthesizable;

                part.ShopSellingPrice = request.ShopSellingPrice;
                part.SellingPrice = request.SellingPrice;
                part.MarketboardProhibited = request.MarketboardProhibited;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Part>>> Delete(int id)
        {
            if (await _dataContext.Parts.FindAsync(id) is not { } part)
            {
                return BadRequest("Part not found");
            }

            _dataContext.Parts.Remove(part);
            
            return Ok(await _dataContext.Parts
                .Select(x => new Part(x))
                .ToListAsync());
        }
    }
}