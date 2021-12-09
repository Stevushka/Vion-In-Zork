using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Vion
{
    public class Game
    {
        public event EventHandler GameQuit;
        public event EventHandler GameInit;


        [JsonIgnore]
        public IOutputService Output { get; set; }

        [JsonIgnore]
        public IInputService Input { get; set; }

        public World World { get; private set; }

        public string StartingLocation { get; set; }

        public string WelcomeMessage { get; set; }

        [JsonIgnore]
        public string ExitMessage { get; set; }

        [JsonIgnore]
        public Player Player { get; private set; }

        [JsonIgnore]
        public bool Init { get; set; }

        [JsonIgnore]
        public bool ChoosingGender { get; set; }

        [JsonIgnore]
        public bool ChoosingName { get; set; }

        [JsonIgnore]
        public bool IsRunning { get; set; }

        [JsonIgnore]
        public Dictionary<string, Command> Commands { get; private set; }

        public Game(World world, Player player)
        {
            World = world;
            Player = player;

            Commands = new Dictionary<string, Command>()
            {
                { "QUIT", new Command("QUIT", new string[] { "QUIT", "Q", "BYE" }, Quit) },
                { "LOOK", new Command("LOOK", new string[] { "LOOK", "L" }, Look) },
                { "NORTH", new Command("NORTH", new string[] { "NORTH", "N" }, game => Move(game, Directions.NORTH)) },
                { "SOUTH", new Command("SOUTH", new string[] { "SOUTH", "S" }, game => Move(game, Directions.SOUTH)) },
                { "EAST", new Command("EAST", new string[] { "EAST", "E"}, game => Move(game, Directions.EAST)) },
                { "WEST", new Command("WEST", new string[] { "WEST", "W" }, game => Move(game, Directions.WEST)) },
                { "DAMAGE", new Command("DAMAGE", new string[] { "DAMAGE", "HURT", "PAIN"}, Damage) },
            };
        }

        private void Quit(Game game)
        {
            game.IsRunning = false;
            GameQuit?.Invoke(this, null);
        }

        public void Look(Game game)
        {
            Output.WriteLine(game.Player.Location.Description);
        }

        public void Move(Game game, Directions direction)
        {
            if (game.Player.Move(direction) == false)
            {
                Output.WriteLine("The way is shut!");
            }
        }

        public void Damage(Game game)
        {
            Player.TakeDamage(this);
        }

        public void Start(IInputService input, IOutputService output)
        {
            Input = input;
            Input.InputReceived += Input_StartInputReceived;

            Output = output;

            Init = true;
            ChoosingGender = false;
            ChoosingName = false;
            IsRunning = false;
        }

        public void ChooseGender()
        {
            Input.InputReceived -= Input_StartInputReceived;
            Input.InputReceived += Input_GenderInputReceived;

            Init = false;
            ChoosingGender = true;
        }

        public void ChooseName()
        {
            Input.InputReceived -= Input_GenderInputReceived;
            Input.InputReceived += Input_NameInputReceived;

            ChoosingGender = false;
            ChoosingName = true;
        }

        public void Play()
        {
            Input.InputReceived -= Input_NameInputReceived;
            Input.InputReceived += Input_InputReceived;

            ChoosingName = false;
            IsRunning = true;
        }

        private void Input_StartInputReceived(object sender, string commandString)
        {
            if (!string.IsNullOrWhiteSpace(commandString))
            {
                Output.WriteLine("Are You A Male Or Female?");
                ChooseGender();
            }
        }

        private void Input_GenderInputReceived(object sender, string commandString)
        {
            try
            {
                switch (Enum.Parse(typeof(Gender), commandString))
                {
                    case Gender.MALE:
                        this.Player.PlayerGender = Gender.MALE;
                        Output.WriteLine("What Is Your Name?");
                        ChooseName();
                        break;

                    case Gender.FEMALE:
                        this.Player.PlayerGender = Gender.FEMALE;
                        Output.WriteLine("What Is Your Name?");
                        ChooseName();
                        break;
                }
            }
            catch
            {
                Output.WriteLine("Are You A Male Or Female?");
            }
        }

        private void Input_NameInputReceived(object sender, string commandString)
        {
            if (!string.IsNullOrWhiteSpace(commandString))
            {
                this.Player.PlayerName = commandString;
                GameInit?.Invoke(this, null);
                Play();
            }
            else
            {
                Output.WriteLine("What Is Your Name?");
            }
        }

        private void Input_InputReceived(object sender, string commandString)
        {
            Command foundCommand = null;
            foreach(Command command in Commands.Values)
            {
                if(command.Verbs.Contains(commandString))
                {
                    foundCommand = command;
                    break;
                }
            }

            if (foundCommand != null)
            {
                foundCommand.Action(this);
                Player.Moves++;
            }
            else
            {
                Output.WriteLine("Unknown command.");
            }
        }

        public static Game Load(string filetext)
        {
            Game game = JsonConvert.DeserializeObject<Game>(filetext);
            game.Player = game.World.SpawnPlayer();

            return game;
        }
    }
}