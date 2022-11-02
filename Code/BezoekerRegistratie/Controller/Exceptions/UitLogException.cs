using System.Runtime.Serialization;

namespace Controller.Exceptions
{
    [Serializable]
    public class UitLogException : Exception
    {
        public UitLogException()
        {
        }

        public UitLogException(string? message) : base(message)
        {
        }

        public UitLogException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UitLogException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}