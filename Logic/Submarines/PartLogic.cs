using Core.Models.Submarines.Schema;
using Data.Repositories.Submarines.Interfaces;

namespace Logic.Submarines;

/// <summary>
/// Bridge gap between controller and repos.
/// Perform supporting logic between the two.
/// </summary>
public class PartLogic : Interfaces.IPartLogic
{
    private readonly IPartRepository _partRepository;

    public PartLogic(IPartRepository partRepository) => _partRepository = partRepository;

    /// <summary>
    /// Delete a sub part
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Success or failure as bool</returns>
    public bool Delete(int id)
    {
        if (GetById(id) is not { } part)
        {
            return false;
        }
        
        _partRepository.Delete(part);

        return true;
    }
    
    /// <summary>
    /// Get all sub parts
    /// </summary>
    /// <returns>List of sub parts</returns>
    public List<Part> GetAll() => _partRepository.GetAll();

    /// <summary>
    /// Get a sub part by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Sub part or null if not found</returns>
    public Part? GetById(int id) => _partRepository.GetById(id);

    /// <summary>
    /// Insert or update a sub part
    /// </summary>
    /// <param name="part"></param>
    /// <returns>Success or failure as bool</returns>
    public bool Upsert(Part part)
    {
        try
        {
            if (GetById(part.Id) is not { } dbPart)
            {
                _partRepository.Insert(part);
            }
            else
            {
                dbPart.Copy(part);
                _partRepository.Update(part);
            }
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
}