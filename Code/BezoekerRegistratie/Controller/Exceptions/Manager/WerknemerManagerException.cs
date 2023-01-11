using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Exceptions.Manager
{
    public class WerknemerManagerException : Exception
    {
        public WerknemerManagerException()
        {
        }

        public WerknemerManagerException(string? message) : base(message)
        {
        }

        public WerknemerManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
