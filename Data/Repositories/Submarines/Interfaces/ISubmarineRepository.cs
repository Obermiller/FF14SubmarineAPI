using Core.Models.Submarines.Schema;

namespace Data.Repositories.Submarines.Interfaces;

public interface ISubmarineRepository
{
    void Delete(Submarine submarine);
    List<Submarine> GetAll();
    Submarine? GetById(int id);
    void Insert(Submarine submarine);
    void Update(Submarine submarine);
}