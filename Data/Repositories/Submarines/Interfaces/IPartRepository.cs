using Core.Models.Submarines.Schema;

namespace Data.Repositories.Submarines.Interfaces;

public interface IPartRepository
{
    void Delete(Part part);
    List<Part> GetAll();
    List<Part> GetByIds(IEnumerable<int> ids);
    Part? GetById(int id);
    void Insert(Part part);
    void Update(Part part);
}