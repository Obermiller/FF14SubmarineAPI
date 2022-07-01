using Core.Models.Submarines.Schema;
using Data.Repositories.Submarines.Interfaces;

namespace Data.Repositories.Submarines;

/// <summary>
/// Access DB for parts
/// </summary>
public class PartRepository : DataRepository, IPartRepository
{
    private readonly DataContext _dataContext;

    public PartRepository(DataContext dataContext) 
        :base(dataContext)
    {
        _dataContext = dataContext;
    }
    
    /// <summary>
    /// Delete a sub part
    /// </summary>
    /// <param name="part"></param>
    public void Delete(Part part)
    {
        _dataContext.Parts.Remove(part);
        SaveChanges();
    }

    /// <summary>
    /// Get all sub parts
    /// </summary>
    /// <returns>List of sub parts</returns>
    public List<Part> GetAll() => _dataContext.Parts.ToList();
    
    /// <summary>
    /// Get sub parts by ids
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Sub part if exists</returns>
    public List<Part> GetByIds(IEnumerable<int> ids)
        => _dataContext.Parts
            .Where(p => ids.Contains(p.Id))
            .ToList();

    /// <summary>
    /// Get a sub part by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Sub part if exists</returns>
    public Part? GetById(int id) => _dataContext.Parts.Find(id);

    /// <summary>
    /// Insert a sub part
    /// </summary>
    /// <param name="part"></param>
    public void Insert(Part part)
    { 
        _dataContext.Parts.Add(part);
        SaveChanges();
    }
    
    /// <summary>
    /// Update a sub part
    /// </summary>
    /// <param name="part"></param>
    public void Update(Part part)
    {
        _dataContext.Parts.Update(part);
        SaveChanges();
    }
}