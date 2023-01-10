using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Exceptions.Manager
{
    public class BedrijfManagerException : Exception
    {
        public BedrijfManagerException()
        {
        }

        public BedrijfManagerException(string? message) : base(message)
        {
        }

        public BedrijfManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

      
    }
}
