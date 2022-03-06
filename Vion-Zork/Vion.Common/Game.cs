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

        public string WelcomeMessage { get; set; }

        [JsonIgnore]
        public string ExitMessage { get; set; }

        [JsonIgnore]
        public Player Player { get; private set; }

        [JsonIgnore]
        private string[] CommandsThatIgnoreMoves = { "STATS", "HELP", "DEBUG" };

        #region Game States Variables

            [JsonIgnore]
            public bool Init { get; set; }

            [JsonIgnore]
            public bool ChoosingGender { get; set; }

            [JsonIgnore]
            public bool ChoosingName { get; set; }

            [JsonIgnore]
            public bool IsRunning { get; set; }

        #endregion

        [JsonIgnore]
        public Dictionary<string, Command> Commands { get; private set; }

        public Game(World world, Player player)
        {
            World = world;
            Player = player;

            Commands = new Dictionary<string, Command>()
            {
                { "DEBUG",  new Command("DEBUG",    new string[] { "DEBUG" },               "Syntax: 'Debug <Debug Command>'",          Debug) },
                { "HELP",   new Command("HELP",     new string[] { "HELP"},                 "Syntax: 'Help'\nSyntax: 'Help <Command>'", Help) },
                { "STATS",  new Command("STATS",    new string[] { "STATS", "STATISTICS"},  "Syntax: 'Stats'",                          Stats)},
                { "LOOK",   new Command("LOOK",     new string[] { "LOOK", "L" },           "Syntax: 'Look'",                           Look) },
                { "NORTH",  new Command("NORTH",    new string[] { "NORTH", "N" },          "Syntax: 'North'",                          game => Move(game, Directions.NORTH)) },
                { "SOUTH",  new Command("SOUTH",    new string[] { "SOUTH", "S" },          "Syntax: 'South'",                          game => Move(game, Directions.SOUTH)) },
                { "EAST",   new Command("EAST",     new string[] { "EAST", "E"},            "Syntax: 'East'",                           game => Move(game, Directions.EAST)) },
                { "WEST",   new Command("WEST",     new string[] { "WEST", "W" },           "Syntax: 'West'",                           game => Move(game, Directions.WEST)) },
                { "QUIT",   new Command("QUIT",     new string[] { "QUIT", "Q", "BYE" },    "Syntax: 'Quit'",                           Quit) },
            };
        }

        #region Commands

            private void Debug(Game game, string[] args)
            {
                if (args[1].ToUpper() == "PRINT")
                {
                    Output.WriteLine("Print!");
                }

                if (args[1].ToUpper() == "DAMAGE")
                {
                    Player.TakeDamage(this);
                }
            }
        
            private void Help(Game game, string[] args)
            {
                if(args.Length > 1)
                {
                    Command foundCommand = null;
                    foreach (Command command in Commands.Values)
                    {
                        if (command.Verbs.Contains(args[1]))
                        {
                            foundCommand = command;
                            break;
                        }
                    }

                    if (foundCommand != null)
                    {
                        Output.WriteLine(foundCommand.HelpText);
                    }
                    else
                    {
                        Output.WriteLine("Help Can't find " + args[1] + ".");
                    }
                }
                else
                {
                    string helpText = "";

                    for (int i = 1; i < Commands.Count; i++)
                    {
                        helpText += ("\n" + Commands.Keys.ElementAt<string>(i));
                    }

                    Output.WriteLine("Commands: " + helpText);
                }
            }

            private void Stats(Game game)
            {
                Output.WriteLine("Moves: " + Player.Moves);
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

        #endregion

        #region Switch Game States

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

        #endregion

        #region Input States

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
                string[] commandArray = commandString.Split();

                Command foundCommand = null;
                foreach(Command command in Commands.Values)
                {
                    if(command.Verbs.Contains(commandArray[0]))
                    {
                        foundCommand = command;
                        break;
                    }
                }

                if (foundCommand != null)
                {
                    if(foundCommand.Action != null)
                    {
                        foundCommand.Action(this);
                    }
                    else if(foundCommand.ComplexAction != null)
                    {
                        foundCommand.ComplexAction(this, commandArray);
                    }
                    
                    if(!CommandsThatIgnoreMoves.Contains(foundCommand.Name))
                        Player.Moves++;
                }
                else
                {
                    Output.WriteLine("Unknown command.");
                }
            }

        #endregion

        public static Game Load(string filetext)
        {
            Game game = JsonConvert.DeserializeObject<Game>(filetext);
            game.Player = game.World.SpawnPlayer();

            return game;
        }
    }
}