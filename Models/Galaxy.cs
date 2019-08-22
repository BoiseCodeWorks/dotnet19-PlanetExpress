// TODO build this model and implement the IGalaxy interface
using System;
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

    public void AddNeighbor(IGalaxy neighbor, bool autoAdd = true)
    {
      Neighbors.Add(neighbor.Name, neighbor);
      if (autoAdd)
      {
        neighbor.AddNeighbor(this, false);
      }
    }

    public void ListNeighbors()
    {
      Console.Clear();
      System.Console.WriteLine($"From {Name} you can travel to: ");
      foreach (KeyValuePair<string, IGalaxy> kvp in Neighbors)
      {
        Console.WriteLine($"{kvp.Key}'s Launch Planet: {kvp.Value.InterGalacticLaunchPlanet.Name}");
      }
    }

    public IGalaxy TravelToNeighbor(string destination = "")
    {

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