using System.Runtime.Serialization;

namespace Persistence
{
    public class BezoekerRepoException : Exception
    {
        public BezoekerRepoException()
        {
        }

        public BezoekerRepoException(string? message) : base(message)
        {
        }

        public BezoekerRepoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BezoekerRepoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}