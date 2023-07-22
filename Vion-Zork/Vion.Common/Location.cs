using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Vion
{
    public class Location : IEquatable<Location>
    {
        [JsonProperty(Order = 1)]
        public string Name { get; private set; }

        [JsonProperty(Order = 2)]
        public string Region { get; private set; }

        [JsonProperty(Order = 3)]
        public string Description { get; private set; }

        [JsonProperty(PropertyName = "Neighbors", Order = 4)]
        private Dictionary<Directions, string> NeighborNames { get; set; }

        [JsonIgnore]
        public IReadOnlyDictionary<Directions, Location> Neighbors { get; private set; }

        public static bool operator == (Location lhs, Location rhs)
        {
            if(ReferenceEquals(lhs, rhs))
            {
                return true;
            }

            if(lhs is null || rhs is null)
            {
                return false;
            }

            return lhs.Name == rhs.Name;
        }

        public static bool operator !=(Location lhs, Location rhs) => !(lhs == rhs);

        public override bool Equals(object obj) => obj is Location location ? this == location : false;

        public bool Equals(Location other) => this == other;

        public override string ToString() => Name;

        public override int GetHashCode() => Name.GetHashCode();

        public void UpdateNeighbors(World world) => Neighbors = (from entry in NeighborNames
                                                                 let location = world.LocationsByName.GetValueOrDefault(entry.Value)
                                                                 where location != null
                                                                 select (Directions: entry.Key, Location: location))
                                                                 .ToDictionary(pair => pair.Directions, pair => pair.Location);
    } 
}