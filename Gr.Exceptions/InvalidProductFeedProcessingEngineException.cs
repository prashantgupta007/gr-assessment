using System;

namespace Gr.Exceptions
{
    public class InvalidProductFeedProcessingEngineException : Exception
    {
        public InvalidProductFeedProcessingEngineException()
        {
        }

        public InvalidProductFeedProcessingEngineException(string message)
            : base(message)
        {
        }

        public InvalidProductFeedProcessingEngineException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
