using Core.Models.Submarines.API;
using Logic.Submarines.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SubmarineAPI.Submarines.Controllers;

/// <summary>
/// Provide endpoints to users
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SubmarineController : ControllerBase
{
    private readonly ISubmarineLogic _submarineLogic;

    public SubmarineController(ISubmarineLogic submarineLogic)
    {
        _submarineLogic = submarineLogic;
    }

    /// <summary>
    /// Get all subs
    /// </summary>
    /// <returns>List of subs</returns>
    [HttpGet]
    public ActionResult<List<Submarine>> GetAll() => Ok(_submarineLogic.GetAll());

    /// <summary>
    /// Get a sub by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Specified sub</returns>
    [HttpGet("{id}")]
    public ActionResult<Submarine> GetById(int id)
        => _submarineLogic.GetById(id) switch
        {
            { } submarine => Ok(submarine),
            _ => BadRequest("Submarine not found.")
        };

    /// <summary>
    /// Add a new sub
    /// </summary>
    /// <param name="submarine"></param>
    /// <returns>List of subs after addition</returns>
    [HttpPost]
    public ActionResult<List<Submarine>> Insert(Submarine submarine)
        => _submarineLogic.Upsert(submarine) 
            ? GetAll()
            : BadRequest($"Error while inserting Submarine with name: {submarine.Name}");

    /// <summary>
    /// Update an existing sub
    /// </summary>
    /// <param name="submarine"></param>
    /// <returns>List of subs after update</returns>
    [HttpPut]
    public ActionResult<List<Submarine>> Update(Submarine submarine)
        => _submarineLogic.Upsert(submarine) 
            ? GetAll()
            : BadRequest($"Error while updating Submarine with id: {submarine.Id}");

    /// <summary>
    /// Delete a sub by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>List of subs after deletion</returns>
    [HttpDelete("{id}")]
    public ActionResult<List<Submarine>> Delete(int id)
        => _submarineLogic.Delete(id) 
            ? GetAll() 
            : BadRequest($"Error while deleting Submarine with id: {id}");
}