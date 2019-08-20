using System;
using System.Collections.Generic;

namespace PlanetExpress.Models
{
  public class Planet : Location
  {
    public Dictionary<string, string> GuestBook { get; set; }

    public Location DisplayOptions()
    {
      Location newDestination = this;

      System.Console.WriteLine("Enter 'sign' to sign the GuestBook or else enter 'go <location>' to go to that location.");

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
        case "go":
          newDestination = this.TravelToNeighbor(option);
          break;
        default:
          System.Console.WriteLine("I'm not sure what you meant.");
          break;
      }
      return newDestination;
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

    public Planet(string name, double diamtr) : base(name, diamtr)
    {
      GuestBook = new Dictionary<string, string>();
    }
  }
}