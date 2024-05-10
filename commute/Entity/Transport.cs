using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace commute.Entity;

[Table("transport")]
public class Transport
{
    [Column("transport_id")]
    public int TransportId { get; set; }
    [Column("transport_name")]
    [MaxLength(250)]
    public string TransportName { get; set; }
    [Column("location_id")]
    [ForeignKey("Location")]
    public int FkLocationId { get; set; }
    public virtual Location Location { get; set; }
}