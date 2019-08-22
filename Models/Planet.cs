using System;
using System.Collections.Generic;

namespace PlanetExpress.Models
{
  public class Planet : Location
  {
    public bool InterGalacticLaunchSite { get; set; } //NOTE You may only travel to other Galaxies if your App's CurrentLocation is an InterGalacticLaunchSite
    public Dictionary<string, string> GuestBook { get; set; }

    public Location DisplayOptions(App rocketship)
    {
      Location newDestination = this;

      System.Console.WriteLine("Enter 'sign' to sign the GuestBook or 'fuel' to collect fuel.  Otherwise enter 'go <location>' to go to that location.");

      // NOTE helpful for final project
      string userInput = Console.ReadLine();
      string[] words = userInput.Split(' '); //NOTE docs on Split() - https://docs.microsoft.com/en-us/dotnet/api/system.string.split?view=netframework-4.8
      string command = words[0];
      string option = "";
      if (words.Length > 1)
      {
        option = words[1];
      }
      switch (command)
      {
        case "sign":
          SignGuestBook();
          break;
        case "fuel":
          if (CheckFuel())
          {
            GetFuel(rocketship);
          }
          else
          {
            Console.WriteLine("Sorry your out of luck!!");
          }
          break;
        case "go":
          newDestination = this.TravelToNeighbor(option);
          break;
        default:
          System.Console.WriteLine("I'm not sure what you meant.");
          break;
      }
      return newDestination;
    }

    public bool CheckFuel()
    {
      return Fuel > 0;
    }
    public void GetFuel(App rocketship)
    {
      rocketship.RocketFuel += Fuel;
      Console.WriteLine($"You gained {Fuel} fuel. your current fuel  supply is {rocketship.RocketFuel}");
      Fuel = 0;

    }


    public void SignGuestBook()
    {
      System.Console.WriteLine($"Enter your name Space Traveller and a message for the inhabitants of {this.Name}.\n");
      System.Console.Write("Name: ");
      string name = Console.ReadLine();
      System.Console.Write("\nMessage: ");
      string message = Console.ReadLine();
      GuestBook.Add(name, message);
    }

    public void ExploreGuestBook()
    {
      //TODO list the names and messages of InterGalactic Travellers before you
    }
    public Planet(string name, double diamtr, bool launchSite = false) : base(name, diamtr)
    {
      InterGalacticLaunchSite = launchSite;
      GuestBook = new Dictionary<string, string>();
    }


  }
}