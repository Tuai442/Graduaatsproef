﻿using System.Runtime.Serialization;

namespace Controller.Exceptions
{
    [Serializable]
    internal class EmailException : Exception
    {
        public EmailException()
        {
        }

        public EmailException(string? message) : base(message)
        {
        }

        public EmailException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}