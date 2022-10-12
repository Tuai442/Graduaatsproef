using System.Runtime.Serialization;

namespace Controller.Exceptions
{
    [Serializable]
    internal class BedrijfException : Exception
    {
        public BedrijfException()
        {
        }

        public BedrijfException(string? message) : base(message)
        {
        }

        public BedrijfException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BedrijfException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}