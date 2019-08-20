using System.Collections.Generic;

namespace PlanetExpress.Models
{
  public class Location
  {
    public string Name { get; set; }
    public double EarthDiameters { get; set; }
    public Dictionary<string, Location> Neighbors { get; set; } //NOTE not in and of itself the linked list but will be utilized to implement a linked list

    public Location(string name, double diamtr)
    {
      Name = name;
      EarthDiameters = diamtr;
      Neighbors = new Dictionary<string, Location>();
    }
  }
}