using System.Runtime.Serialization;

namespace Controller.Exceptions
{
    [Serializable]
    internal class emailServiceException : Exception
    {
        public emailServiceException()
        {
        }

        public emailServiceException(string? message) : base(message)
        {
        }

        public emailServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected emailServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}