using System.Data.Entity.Core;
using Data.Repositories.Submarines.Interfaces;
using Logic.Submarines.Interfaces;
using api = Core.Models.Submarines.API;
using db = Core.Models.Submarines.Schema;

namespace Logic.Submarines;

/// <summary>
/// Bridge gap between controller and repos.
/// Perform supporting logic between the two.
/// </summary>
public class SubmarineLogic : ISubmarineLogic
{
    private readonly IPartRepository _partRepository;
    private readonly ISubmarineRepository _submarineRepository;

    public SubmarineLogic(IPartRepository partRepository, ISubmarineRepository submarineRepository)
    {
        _partRepository = partRepository;
        _submarineRepository = submarineRepository;
    }

    /// <summary>
    /// Delete a sub
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Success or failure as bool</returns>
    public bool Delete(int id)
    {
        if (GetDbById(id) is not { } submarine)
        {
            return false;
        }
        
        _submarineRepository.Delete(submarine);

        return true;
    }

    /// <summary>
    /// Get all subs
    /// </summary>
    /// <returns>List of subs</returns>
    public List<api.Submarine> GetAll()
        => _submarineRepository.GetAll()
            .Select(s => new api.Submarine(s))
            .ToList();

    /// <summary>
    /// Get a sub by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Sub or null if not found</returns>
    public api.Submarine? GetById(int id) => GetDbById(id) switch
    {
        { } submarine => new api.Submarine(submarine),
        _ => null
    };

    /// <summary>
    /// Insert or update a sub
    /// </summary>
    /// <param name="submarine"></param>
    /// <returns>Success or failure as bool</returns>
    public bool Upsert(api.Submarine submarine)
    {
        try
        {
            var mappedSubmarine = submarine.MapToDb();
            var dbParts = _partRepository.GetByIds(mappedSubmarine.Parts.Select(p => p.PartId));
            mappedSubmarine.Parts.ForEach(p => p.Part = dbParts.Find(db => db.Id == p.PartId));

            if (mappedSubmarine.Parts.Select(sp => sp.Part).Any(p => p is null))
            {
                throw new ObjectNotFoundException();
            }
            
            if (GetDbById(submarine.Id) is not { } dbSubmarine)
            {
                mappedSubmarine.Id = default;
                mappedSubmarine.Parts.ForEach(p => p.SubmarineId = default);
                _submarineRepository.Insert(mappedSubmarine);
            }
            else
            {
                dbSubmarine.Copy(mappedSubmarine);
                _submarineRepository.Update(dbSubmarine);
            }
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    private db.Submarine? GetDbById(int id) => _submarineRepository.GetById(id);
}