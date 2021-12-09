using System;
using Vion;
using System.IO;

namespace Vion
{
    class Program
    {

        private static Game game = null;
        private static ConsoleOutputService output;
        private static ConsoleInputService input;

        static void Main(string[] args)
        {
            const string defaultRoomsFilename = "Zork.Json";
            string gameFilename = (args.Length > 0 ? args[(int)CommandLineArguments.GameFilename] : defaultRoomsFilename);

            game = Game.Load(File.ReadAllText(gameFilename));

            input = new ConsoleInputService();
            output = new ConsoleOutputService();

            output.WriteLine(string.IsNullOrWhiteSpace(game.WelcomeMessage) ? "Welcome to Zork!" : game.WelcomeMessage);
            game.Start(input, output);

            while (game.Init)
            {
                output.WriteLine("Press Any Key To Start");
                output.Write("\n> ");
                input.ProcessInput();
            }

            while (game.ChoosingGender)
            {
                if(game.Player.PlayerGender == null)
                {
                    output.WriteLine("Are You A Male Or Female?");
                    output.Write("\n> ");
                    input.ProcessInput();
                }
            }

            while (game.ChoosingName)
            {
                if(string.IsNullOrEmpty(game.Player.PlayerName))
                {
                    output.WriteLine("What Is Your Name?");
                    output.Write("\n> ");
                    input.ProcessInput();
                }
            }

            Room previousRoom = null;
            while (game.IsRunning)
            {
                output.WriteLine(game.Player.Location.Name);
                if (previousRoom != game.Player.Location)
                {
                    game.Look(game);
                    previousRoom = game.Player.Location;
                }

                output.Write("\n> ");
                input.ProcessInput();
            }
        }

        private enum CommandLineArguments
        {
            GameFilename = 0
        }
    }
}