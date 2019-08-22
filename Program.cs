using System;

namespace PlanetExpress
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Clear();
      App app = new App();
      app.Setup();
      app.Run();
    }
  }
}