﻿using System.Runtime.Serialization;

namespace Controller.Exceptions
{
    [Serializable]
    public class BezoekerException : Exception
    {
        public BezoekerException()
        {
        }

        public BezoekerException(string? message) : base(message)
        {
        }

        public BezoekerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BezoekerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}