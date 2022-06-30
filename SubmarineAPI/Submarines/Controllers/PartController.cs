using Logic.Submarines.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SubmarineAPI.Submarines.Models;

namespace SubmarineAPI.Submarines.Controllers
{
    /// <summary>
    /// Provide endpoints to users
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PartController : ControllerBase
    {
        private readonly IPartLogic _partLogic;

        public PartController(IPartLogic partLogic)
        {
            _partLogic = partLogic;
        }

        /// <summary>
        /// Get all sub parts
        /// </summary>
        /// <returns>List of sub parts</returns>
        [HttpGet]
        public ActionResult<List<Part>> GetAll()
            => Ok(_partLogic.GetAll()
                .Select(x => new Part(x))
                .ToList());

        /// <summary>
        /// Get a sub part by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Specified sub part</returns>
        [HttpGet("{id}")]
        public ActionResult<Part> GetById(int id)
            => _partLogic.GetById(id) switch
            {
                { } part => Ok(new Part(part)),
                _ => BadRequest("Part not found.")
            };

        /// <summary>
        /// Add a new sub part
        /// </summary>
        /// <param name="part"></param>
        /// <returns>List of sub parts after addition</returns>
        [HttpPost]
        public ActionResult<List<Part>> Insert(Part part)
            => _partLogic.Upsert(part.MapToDb()) 
                ? GetAll()
                : BadRequest($"Error while inserting part with name: {part.Name}");

        /// <summary>
        /// Update an existing sub part
        /// </summary>
        /// <param name="part">Sub part</param>
        /// <returns>List of sub parts after update</returns>
        [HttpPut]
        public ActionResult<List<Part>> Update(Part part)
            => _partLogic.Upsert(part.MapToDb()) 
                ? GetAll()
                : BadRequest($"Error while updating part with id: {part.Id}");

        /// <summary>
        /// Delete a sub part by idea
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of sub parts after deletion</returns>
        [HttpDelete("{id}")]
        public ActionResult<List<Part>> Delete(int id)
            => _partLogic.Delete(id) 
                ? GetAll() 
                : BadRequest($"Error while deleting part with id: {id}");
    }
}