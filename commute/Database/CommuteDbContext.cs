using commute.Entity;
using Microsoft.EntityFrameworkCore;

namespace commute.Database;

public class CommuteDbContext :DbContext
{
    public DbSet<Location>Locations { get; set; }
    public DbSet<Transport>Transports { get; set; }
    
    private readonly IConfiguration _configuration;
    
     
    public CommuteDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Commute_DB"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>().HasData(new Location[]
        {
           new Location{LocationId = 1,LocationName = "CityA",Latitude = 19.045765,Longitude = 10.4636},
           new Location{LocationId = 2,LocationName = "CityB",Latitude = 20.045765,Longitude = 9.5636},
           new Location{LocationId = 3,LocationName = "CityC",Latitude = 18.67765,Longitude = 11.46746},
           new Location{LocationId = 4,LocationName = "CityD",Latitude = 30.0655765,Longitude = 8.6636},
        });
        modelBuilder.Entity<Transport>().HasData(new Transport[]
        {  
            new Transport{TransportId = 1,TransportName = "Airplane",FkLocationId = 1},
            new Transport{TransportId = 2,TransportName = "Airplane",FkLocationId = 2},
            new Transport{TransportId = 3,TransportName = "Bus",FkLocationId = 1},
            new Transport{TransportId = 4,TransportName = "Bus",FkLocationId = 3},
            new Transport{TransportId = 5,TransportName = "Train",FkLocationId = 3},
            new Transport{TransportId = 6,TransportName = "Bus",FkLocationId = 4},
        });
    }
}