using Core.Models.Submarines.Schema;

namespace Data.Repositories.Submarines;

/// <summary>
/// Access DB
/// </summary>
public class PartRepository : Interfaces.IPartRepository
{
    private readonly DataContext _dataContext;

    public PartRepository(DataContext dataContext)
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
        _dataContext.SaveChanges();
    }

    /// <summary>
    /// Get all sub parts
    /// </summary>
    /// <returns>List of sub parts</returns>
    public List<Part> GetAll() => _dataContext.Parts.ToList();

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
        if (_dataContext.Parts.Find(part.Id) is { } dbPart)
        {
            dbPart.Copy(part);
            _dataContext.Parts.Update(dbPart);
        }

        _dataContext.Parts.Add(part);
        _dataContext.SaveChanges();
    }
    
    /// <summary>
    /// Update a sub part
    /// </summary>
    /// <param name="part"></param>
    public void Update(Part part)
    {
        _dataContext.Parts.Update(part);
        _dataContext.SaveChanges();
    }
}