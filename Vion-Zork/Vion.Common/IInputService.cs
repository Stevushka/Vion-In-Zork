using System;

namespace Vion
{
    public interface IInputService
    {
        event EventHandler<string> InputReceived;
    }
}
