using System;

namespace Gr.Exceptions
{
    public class InvalidJSONSchemaException : Exception
    {
        public InvalidJSONSchemaException()
        {
        }

        public InvalidJSONSchemaException(string message)
            : base(message)
        {
        }

        public InvalidJSONSchemaException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
