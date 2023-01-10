using System.Runtime.Serialization;

namespace Persistence.Exceptions
{
    [Serializable]
    public class AfspraakRepoException : Exception
    {
        public AfspraakRepoException()
        {
        }

        public AfspraakRepoException(string? message) : base(message)
        {
        }

        public AfspraakRepoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AfspraakRepoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}