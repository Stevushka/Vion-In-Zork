using System;
using System.Collections.Generic;
using System.Text;

namespace Zork
{
    public class ConsoleInputService : IInputService
    {
        public event EventHandler<string> InputReceived;

        public void ProcessInput()
        {
            string inputString = Console.ReadLine().Trim().ToUpper();
            InputReceived?.Invoke(this, inputString);
        }
    }
}
