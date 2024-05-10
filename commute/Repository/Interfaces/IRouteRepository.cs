using commute.Entity;
using Route = commute.Entity.Route;

namespace commute.Repository.Interfaces;

public interface IRouteRepository
{
    public Route CalculateDistance(string from, string to);
    
}