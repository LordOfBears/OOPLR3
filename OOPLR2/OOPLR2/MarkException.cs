using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLR3
{
    class MarkException : Exception
    {
        public MarkException(string message) : base(message) { }
    }
}
