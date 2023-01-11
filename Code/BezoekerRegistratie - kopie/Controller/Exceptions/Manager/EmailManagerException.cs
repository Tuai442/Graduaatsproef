using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Exceptions.Manager
{
    public class EmailManagerException : Exception
    {
        public EmailManagerException()
        {
        }

        public EmailManagerException(string? message) : base(message)
        {
        }

        public EmailManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
