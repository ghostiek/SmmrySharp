using System;
using System.Collections.Generic;
using System.Text;

namespace SmmrySharp
{
    public class SmmryException : Exception
    {
        public SmmryException() : base() { }

        public SmmryException(string message) : base(message) { }

        public SmmryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
