using System;
using System.Collections.Generic;

namespace PlanetExpress.Models
{
  public class Location
  {
    public string Name { get; set; }
    public double EarthDiameters { get; set; }
    public Dictionary<string, Location> Neighbors { get; set; } //NOTE not in and of itself the linked list but will be utilized to implement a linked list

    public void AddNeighbor(Location neighborToAdd, bool autoAdd = true)
    {
      Neighbors.Add(neighborToAdd.Name, neighborToAdd);
      if (autoAdd)
      {
        neighborToAdd.AddNeighbor(this, false); //NOTE 'this' always references the object to the left of the method invocation (eg. earth.AddNieghbor())
      }
    }

    public void ListNeighbors()
    {
      Console.Clear();
      System.Console.WriteLine($"From {Name} you can travel to:");
      foreach (KeyValuePair<string, Location> kvp in Neighbors)
      {
        System.Console.WriteLine($"{kvp.Key}");
      }
    }

    public Location TravelToNeighbor(string locationName = "")
    {
      string destination = locationName;
      if (locationName == "")
      {
        System.Console.WriteLine("\n\nPlease enter the neighbor you'd like to travel to or else type 'menu' to return to main menu.");
        destination = Console.ReadLine();
      }
      if (destination == "menu")
      {
        return this;
      }
      if (Neighbors.ContainsKey(destination))
      {
        return Neighbors[destination];
      }
      return this;
    }

    public Location(string name, double diamtr)
    {
      Name = name;
      EarthDiameters = diamtr;
      Neighbors = new Dictionary<string, Location>();
    }
  }
}