namespace PlanetExpress.Models
{
  public class Moon : Location
  {
    public bool VisitedByArmstrong { get; set; }

    public Moon(string name, double diamtr, bool visited = false) : base(name, diamtr)
    {
      VisitedByArmstrong = visited;
    }
  }
}