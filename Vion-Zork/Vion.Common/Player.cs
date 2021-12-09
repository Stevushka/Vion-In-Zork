using Newtonsoft.Json;
using System;

namespace Vion
{
    public class Player
    {
        public event EventHandler<string> CityChanged;

        public event EventHandler<Room> LocationChanged;

        public event EventHandler<string> NameChanged;

        public event EventHandler<Gender?> GenderChanged;

        public event EventHandler<int> ScoreChanged;

        public event EventHandler<int> MovesChanged;

        public event EventHandler<int> ReceiveDamage;

        public World World { get; }

        [JsonIgnore]
        public string City
        {
            get
            {
                return _city;
            }

            set
            {
                if (_city != value)
                {
                    _city = value;
                    CityChanged?.Invoke(this, _city);
                }
            }
        }

        [JsonIgnore]
        public Room Location
        { 
            get
            {
                return _location;
            }

            set
            {
                if(_location != value)
                {
                    _location = value;
                    LocationChanged?.Invoke(this, _location);
                }
            }
        }

        [JsonIgnore]
        public string PlayerName
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name != value)
                {
                    _name = value;
                    NameChanged?.Invoke(this, _name);
                }
            }
        }

        [JsonIgnore]
        public Gender? PlayerGender
        {
            get
            {
                return _gender;
            }

            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    GenderChanged?.Invoke(this, _gender);
                }
            }
        }

        [JsonIgnore]
        public int Score
        {
            get
            {
                return _score;
            }

            set
            {
                if (_score != value)
                {
                    _score = value;
                    ScoreChanged?.Invoke(this, _score);
                }
            }
        }

        [JsonIgnore]
        public int Moves
        {
            get
            {
                return _moves;
            }

            set
            {
                if (_moves != value)
                {
                    _moves = value;
                    MovesChanged?.Invoke(this, _moves);
                }
            }
        }

        [JsonIgnore]
        public string LocationName
        {
            get
            {
                return Location?.Name;
            }
            set
            {
                Location = World?.RoomsByName.GetValueOrDefault(value);
            }
        }

        public Player(World world, string startingLocation)
        {
            World = world;
            LocationName = startingLocation;
            Moves = 0;
            Score = 0;
        }

        public void TakeDamage(Game game)
        {
            ReceiveDamage?.Invoke(game, 0);
        }

        public bool Move(Directions direction)
        {
            bool isValidMove = Location.Neighbors.TryGetValue(direction, out Room destination);
            if(isValidMove)
            {
                Location = destination;
            }

            return isValidMove;
        }

        private string _city;
        private Room _location;
        private string _name;
        private Gender? _gender;
        public int _moves;
        public int _score;
    }
}
