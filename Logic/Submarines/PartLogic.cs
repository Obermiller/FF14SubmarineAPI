using Data.Repositories.Submarines.Interfaces;
using Logic.Submarines.Interfaces;
using api = Core.Models.Submarines.API;
using db = Core.Models.Submarines.Schema;

namespace Logic.Submarines;

/// <summary>
/// Bridge gap between controller and repos.
/// Perform supporting logic between the two.
/// </summary>
public class PartLogic : IPartLogic
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
        if (GetDbById(id) is not { } part)
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
    public List<api.Part> GetAll()
        => _partRepository.GetAll()
            .Select(p => new api.Part(p))
            .ToList();

    /// <summary>
    /// Get a sub part by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Sub part or null if not found</returns>
    public api.Part? GetById(int id) => GetDbById(id) switch
    {
        { } part => new api.Part(part),
        _ => null
    };

    /// <summary>
    /// Insert or update a sub part
    /// </summary>
    /// <param name="part"></param>
    /// <returns>Success or failure as bool</returns>
    public bool Upsert(api.Part part)
    {
        try
        {
            var mappedPart = part.MapToDb();
            if (_partRepository.GetById(part.Id) is not { } dbPart)
            {
                mappedPart.Id = default;
                _partRepository.Insert(mappedPart);
            }
            else
            {
                dbPart.Copy(mappedPart);
                _partRepository.Update(dbPart);
            }
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    private db.Part? GetDbById(int id) => _partRepository.GetById(id);
}