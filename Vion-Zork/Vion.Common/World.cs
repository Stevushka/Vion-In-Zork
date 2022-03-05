using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Vion
{
    public class World
    {
        public HashSet<Location> Locations { get; set; }

        [JsonIgnore]
        public Dictionary<string, Location> LocationsByName => new Dictionary<string, Location>(mLocationsByName);

        public Player SpawnPlayer() => new Player(this, StartingLocation);

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            mLocationsByName = Locations.ToDictionary(location => location.Name, location => location);

            foreach(Location location in Locations)
            {
                location.UpdateNeighbors(this);
            }
        }

        [JsonProperty]
        private string StartingLocation { get; set; }

        private Dictionary<string, Location> mLocationsByName;
    }
}