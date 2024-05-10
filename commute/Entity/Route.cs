using System.ComponentModel.DataAnnotations.Schema;

namespace commute.Entity;

public class Route
{
  public double Distance { get; set; }
  public double Time { get; set; }
  
}