using System.Collections.Generic;
using PlanetExpress.Models;

namespace PlanetExpress.Interfaces
{
    public interface IGalaxy
    {
        string Name { get; set; } //NOTE eg., "Milky Way"
        string Shape { get; set; } //NOTE eg., "Elliptical", "Spiral"
        Dictionary<string, IGalaxy> Neighbors { get; set; } //NOTE eg., "Andromeda"
        Planet InterGalacticLaunchPlanet { get; set; } //NOTE eg., "Earth"

        void ListNeighbors();
        void AddNeighbor(IGalaxy neighbor);
        IGalaxy TravelToNeighbor(string destination = "");

        // NOTE methods above are how we implemented the logic for a linked list between locations.
        // You may either follow or modify this interface to fit the purposes of your InterGalatic Application  
    }
}