using System;
using PlanetExpress.Models;

namespace PlanetExpress
{
  public class App
  {
    public Location CurrentLocation { get; set; }
    public bool SpaceTraveling { get; set; }

    public void Setup()
    {
      //NOTE instantiating raw data for our application
      Planet mercury = new Planet("Mercury", 0.38);
      Planet venus = new Planet("Venus", 0.94);
      Planet earth = new Planet("Earth", 1);
      Planet mars = new Planet("Mars", 0.98);
      Planet jupiter = new Planet("Jupiter", 23.7);
      Planet saturn = new Planet("Saturn", 21);
      Planet uranus = new Planet("Uranus", 18);
      Planet neptune = new Planet("Neptune", 17.5);
      Planet pluto = new Planet("Pluto", 0.17);

      Moon moon = new Moon("Moon", 0.28, true);
      Moon luna = new Moon("Luna", 0.28);
      Moon bloodRed = new Moon("BloodRed", 0.28);
      Moon dark = new Moon("Sattellite", 0.28);

      // NOTE adding neighbors to the objects
      mercury.AddNeighbor(venus);
      venus.AddNeighbor(earth);
      earth.AddNeighbor(mars);
      mars.AddNeighbor(jupiter);
      jupiter.AddNeighbor(saturn);
      saturn.AddNeighbor(uranus);
      uranus.AddNeighbor(neptune);
      neptune.AddNeighbor(pluto);

      earth.AddNeighbor(moon);

      jupiter.AddNeighbor(luna);
      jupiter.AddNeighbor(bloodRed);
      jupiter.AddNeighbor(dark);

      pluto.AddNeighbor(bloodRed);

      CurrentLocation = earth;
      SpaceTraveling = true;
    }

    public void Run()
    {
      System.Console.WriteLine("Welcome Space Traveller\n\n");
      while (SpaceTraveling)
      {
        DisplayMenu();
      }
    }

    public void DisplayMenu()
    {
      System.Console.WriteLine("1) List neighbors\n2) Quit");
      switch (Console.ReadLine())
      {
        case "1":
          CurrentLocation = CurrentLocation.ListNeighbors();
          break;
        case "2":
          SpaceTraveling = false;
          break;
        default:
          System.Console.WriteLine("Houston we have a problem.\nSimply type 1 or 2.");
          break;
      }
    }
  }
}