// TODO build this model and implement the IGalaxy interface
using System.Collections.Generic;
using PlanetExpress.Interfaces;

namespace PlanetExpress.Models
{
  public class Galaxy : IGalaxy
  {
    public string Name { get; set; }
    public string Shape { get; set; }
    public Dictionary<string, IGalaxy> Neighbors { get; set; }
    public Planet InterGalacticLaunchPlanet { get; set; }

    public void AddNeighbor(IGalaxy neighbor)
    {

    }

    public void ListNeighbors()
    {

    }

    public IGalaxy TravelToNeighbor(string destination = "")
    {
      return null;
    }

    public Galaxy(string name, string shape, Planet launchPlanet)
    {
      Name = name;
      Shape = shape;
      Neighbors = new Dictionary<string, IGalaxy>();
      InterGalacticLaunchPlanet = launchPlanet;
    }
  }

}