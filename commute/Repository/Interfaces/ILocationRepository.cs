using commute.Entity;

namespace commute.Repository.Interfaces;

public interface ILocationRepository
{
    public List<Location> GetAll();
}