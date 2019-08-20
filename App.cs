using System;
using PlanetExpress.Models;

namespace PlanetExpress
{
  public class App
  {


    public void Setup()
    {
      Planet mercury = new Planet("Mercury", 0.38);
      Planet venus = new Planet("Venus", 0.94);
      Planet earth = new Planet("Earth", 1);
      Planet mars = new Planet("Earth", 0.98);
      Planet jupiter = new Planet("Earth", 23.7);
      Planet saturn = new Planet("Earth", 21);
      Planet uranus = new Planet("Earth", 18);
      Planet neptune = new Planet("Earth", 17.5);
      Planet pluto = new Planet("Earth", 0.17);

      Moon moon = new Moon("Moon", 0.28, true);
      Moon luna = new Moon("Luna", 0.28);
      Moon bloodRed = new Moon("BloodRed", 0.28);
      Moon dark = new Moon("Sattellite", 0.28);

      earth.Neighbors.Add(venus.Name, venus);
      earth.Neighbors.Add(moon.Name, moon);

    }
  }
}