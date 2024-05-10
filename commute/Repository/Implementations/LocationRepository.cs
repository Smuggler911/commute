
using commute.Database;
using commute.Entity;
using commute.Repository.Intefaces;
using commute.Repository.Interfaces;

namespace commute.Repository.Implementations;

public class LocationRepository : ILocationRepository
{
    private readonly CommuteDbContext _context;

    public LocationRepository(CommuteDbContext context)
    {
        _context = context;
    }

    public List<Location> GetAll()
    {
        return _context.Set<Location>().ToList();
    }
}
