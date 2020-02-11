using System;

namespace Gr.Exceptions
{
    public class InvalidCSVFormatException : Exception
    {
        public InvalidCSVFormatException()
        {
        }

        public InvalidCSVFormatException(string message)
            : base(message)
        {
        }

        public InvalidCSVFormatException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
