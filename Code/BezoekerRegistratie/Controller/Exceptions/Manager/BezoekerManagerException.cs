using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Exceptions.Manager
{
    public class BezoekerManagerException : Exception
    {
        public BezoekerManagerException()
        {
        }

        public BezoekerManagerException(string? message) : base(message)
        {
        }

        public BezoekerManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
