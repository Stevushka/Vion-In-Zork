﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Vion
{
    public class Player
    {
        #region Event Handlers

            public event EventHandler<string> RegionChanged;

            public event EventHandler<Location> LocationChanged;

            public event EventHandler<string> NameChanged;

            public event EventHandler<Gender?> GenderChanged;

            public event EventHandler<int> ScoreChanged;

            public event EventHandler<int> GoldChanged;

            public event EventHandler<int> LevelChanged;

            public event EventHandler<int> HealthChanged;

            public event EventHandler<int> MaxHealthChanged;

            public event EventHandler<string> CompassChanged;

            public event EventHandler<int> ReceiveDamage;

        #endregion

        public World World { get; }

        #region Game Properties

            [JsonIgnore]
            public string Region
            {
                get
                {
                    return _region;
                }

                set
                {
                    if (_region != value)
                    {
                        _region = value;
                        RegionChanged?.Invoke(this, _region);
                    }
                }
            }

            [JsonIgnore]
            public Location Location
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

                        Region = value.Region;
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
                    Location = World?.LocationsByName.GetValueOrDefault(value);
                }
            }

            [JsonIgnore]
            public string Compass
            {
                get
                {
                    return _compass;
                }

                set
                {
                    if (_compass != value)
                    {
                        _compass = value;
                        CompassChanged?.Invoke(this, _compass);
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
                        //GoldChanged?.Invoke(this, _moves);
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

        #endregion

        #region Player Properties

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
            public int Level
            {
                get
                {
                    return _level;
                }

                set
                {
                    if (true)
                    {
                        _level = value;
                        LevelChanged?.Invoke(this, _level);
                    }
                }
            }

            [JsonIgnore]
            public int Health
            {
                get
                {
                    return _health;
                }

                set
                {
                    if (value >= _maxHealth)
                        _health = _maxHealth;
                    else
                        _health = value;
                    HealthChanged?.Invoke(this, _health);
                }
            }

            [JsonIgnore]
            public int MaxHealth
            {
                get
                {
                    return _maxHealth;
                }

                set
                {
                    _maxHealth = value;
                    MaxHealthChanged?.Invoke(this, _maxHealth);
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
            public int Gold
            {
                get
                {
                    return _gold;
                }

                set
                {
                    if (true)
                    {
                        _gold = value;
                        GoldChanged?.Invoke(this, _gold);
                    }
                }
            }

        #endregion

        #region Inventory Properties

            [JsonIgnore]
            public List<Item> Inventory
            {
                get
                {
                    return game.Player._inventory;
                }
                set
                {
                    game.Player._inventory = value;
                }
            }

            [JsonIgnore]
            public Weapon? EquippedWeapon
            {
                get
                {
                    return _equippedWeapon;
                }

                set
                {
                    if (_equippedWeapon != value)
                    {
                        _equippedWeapon = value;
                    }
                }
            }

            [JsonIgnore]
            public Armor? EquippedArmor
            {
                get
                {
                    return _equippedArmor;
                }

                set
                {
                    if (_equippedArmor != value)
                    {
                        _equippedArmor = value;
                    }
                }
            }

            [JsonIgnore]
            public Weapon Fists
            {
                get
                {
                    return _fists;
                }
            }

        #endregion

        public Player(World world, string startingLocation)
        {
            World = world;
            LocationName = startingLocation;
            Gold = 0;
            Level = 1;
            Score = 0;
            Compass = "--";
            MaxHealth = 20;
            Health = MaxHealth;

            Inventory = new List<Item>()
            {
                new Weapon("sword", 10f, 5f, 0.80f)
            };

            EquippedWeapon = Inventory[0];
        }

        public void TakeDamage(Game game)
        {
            ReceiveDamage?.Invoke(game, 0);
        }

        public bool Move(Directions direction)
        {
            bool isValidMove = Location.Neighbors.TryGetValue(direction, out Location destination);
            if(isValidMove)
            {
                Location = destination;
            }

            return isValidMove;
        }

        #region Member Vars

            private Location _location;
            private List<Item> _inventory;
            private Weapon? _equippedWeapon;
            private Armor? _equippedArmor;
            private string _region;
            private string _name;
            private Gender? _gender;
            private string _compass;
            private int _gold;
            private int _level;
            private int _score;
            private int _moves;
            private int _health;
            private int _maxHealth;

            private Weapon _fists = new Weapon("Fists", 0f, 1f, 0.9f);

        #endregion
    }
}
