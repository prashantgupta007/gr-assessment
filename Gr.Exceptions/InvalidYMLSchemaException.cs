using System;

namespace Gr.Exceptions
{
    public class InvalidYMLSchemaException : Exception
    {
        public InvalidYMLSchemaException()
        {
        }

        public InvalidYMLSchemaException(string message)
            : base(message)
        {
        }

        public InvalidYMLSchemaException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
