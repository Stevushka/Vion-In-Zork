using System;
using System.Collections.Generic;
using System.Text;

namespace Vion
{
    public interface IOutputService
    {
        void Write(string value);

        void WriteLine(string value);
    }
}
