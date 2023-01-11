using System.Runtime.Serialization;

namespace Persistence.Datalaag
{
    [Serializable]
    public class WerknemerRepoException : Exception
    {
        public WerknemerRepoException()
        {
        }

        public WerknemerRepoException(string? message) : base(message)
        {
        }

        public WerknemerRepoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WerknemerRepoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}