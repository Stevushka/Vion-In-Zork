using System;
using System.Collections.Generic;
using System.Text;

namespace Vion
{
    public class ConsoleOutputService : IOutputService
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
