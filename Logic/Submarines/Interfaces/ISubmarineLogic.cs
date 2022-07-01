using Core.Models.Submarines.API;

namespace Logic.Submarines.Interfaces;

public interface ISubmarineLogic
{
    bool Delete(int id);
    List<Submarine> GetAll();
    Submarine? GetById(int id);
    bool Upsert(Submarine part);
}