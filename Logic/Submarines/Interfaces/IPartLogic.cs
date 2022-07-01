using Core.Models.Submarines.API;

namespace Logic.Submarines.Interfaces;

public interface IPartLogic
{
    bool Delete(int id);
    List<Part> GetAll();
    Part? GetById(int id);
    bool Upsert(Part part);
}