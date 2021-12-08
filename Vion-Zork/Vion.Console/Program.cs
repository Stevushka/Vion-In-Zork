using System;
using Zork;
using System.IO;

namespace Zork
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