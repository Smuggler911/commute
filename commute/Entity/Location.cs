using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace commute.Entity;
[Table("location")]
public class Location
{
    [Column("location_id")]
    public int LocationId { get; set; }
    [Column("location_name")]
    [MaxLength(250)]
    public string LocationName { get; set; }
    [Column("Latitude")]
    public double Latitude { get; set; }
    [Column("Longitude")]
    public double Longitude { get; set; }
}