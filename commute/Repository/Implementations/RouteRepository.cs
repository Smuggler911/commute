using commute.Database;
using commute.Entity;
using commute.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Route = commute.Entity.Route;

namespace commute.Repository.Implementations;

public class RouteRepository : IRouteRepository
{
    private readonly CommuteDbContext _context;

    public RouteRepository(CommuteDbContext context)
    {
        _context = context;
    }
    public Route CalculateDistance(string from , string to)
    {   
        var fromQuery = _context.Set<Location>().FromSql($"Select * from location where location_name ={from}").First();
        var toQuery = _context.Set<Location>().FromSql($"Select * from location where  location_name={to}").First();
        
        double radiansOverDegrees = (Math.PI / 180.0);
        double SLattitudeRadians = fromQuery.Latitude * radiansOverDegrees;
        double SLongitudeRadians = fromQuery.Longitude * radiansOverDegrees;
        double ELattitudeRadians = toQuery.Latitude * radiansOverDegrees;
        double ELongitudeRadians = toQuery.Longitude * radiansOverDegrees;
        
        double dLongitude = ELongitudeRadians - SLongitudeRadians;
        double dLattitude = ELattitudeRadians - SLattitudeRadians;
        
        double result = Math.Pow(Math.Sin(dLattitude / 2.0), 2.0) +
                     Math.Cos(SLattitudeRadians) * Math.Cos(ELattitudeRadians) *
                     Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);
        double distance = 3956.0 * 2.0 * Math.Atan2(Math.Sqrt(result), Math.Sqrt(1.0 - result));

        int speed = 120;
        var time = distance / speed;
        var rt = new Route();
        
        rt.Distance = Math.Round(distance);
        rt.Time = Math.Round(time);
        
        return rt;

    }
    
}
