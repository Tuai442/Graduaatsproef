using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Exceptions.Manager
{
    public class AfspraakManagerException : Exception
    {
        public AfspraakManagerException()
        {
        }

        public AfspraakManagerException(string? message) : base(message)
        {
        }

        public AfspraakManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
