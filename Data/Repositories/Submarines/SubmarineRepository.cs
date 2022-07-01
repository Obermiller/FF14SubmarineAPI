using Core.Models.Submarines.Schema;
using Data.Repositories.Submarines.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Submarines;

/// <summary>
/// Access DB for submarines
/// </summary>
public class SubmarineRepository : DataRepository, ISubmarineRepository
{
    private readonly DataContext _dataContext;

    public SubmarineRepository(DataContext dataContext) 
        :base(dataContext)
    {
        _dataContext = dataContext;
    }
    
    /// <summary>
    /// Delete a sub
    /// </summary>
    /// <param name="submarine"></param>
    public void Delete(Submarine submarine)
    {
        _dataContext.Submarines.Remove(submarine);
        SaveChanges();
    }

    /// <summary>
    /// Get all subs
    /// </summary>
    /// <returns>List of subs</returns>
    public List<Submarine> GetAll()
    {
        var submarines = _dataContext.Submarines
            .Include(s => s.Parts)
            .ThenInclude(sp => sp.Part)
            .ToList();
        
        return submarines;
    }

    /// <summary>
    /// Get a sub by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Sub if exists</returns>
    public Submarine? GetById(int id)
        => _dataContext.Submarines
            .Include(s => s.Parts)
            .ThenInclude(sp => sp.Part)
            .FirstOrDefault(s => s.Id == id);

    /// <summary>
    /// Insert a sub
    /// </summary>
    /// <param name="submarine"></param>
    public void Insert(Submarine submarine)
    {
        _dataContext.Submarines.Add(submarine);
        SaveChanges();
    }
    
    /// <summary>
    /// Update a sub
    /// </summary>
    /// <param name="submarine"></param>
    public void Update(Submarine submarine)
    {
        _dataContext.Submarines.Update(submarine);
        SaveChanges();
    }
}