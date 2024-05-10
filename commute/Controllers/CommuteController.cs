using commute.Entity;
using commute.Repository.Intefaces;
using commute.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Route = Microsoft.AspNetCore.Routing.Route;

namespace commute.Controllers;
[ApiController]
[Route("[controller]")]
public class CommuteController
{
    private readonly ILogger<CommuteController> _logger;
    private  readonly ILocationRepository _locationRepository;
    private readonly IRouteRepository _routeRepository;
    
    public CommuteController(ILogger<CommuteController> logger,ILocationRepository locations,IRouteRepository routes)
    {
        _logger = logger;
        _locationRepository = locations;
        _routeRepository = routes;
    }
    

    [HttpGet("/locations")]
    public JsonResult Get()
    {
        return new  JsonResult(_locationRepository.GetAll());
    }

    [HttpGet("/calc_distance/{from}/{to}")]
    public JsonResult GetDistance(string to,string from)
    {
        return new JsonResult(_routeRepository.CalculateDistance(to, from));
    }
}