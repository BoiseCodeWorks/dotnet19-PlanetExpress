using System.Collections.Generic;

namespace PlanetExpress.Models
{
  public class Planet : Location
  {
    public Dictionary<string, string> GuestBook { get; set; }
    public Planet(string name, double diamtr) : base(name, diamtr)
    {
      GuestBook = new Dictionary<string, string>();
    }
  }
}