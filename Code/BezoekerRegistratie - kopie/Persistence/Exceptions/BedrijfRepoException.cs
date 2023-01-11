using System.Runtime.Serialization;

namespace Persistence.Datalaag
{
    [Serializable]
    public class BedrijfRepoException : Exception
    {
        public BedrijfRepoException()
        {
        }

        public BedrijfRepoException(string? message) : base(message)
        {
        }

        public BedrijfRepoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BedrijfRepoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}