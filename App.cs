using System;
using PlanetExpress.Interfaces;
using PlanetExpress.Models;

namespace PlanetExpress
{
  public class App
  {
    public IGalaxy CurrentGalaxy { get; set; }
    public Location CurrentLocation { get; set; }
    public bool SpaceTraveling { get; set; }

    public void Setup()
    {
      //NOTE instantiating raw data for our application
      Planet mercury = new Planet("Mercury", 0.38);
      Planet venus = new Planet("Venus", 0.94);
      Planet earth = new Planet("Earth", 1, true);
      Planet mars = new Planet("Mars", 0.98);
      Planet jupiter = new Planet("Jupiter", 23.7);
      Planet saturn = new Planet("Saturn", 21);
      Planet uranus = new Planet("Uranus", 18);
      Planet neptune = new Planet("Neptune", 17.5);
      Planet pluto = new Planet("Pluto", 0.17);
      Planet persephone = new Planet("Persephone", 15, true);
      Planet zeus = new Planet("Zeus", 30);
      Planet polaris = new Planet("Polaris", 2, true);

      Galaxy andromeda = new Galaxy("Andromeda", "elliptical", persephone);
      Galaxy milkyway = new Galaxy("Milkyway", "spiral", earth);
      Galaxy serenity = new Galaxy("Serenity", "disc", polaris);

      Moon moon = new Moon("Moon", 0.28, true);
      Moon luna = new Moon("Luna", 0.28);
      Moon bloodRed = new Moon("BloodRed", 0.28);
      Moon dark = new Moon("Sattellite", 0.28);
      Moon charon = new Moon("Charon", 0.16);

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
      jupiter.AddNeighbor(dark);

      pluto.AddNeighbor(bloodRed);

      persephone.AddNeighbor(zeus);
      polaris.AddNeighbor(charon);

      milkyway.AddNeighbor(andromeda);
      andromeda.AddNeighbor(serenity);


      CurrentLocation = earth;
      CurrentGalaxy = milkyway;
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
      //TODO modify this menu to include options for travelling between galaxies and for travelling between locations within the CurrentGalaxy

      //see if CurrentLocation is of data type Planet
      //  if it is see if it is the InterGalacticLaunchPlanet
      //    if it is then menu should include options for galaxy travel, location travel, and quit
      //  else menu should include location travel and quit
      //else menu should include location travel and quit

      string menuOptions = "(P) to list neighbor planetary objects. (Q) to quit.";
      bool InterGalacticTravel = false;

      if (CurrentLocation is Planet)
      {
        Planet littlePlanet = (Planet)CurrentLocation;
        if (littlePlanet.InterGalacticLaunchSite)
        {
          menuOptions = "(G) to list neighbor galaxies. " + menuOptions;
          InterGalacticTravel = true;
        }
      }

      System.Console.WriteLine(menuOptions);
      switch (Console.ReadLine())
      {
        case "G":
        case "g":
          if (!InterGalacticTravel)
          {
            System.Console.WriteLine($"Must be at {CurrentGalaxy.InterGalacticLaunchPlanet.Name} for InterGalactic Travel.");
            break;
          }
          CurrentGalaxy.ListNeighbors();
          CurrentGalaxy = CurrentGalaxy.TravelToNeighbor();
          CurrentLocation = CurrentGalaxy.InterGalacticLaunchPlanet;
          break;
        case "P":
        case "p":
          CurrentLocation.ListNeighbors();
          if (CurrentLocation is Moon)
          {
            CurrentLocation = CurrentLocation.TravelToNeighbor();
          }
          else
          {
            Planet currentPlanet = (Planet)CurrentLocation; //NOTE the right side logic is type casting to change from data type Location to Planet so that we can access the method DisplayOptions.
            CurrentLocation = currentPlanet.DisplayOptions();
          }
          break;
        case "Q":
        case "q":
          SpaceTraveling = false;
          break;
        default:
          System.Console.WriteLine("Houston we have a problem.");
          break;
      }
    }
  }
}